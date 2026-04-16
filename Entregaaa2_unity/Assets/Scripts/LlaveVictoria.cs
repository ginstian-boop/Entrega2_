using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LlaveVictoria : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Buscamos el UIManager en la escena y llamamos a la función de ganar
            UIManager ui = Object.FindFirstObjectByType<UIManager>();

            if (ui != null)
            {
                SceneManager.LoadScene(1);
            }

            // Destruimos la llave o la desactivamos
            gameObject.SetActive(false);
        }
    }

    
}