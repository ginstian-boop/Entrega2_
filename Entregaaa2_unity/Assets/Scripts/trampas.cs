using UnityEngine;

public class trampas : MonoBehaviour
{
    public Stats _stats;
 


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _stats.TakeDamage(1f);

                transform.position = new Vector3(0, 0, 0); // Or a stored startPosition
        }
        
    }
}
