using UnityEngine;
using TMPro;

public class CoinDoor : MonoBehaviour
{
    [Header("Configuración de Apertura")]
    [SerializeField] private int coinsRequired = 5; // Monedas necesarias para abrir
    [SerializeField] private GameObject doorVisual;   // El objeto 3D de la puerta que desaparecerá

    [Header("UI de Advertencia de la Puerta")]
    [SerializeField] private GameObject doorUIPanel;   // Un texto flotante o cartel en pantalla
    [SerializeField] private TextMeshProUGUI doorUIText; // Texto que dice "Necesitas X monedas"

    private void Start()
    {
        // Nos aseguramos de que el cartel de la puerta empiece oculto
        if (doorUIPanel != null) doorUIPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory inventory = other.GetComponent<PlayerInventory>();

        if (inventory != null)
        {
            // 1. ¿Tiene las monedas suficientes?
            if (inventory.CurrentCoins >= coinsRequired)
            {
                OpenDoor();
            }
            else
            {
                // 2. Si no las tiene, le mostramos el aviso en pantalla
                ShowWarning(inventory.CurrentCoins);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el jugador se aleja de la puerta, ocultamos el aviso
        if (other.CompareTag("Player") && doorUIPanel != null)
        {
            doorUIPanel.SetActive(false);
        }
    }

    private void OpenDoor()
    {
        Debug.Log("[CoinDoor] ¡Puerta abierta con éxito!");
        
        if (doorUIPanel != null) doorUIPanel.SetActive(false);

        // Desactivamos el objeto visual de la puerta (puedes destruirla o reproducir una animación)
        if (doorVisual != null)
        {
            doorVisual.SetActive(false); 
        }
        else
        {
            gameObject.SetActive(false); // Si no asignaste un hijo, desaparece todo el objeto
        }
    }

    private void ShowWarning(int currentCoins)
    {
        if (doorUIPanel == null || doorUIText == null) return;

        doorUIPanel.SetActive(true);
        int missing = coinsRequired - currentCoins;
        doorUIText.text = $"¡DAME MAS!\nNecesitas {missing} monedas más.";
    }
}