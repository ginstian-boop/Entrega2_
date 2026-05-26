using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LlaveVictoria : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        {
            if (other.CompareTag("Player"))
            {

                SceneManager.LoadScene(1);


                // Destruimos la llave o la desactivamos
                gameObject.SetActive(false);
            }
        }
    }
}