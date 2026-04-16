using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FINAL_ : MonoBehaviour
{



    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {

            SceneManager.LoadScene(0);
           

        }
    }

}
