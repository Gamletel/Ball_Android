using UnityEngine;
using static GlobalVars.Vars;
public class CoinBank : MonoBehaviour
{
    //ПРИ ПОДБОРЕ смотрим добавляем монетки
    public delegate void CoinHandler(int coinCost);
    public static event CoinHandler coinCollected;

    //Всего монеток
    public static int coinsAmount { get; private set; }

    //Загружаем и обновляем изначальное количество монеток
    public static int LoadCoins()
    {
        coinsAmount = saveSystem.LoadCoins(coinsAmount);
        return coinsAmount;
    }

    //Добавляем монетки
    public static void OnCoinCollected(int coinCost)
    {
        coinsAmount += coinCost;
        saveSystem.SaveCoins(coinCost);
        coinCollected?.Invoke(coinsAmount);  
    }
}