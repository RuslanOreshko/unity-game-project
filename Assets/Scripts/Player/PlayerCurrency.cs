using UnityEngine;

public class PlayerCurrency : MonoBehaviour
{
    public int Coins { get; private set; }

    public void AddCoin(int amount)
    {
        Coins += amount;
        Debug.Log($"Coins: {Coins}");
    }

    public bool SpendCoins(int amount)
    {
        if (Coins < amount)
            return false;

        Coins -= amount;
        return true;
    }
}