using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que la tocó tiene el inventario
        PlayerInventory inventory = other.GetComponent<PlayerInventory>();

        if (inventory != null)
        {
            inventory.AddCoin(coinValue);
            
           
            Destroy(gameObject); // La moneda desaparece
        }
    }
}