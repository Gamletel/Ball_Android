using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
[RequireComponent(typeof(AudioSource))]
public class MovementHandler : MonoBehaviour
{
    private readonly float _speed = 0.4f;
    private Rigidbody _rb;
    private InputHandler _input;
    private Vector3 _curDeltaPos;
    private AudioSource _audioSource;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<InputHandler>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    //≈сли получаем касание, тогда начинаем добавл€ть силу к игроку в соответствующую сторону
    void FixedUpdate()
    {
        if (_input.isTouched())
        {
            MoveBall();
        }
        PlayMoveSound();
    }

    //—мотрим в каком направлении прилагать силу и примен€ем эту силу
    private void MoveBall()
    {
        _curDeltaPos = new Vector3(_input.GetTouchDeltaPos().x, 0, _input.GetTouchDeltaPos().y);
        _curDeltaPos *= _speed;
        _rb.AddForce(_curDeltaPos, ForceMode.Force);

    }

    //¬оспроизведение звука перекатывани€ шара
    private void PlayMoveSound()
    {
        _audioSource.volume = _rb.angularVelocity.magnitude/10;
    }
}