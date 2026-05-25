using System.Collections;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [Header("Configuración del Boost")]
    [SerializeField] private float speedMultiplier = 2f; 
    [SerializeField] private float duration = 4f;        
    
    [Header("Efectos Visuales (Opcional)")]
    [SerializeField] private GameObject visualModel;     

    private bool _isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
  
        if (_isCollected) return;

        
        PlayerMovementModel playerMovement = other.GetComponent<PlayerMovementModel>();

        if (playerMovement != null)
        {
           
            StartCoroutine(ApplySpeedBoost(playerMovement));
        }
    }

    private IEnumerator ApplySpeedBoost(PlayerMovementModel player)
    {
        _isCollected = true;

        //  Guardamos la velocidad original del jugador
        float originalSpeed = player.MoveSpeed;

        //  Aplicamos el multiplicador
        player.MoveSpeed = originalSpeed * speedMultiplier;
        Debug.Log($"[SpeedBoost] ¡Boost activado! Nueva velocidad: {player.MoveSpeed}");

        // Escondemos el objeto visualmente para que parezca que desapareció
        if (visualModel != null) visualModel.SetActive(false);
        
        // Si tienes un Collider, lo desactivamos para que no se vuelva a tocar
        if (TryGetComponent<Collider>(out Collider col)) col.enabled = false;

        // Esperamos el tiempo de duración en segundos
        yield return new WaitForSeconds(duration);

        // Devolvemos la velocidad a la normalidad
        player.MoveSpeed = originalSpeed;
        Debug.Log("[SpeedBoost] El efecto ha terminado. Velocidad restaurada.");

        //  Destruimos el objeto por completo de la escena
        Destroy(gameObject);
    }
}