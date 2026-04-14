using UnityEngine;

public class trampas : MonoBehaviour
{
    public Stats _stats;
 


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Osaka"))
        {
            _stats.TakeDamage(1f);

        }
    }
}
