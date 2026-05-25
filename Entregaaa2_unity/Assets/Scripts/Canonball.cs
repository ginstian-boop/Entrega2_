using UnityEngine;
using UnityEngine.SceneManagement;

public class CannonBall : MonoBehaviour
{
    [Header("Configuración Física")]
    [SerializeField] private float speed = 15f;
    [SerializeField] private float lifeTime = 5f; // Segundos antes de destruirse sola
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        
        // Le damos velocidad inicial en la dirección "hacia adelante" del objeto
        rb.linearVelocity = transform.forward * speed;

        // Destruir la bala automáticamente después de unos segundos para no llenar la memoria
        Destroy(gameObject, lifeTime);
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    
        // La bala se destruye al chocar contra cualquier cosa (suelo, paredes, jugador)
        Destroy(gameObject);
    }
}