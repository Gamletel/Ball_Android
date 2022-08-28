using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class WallController : MonoBehaviour
{
    private AudioSource _audioSourse;
    [SerializeField] private AudioClip _wallPunchSound;

    private void Start()
    {
        _audioSourse = GetComponent<AudioSource>();
    }

    //���� ����� �������� �����, �� ��������������� ���� �����
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(typeof(PlayerController), out Component component))
        {
            Punch();
        }
    }

    //��������������� ����� �����
    private void Punch()
    {
        _audioSourse.PlayOneShot(_wallPunchSound);
    }
}
