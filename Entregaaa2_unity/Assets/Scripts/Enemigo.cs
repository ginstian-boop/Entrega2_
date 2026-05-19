using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.Collections;
public class Enemigo : MonoBehaviour

{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform characterVisual;
    [SerializeField] private Transform player; // Arrastra aquí al jugador desde el editor
    [SerializeField] private float rotationSpeed = 150f;

    private NavMeshAgent agent;



    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

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
        UpdateRotation();

 


    }

    
    private void UpdateRotation()
    {

        Vector3 horizontalVelocity = rb.linearVelocity;
        // Tomamos la dirección actual del movimiento.
        Vector3 moveDirection = horizontalVelocity;

        // Si no hay dirección, no rotamos.
        if (moveDirection == Vector3.zero) return;

        moveDirection.y = 0;
        // Calculamos la rotación objetivo basada en la dirección.
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

        // Rotamos suavemente hacia la dirección deseada.
        characterVisual.rotation = Quaternion.Slerp(
            characterVisual.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }

}



