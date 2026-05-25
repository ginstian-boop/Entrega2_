using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bandera : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
     
                SceneManager.LoadScene(1);
            

          
            gameObject.SetActive(false);
        }
    }

    
}