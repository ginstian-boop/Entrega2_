using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniBomb : MonoBehaviour
{
    [Header("Configuración de Explosión")]
    [SerializeField] private float explosionRadius = 3f; // Qué tan grande es la explosión
    [SerializeField] private GameObject explosionEffectPrefab; // Partículas de la explosión (opcional)

    private void OnCollisionEnter(Collision collision)
    {
        // Al chocar contra CUALQUIER cosa (suelo, obstáculos, jugador), explota
        Explode();
    }

    private void Explode()
    {
        Debug.Log("[MiniBomb] ¡BOOM! La bomba ha impactado.");

        // 1. Instanciar efectos visuales si tienes uno asignado
        if (explosionEffectPrefab != null)
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        }
        

Vector3 explosionCenter = transform.position + Vector3.up * 1f;
        // 2. Detectar si el jugador estaba dentro del rango de la explosión
        // Creamos una esfera invisible en la física para ver qué objetos tocó
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        
        foreach (Collider hit in colliders)
        {
            if (hit.CompareTag("Player"))
            {
                Debug.Log("[MiniBomb] El jugador fue alcanzado por la onda expansiva. Reiniciando...");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break; // Salimos del bucle porque ya encontramos al jugador
            }
        }

        // 3. Destruir la bomba física de la escena
        Destroy(gameObject);
    }

    // Dibuja el radio de la explosión en el editor al seleccionarla para que puedas calibrar el tamaño
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}