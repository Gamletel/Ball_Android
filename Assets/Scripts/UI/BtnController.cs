using UnityEngine;

public class BtnController : MonoBehaviour
{
    [SerializeField] private AudioSource _btnPressedSound;

    public void BtnPressed()
    {
        _btnPressedSound.PlayOneShot(_btnPressedSound.clip);
    }
}
