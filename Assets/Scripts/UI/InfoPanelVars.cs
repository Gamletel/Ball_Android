using UnityEngine;
using UnityEngine.UI;

public class InfoPanelVars : MonoBehaviour
{
    [SerializeField] private Text _maxLvlTxt;
    [SerializeField] private Text _coinsAmountTxt;
    [SerializeField] private SaveSystem _saveSystem;
    private int _maxLvl;
    private int _coinsAmount;

    //При запуске приложения читаем данные сохранения
    void Start()
    {
        _saveSystem.ReadData(_maxLvl, _coinsAmount);
        UpdateInfo();
    }

    //Обновляем данные
    private void UpdateInfo()
    {
        _maxLvlTxt.text = $"Уровней пройдено: {_maxLvl}";
        _coinsAmountTxt.text = $"Собрано монеток: {_coinsAmount}";
    }
}
