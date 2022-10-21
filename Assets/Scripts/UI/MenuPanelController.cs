using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPanelController : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;

    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private Text _openMenuBtnText;
    [SerializeField] private Text _nameLvlText;
    [SerializeField] private Text _collectedCoinsText;
    private bool _playBackwards;
    private DOTweenAnimation _tween;

    private void Start()
    {
        _tween = _mainMenuPanel.GetComponent<DOTweenAnimation>();
        _nameLvlText.text = $"Уровень: {SceneManager.GetActiveScene().buildIndex}";
        //Подписываемся на событие
        CoinBank.coinCollected += OnCoinCollected;
        //Загружаем изначальное значение монеток
        UpdateCoinsAmount(CoinBank.coinsAmount);
    }

    //Вызывается при сборе монетки
    private void OnCoinCollected(int coinsAmount)
    {
        UpdateCoinsAmount(coinsAmount);
    }

    //Обновляем количество монеток
    private void UpdateCoinsAmount(int coinsAmount)
    {
        _collectedCoinsText.text = $"Монеток: {coinsAmount}";
    }

    //Для открытия/закрытия боковой панели
    public void MovePanel()
    {
        switch (!_playBackwards)
        {
            case true:
                _tween.DOPlayForward();
                _playBackwards = !_playBackwards;
                _openMenuBtnText.text = "Закрыть";
                return;
            case false:
                _tween.DOPlayBackwards();
                _playBackwards = !_playBackwards;
                _openMenuBtnText.text = "Меню";
                return;
        }
        
    }

    //Обновляем id уровня на панели сверху
    public void LoadMenuScene()
    {
        int menuSceneIndex = 0;
        SceneManager.LoadScene(menuSceneIndex);
    }

    //Вызывать когда нужно открыть меню Победы/Проигрыша
    public void OpenWinPanel()
    {
        _winPanel.SetActive(true);
    }

    public void OpenLosePanel()
    {
        _losePanel.SetActive(true);
    }
}
