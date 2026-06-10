using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private PlayerCurrency playerCurrency;
    [SerializeField] private TMP_Text coinText;

    private void Update()
    {
        coinText.text = $"{playerCurrency.Coins}";
    }
}