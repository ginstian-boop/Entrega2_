using UnityEngine;  // Librería principal de Unity.

public class PlayerMovementModel : MonoBehaviour
{
    [Header("Referencias")]

    // Referencia al script que lee el input.
    [SerializeField] private PlayerInputController playerInputController;

    // Referencia al Rigidbody del personaje.
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Collider playerCollider;
    [Header("Salto")]
    [SerializeField] private float jumpForce = 6.7f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckExtra = 0.1f;
    

    public bool _isGrounded;

    [Header("Movimiento")]

    //fuerza de salto
 

    // Velocidad de movimiento del personaje.
    [SerializeField] private float moveSpeed = 5f;

    // Velocidad horizontal actual del personaje.
    public Vector3 CurrentHorizontalVelocity { get; private set; }

    // Magnitud de la velocidad horizontal.
    public float CurrentSpeed { get; private set; }

    // NUEVO:-
    // Dirección actual del movimiento en el plano XZ.
    // Esto lo usaremos para girar visualmente al personaje.
    public Vector3 CurrentMoveDirection { get; private set; }

    public bool IsGrounded => _isGrounded;

    private void Start()
    {
        // Revisamos referencias importantes.
        if (playerInputController == null)
        {
            Debug.LogError("[PlayerMovementModel] Falta asignar PlayerInputController en el Inspector.");
        }

        if (rb == null)
        {
            Debug.LogError("[PlayerMovementModel] Falta asignar Rigidbody en el Inspector.");
        }
        if (playerInputController == null) Debug.LogError("Falta PlayerInputController.");
    
    }


    private void Update()
    {
        if (playerInputController.JumpTriggered && _isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
        // Mueve el rigidbody.
        Move();

        // Actualiza velocidad y dirección real.
        UpdateVelocityData();
    }
    private void CheckGround()
    {
        // Calculamos la distancia desde el centro hasta la base del colisionador
        float rayLength = playerCollider.bounds.extents.y + groundCheckExtra;

        // Lanzamos el rayo desde el centro hacia abajo
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, rayLength, groundLayer);

        // Debug visual: Verde si toca suelo, Rojo si está en el aire
        Debug.DrawRay(transform.position, Vector3.down * rayLength, _isGrounded ? Color.green : Color.red);
    }
    private void Move()
    {
        // Si falta algo, no seguimos.
        if (playerInputController == null || rb == null) return;

        // Leemos el input actual.
        Vector2 input = playerInputController.MoveInput;

        // Convertimos el input 2D a dirección 3D.
        Vector3 moveDirection = new Vector3(input.x, 0f , input.y);

        // Si la magnitud es mayor a 1, normalizamos
        // para evitar que en diagonal se mueva más rápido.
        if (moveDirection.magnitude > 1f)
        {
            moveDirection.Normalize();
        }

        // Guardamos la dirección actual solo si realmente hay input.
        if (moveDirection != Vector3.zero)
        {
            CurrentMoveDirection = moveDirection;
        }

        // Creamos la nueva velocidad.
        Vector3 newVelocity = new Vector3(
            moveDirection.x * moveSpeed,
            rb.linearVelocity.y,
            moveDirection.z * moveSpeed
            
        );

        // Aplicamos la velocidad al Rigidbody.
        rb.linearVelocity = newVelocity;

        // Debug de movimiento.
        if (moveDirection != Vector3.zero)
        {
            Debug.Log($"[PlayerMovementModel] Dirección de movimiento: {CurrentMoveDirection}");
            Debug.Log($"[PlayerMovementModel] Velocidad aplicada al Rigidbody: {rb.linearVelocity}");
        }
    }
    private void Jump()
    {
        // Resetear velocidad vertical antes de aplicar el impulso
        // Esto asegura que el salto siempre llegue a la misma altura
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // Aplicamos el salto como un impulso instantáneo
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        Debug.Log("[PlayerMovementModel] Salto ejecutado.");
    }
    private void UpdateVelocityData()
    {
        // Si no hay rigidbody, no seguimos.
        if (rb == null) return;

        // Tomamos la velocidad actual del rigidbody.
        Vector3 horizontalVelocity = rb.linearVelocity;

        // Quitamos Y para quedarnos solo con movimiento horizontal.
        horizontalVelocity.y = 0f;

        // Guardamos velocidad horizontal.
        CurrentHorizontalVelocity = horizontalVelocity;

        // Calculamos la magnitud de la velocidad.
        CurrentSpeed = horizontalVelocity.magnitude;

        // Debug importante para comprobar velocidad real.
        if (CurrentSpeed > 0f)
        {
            Debug.Log($"[PlayerMovementModel] CurrentHorizontalVelocity: {CurrentHorizontalVelocity} | CurrentSpeed: {CurrentSpeed}");
        }
    }
}