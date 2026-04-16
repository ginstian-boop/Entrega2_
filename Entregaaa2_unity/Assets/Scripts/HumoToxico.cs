using UnityEngine;

public class HumoToxico : MonoBehaviour
{
    public float dañoPorSegundo = 20f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Stats playerStats = other.GetComponent<Stats>();
            if (playerStats != null)
            {
                // Usamos Time.deltaTime para que el daño sea constante mientras esté dentro
                playerStats.TakeDamage(dañoPorSegundo * Time.deltaTime);
            }
        }
    }
}