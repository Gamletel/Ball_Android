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

    //Если игрок коснется стены, то воспроизведется звук удара
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(typeof(PlayerController), out Component component))
        {
            Punch();
        }
    }

    //Воспроизведение звука удара
    private void Punch()
    {
        _audioSourse.PlayOneShot(_wallPunchSound);
    }
}
