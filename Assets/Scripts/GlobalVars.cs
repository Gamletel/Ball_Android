using UnityEngine;
using UnityEngine.SceneManagement;

namespace GlobalVars
{
    public class Vars : MonoBehaviour
    {
        //скрипт с системой сохранений
        public static SaveSystem saveSystem = GameObject.FindGameObjectWithTag("SaveSystem").GetComponent<SaveSystem>();

        //сколько всего сцен в билде
        public static int sceneCount = SceneManager.sceneCountInBuildSettings;
        
    }
}

