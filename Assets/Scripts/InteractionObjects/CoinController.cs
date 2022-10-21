using UnityEngine;
public class CoinController : MonoBehaviour
{
    private int _coinCost = 2;

    //Если игрок зашел в триггер монетки, тогда добавляем монетку
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(typeof(PlayerController), out Component component))
        {
            AddCoin(_coinCost);
        }
    }

    //Метод для добавления монетки и её последующего уничтожения
    private void AddCoin(int coinCost)
    {
        CoinBank.OnCoinCollected(coinCost);
        Destroy(gameObject);
    }
}
