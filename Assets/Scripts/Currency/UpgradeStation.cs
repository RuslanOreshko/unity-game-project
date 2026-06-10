using UnityEngine;

public class UpgradeStation : MonoBehaviour
{

    [SerializeField] private PlayerInputHandler input;
    [SerializeField] private GameObject upgradeHint;
    [SerializeField] private int upgradeCost = 5;

    private bool playerInside;

    private PlayerCurrency playerCurrency;
    private WorldSwitcher worldSwitcher;
    private UpgradeMessageUI upgradeMessageUI;

    private void Start()
    {
        worldSwitcher = FindFirstObjectByType<WorldSwitcher>();
        upgradeMessageUI = FindFirstObjectByType<UpgradeMessageUI>();
    }

    private void Update()
    {
        if (!playerInside)
            return;

        if (input.InteractPressed)
        {
            Debug.Log("E pressed");
            if (playerCurrency.SpendCoins(upgradeCost))
            {
                worldSwitcher.ReduceCooldown();
                upgradeMessageUI.ShowMessage("Cooldown reduced!");
                Debug.Log("Cooldown upgraded!");
            }
            else
            {
                Debug.Log("Not enough coins!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerCurrency>(out var currency))
        {
            playerCurrency = currency;
            playerInside = true;

            upgradeHint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerCurrency>(out _))
        {
            playerInside = false;

            upgradeHint.SetActive(false);
        }
    }
}