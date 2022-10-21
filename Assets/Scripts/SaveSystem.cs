using UnityEngine;
using UnityEngine.SceneManagement;
using static GlobalVars.Vars;

[RequireComponent(typeof(LvlAutoSaver))]
    public class SaveSystem : MonoBehaviour
    {
            private int coinsAmount;

            private void Start()
            {
                //Если нет данных о сохранении, то делаем переменные для сохранения 0, чтобы избежать ошибок об отсутствии
                if (!PlayerPrefs.HasKey("LastLvl"))
                {
                    PlayerPrefs.SetInt("LastLvl", 0);
                }
                if (!PlayerPrefs.HasKey("CoinsAmount"))
                {
                    PlayerPrefs.SetInt("CoinsAmount", 0);
                }
            }

        //При закрытии приложения сохраняем прогресс
        #if UNITY_ANDROID && !UNITY_EDITOR
                private void OnApplicationPause(bool pause)
                {
                if (pause)
                {
                PlayerPrefs.SetInt("LastLvl", SceneManager.GetActiveScene().buildIndex);
                PlayerPrefs.Save();
                }
                }
        #endif

    private void OnApplicationQuit()
            {
                PlayerPrefs.SetInt("LastLvl", SceneManager.GetActiveScene().buildIndex);
                PlayerPrefs.Save();
            }

            //Сохранение монеток
            public void SaveCoins(int coinCost)
            {
                PlayerPrefs.SetInt("CoinsAmount", coinsAmount += coinCost);
                Debug.Log($"Сохраненная сумма монеток: {PlayerPrefs.GetInt("CoinsAmount")}");
            }

            //Загрузка сохраненного количества монеток
            public int LoadCoins(int coinsAmount)
            {
                coinsAmount = PlayerPrefs.GetInt("CoinsAmount");
                Debug.Log($"Загружено монеток из банка: {coinsAmount}");
                return coinsAmount;
            }

            //Сохранение последнего пройденого уровня
            public void SaveLastLvl()
            {
                if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("LastLvl"))
                {
                    PlayerPrefs.SetInt("LastLvl", SceneManager.GetActiveScene().buildIndex);
                    Debug.Log($"Уровень {SceneManager.GetActiveScene().buildIndex} сохранен!");
                }
                else
                    Debug.Log("Сохранение не требуется!");
            }

            //Загрузка последнего сохраненного уровня
            public void LoadLastSavedLvl()
            {
                SceneManager.LoadScene(PlayerPrefs.GetInt("LastLvl"));
            }

            //Загрузка следующего уровня
            public void LoadNextLvl()
            {
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                if (nextSceneIndex <= sceneCount-1)
                    SceneManager.LoadScene(nextSceneIndex);
                else
                    SceneManager.LoadScene(0);
                Time.timeScale = 1;
            }

            //Перезапуск уровня
            public void RestartLvl()
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }

            //Читаем данные сохранения
            public void ReadData(int maxLvl, int coinsAmount)
            {
                
                maxLvl = PlayerPrefs.GetInt("LastLvl");
                coinsAmount = PlayerPrefs.GetInt("CoinsAmount");
            }
    }
