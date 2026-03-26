using UnityEngine;                  // Librería principal de Unity.
using UnityEngine.InputSystem;      // Librería del nuevo Input System.

public class PlayerInputController : MonoBehaviour
{
    // Referencia privada a la acción de movimiento del Input System.
    private InputAction _moveAction;
    private InputAction _jumpAction;

    // Propiedad pública de solo lectura.
    public Vector2 MoveInput { get; private set; }
    public bool JumpTriggered { get; private set; }
    private void Start()
    {
        // Busca la acción llamada "Move" dentro del Input Actions Asset.
        _moveAction = InputSystem.actions.FindAction("Move");

        _jumpAction = InputSystem.actions.FindAction("Jump");

        // Si la encuentra, la habilita.
        if (_moveAction != null)
        {
            _moveAction.Enable();
            Debug.Log("[PlayerInputController] Acción 'Move' encontrada y habilitada correctamente.");
        }
        else
        {
            Debug.LogError("[PlayerInputController] No se encontró la acción 'Move'.");
        }
        if (_jumpAction != null)
        {
            _jumpAction.Enable(); 
        }
        else
        {
            Debug.LogError("[PlayerInputController] No se encontró 'Jump'. ¿Creaste la acción en el Asset?");
        }
    }

    private void Update()
    {
        // Si no existe la acción, salimos.
        if (_moveAction == null) return;

        // Leemos el input actual como Vector2.
        MoveInput = _moveAction.ReadValue<Vector2>();

        if (_jumpAction == null) return;

        // Debug solo cuando hay input.
        if (MoveInput != Vector2.zero)
        {
            Debug.Log($"[PlayerInputController] Input detectado: {MoveInput}");
        }

        if (_jumpAction != null)
        { 
            JumpTriggered = _jumpAction.WasPressedThisFrame();
        
        }
    }

    private void OnDisable()
    {
        // Deshabilitamos la acción cuando el objeto se apaga.
        if (_moveAction != null)
        {
            _moveAction.Disable();
            Debug.Log("[PlayerInputController] Acción 'Move' deshabilitada.");
        }
        if (_jumpAction != null)
        {
            _jumpAction.Disable();
            Debug.Log("[PlayerInputController] Acción 'Jump' deshabilitada.");
        }
    }
}