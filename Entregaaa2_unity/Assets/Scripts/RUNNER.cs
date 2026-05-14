using UnityEngine;
using UnityEngine.SceneManagement;

public class RUNNER : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Buscamos el UIManager en la escena y llamamos a la función de ganar
            UIManager ui = Object.FindFirstObjectByType<UIManager>();

            if (ui != null)
            {
                SceneManager.LoadScene(2);
            }

            // Destruimos la llave o la desactivamos
            gameObject.SetActive(false);
        }
    }


}