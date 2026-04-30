using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemigo : MonoBehaviour
{

    [SerializeField] private Transform player; // Arrastra aquí al jugador desde el editor

    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player != null)
        {
            // Le indica al agente que se mueva hacia la posición del jugador
            agent.SetDestination(player.position);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Comprobamos si el objeto que colisiona tiene la etiqueta "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);

        }
    }
}


