using UnityEngine;
using TMPro; // Necesario para usar TextMeshPro

public class PlayerInventory : MonoBehaviour
{
    [Header("UI de Monedas")]
    [SerializeField] private TextMeshProUGUI coinText; 

    // Propiedad pública para que la puerta pueda consultar cuántas monedas tenemos
    public int CurrentCoins { get; private set; }

    private void Start()
    {
        CurrentCoins = 0;
        UpdateCoinUI();
    }

    public void AddCoin(int amount)
    {
        CurrentCoins += amount;
        Debug.Log($"[Inventory] Moneda recogida. Total: {CurrentCoins}");
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = "Monedas: " + CurrentCoins;
        }
    }
}