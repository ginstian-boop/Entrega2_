using UnityEngine;

public class ItemEscudo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Si el jugador toca el diamante
        if (other.CompareTag("Player"))
        {
            Stats playerStats = other.GetComponent<Stats>();
            if (playerStats != null)
            {
                playerStats.SetShield(true); // Activa el escudo en tus Stats
                Destroy(gameObject); // El diamante desaparece
            }
        }
    }

}
