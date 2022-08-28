using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Player;

namespace GlobalVars
{
    public class Vars : MonoBehaviour
    {
        //������ � �������� ����������
        public static SaveSystem saveSystem = GameObject.FindGameObjectWithTag("SaveSystem").GetComponent<SaveSystem>();

        //������� ����� ���� � �����
        public static int sceneCount = SceneManager.sceneCountInBuildSettings;
        
    }
}

