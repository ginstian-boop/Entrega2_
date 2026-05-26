using UnityEngine;
using UnityEngine.SceneManagement;

public class BEE : MonoBehaviour
{
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
