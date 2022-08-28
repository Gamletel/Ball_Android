using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GlobalVars.Vars;

[RequireComponent(typeof(LvlAutoSaver))]
    public class SaveSystem : MonoBehaviour
    {
            private int coinsAmount;

            private void Start()
            {
                //���� ��� ������ � ����������, �� ������ ���������� ��� ���������� 0, ����� �������� ������ �� ����������
                if (!PlayerPrefs.HasKey("LastLvl"))
                {
                    PlayerPrefs.SetInt("LastLvl", 0);
                }
                if (!PlayerPrefs.HasKey("CoinsAmount"))
                {
                    PlayerPrefs.SetInt("CoinsAmount", 0);
                }
            }

        //��� �������� ���������� ��������� ��������
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

            //���������� �������
            public void SaveCoins(int coinCost)
            {
                PlayerPrefs.SetInt("CoinsAmount", coinsAmount += coinCost);
                Debug.Log($"����������� ����� �������: {PlayerPrefs.GetInt("CoinsAmount")}");
            }

            //�������� ������������ ���������� �������
            public int LoadCoins(int coinsAmount)
            {
                coinsAmount = PlayerPrefs.GetInt("CoinsAmount");
                Debug.Log($"��������� ������� �� �����: {coinsAmount}");
                return coinsAmount;
            }

            //���������� ���������� ���������� ������
            public void SaveLastLvl()
            {
                if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("LastLvl"))
                {
                    PlayerPrefs.SetInt("LastLvl", SceneManager.GetActiveScene().buildIndex);
                    Debug.Log($"������� {SceneManager.GetActiveScene().buildIndex} ��������!");
                }
                else
                    Debug.Log("���������� �� ���������!");
            }

            //�������� ���������� ������������ ������
            public void LoadLastSavedLvl()
            {
                SceneManager.LoadScene(PlayerPrefs.GetInt("LastLvl"));
            }

            //�������� ���������� ������
            public void LoadNextLvl()
            {
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                if (nextSceneIndex <= sceneCount-1)
                    SceneManager.LoadScene(nextSceneIndex);
                else
                    SceneManager.LoadScene(0);
                Time.timeScale = 1;
            }

            //���������� ������
            public void RestartLvl()
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }

            //������ ������ ����������
            public void ReadData(int maxLvl, int coinsAmount)
            {
                
                maxLvl = PlayerPrefs.GetInt("LastLvl");
                coinsAmount = PlayerPrefs.GetInt("CoinsAmount");
            }
    }
