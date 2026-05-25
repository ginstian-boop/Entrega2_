using System.Collections;
using UnityEngine;

public class StaticCannon : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private GameObject bulletPrefab; // El prefab de la bala (el mismo CannonBall de antes)
    [SerializeField] private Transform firePoint;     // Desde dónde sale la bala

    [Header("Configuración del Cañón")]
    [SerializeField] private float fireRate = 2f;     // Tiempo en segundos entre disparos
    [SerializeField] private bool startFiringOnPlay = true; // ¿Empieza a disparar apenas inicia el nivel?

    private bool _isShooting = false;

    private void Start()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogError("[StaticCannon] Faltan referencias por asignar en el Inspector.");
            return;
        }

        if (startFiringOnPlay)
        {
            StartCoroutine(FireRoutine());
        }
    }

    // Puedes llamar a este método desde otros scripts si quieres activar/desactivar el cañón
    public void ToggleShooting(bool state)
    {
        if (state && !_isShooting)
        {
            StartCoroutine(FireRoutine());
        }
        else if (!state)
        {
            _isShooting = false;
        }
    }

    private IEnumerator FireRoutine()
    {
        _isShooting = true;

        // Esperar un pequeño retraso inicial aleatorio opcional 
        // por si pones varios cañones juntos y no quieres que disparen al mismo milisegundo
        yield return new WaitForSeconds(Random.Range(0f, 0.5f));

        while (_isShooting)
        {
            Shoot();
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;

        // Instanciamos la bala usando la posición y rotación exacta del FirePoint
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        Debug.Log("[StaticCannon] ¡Disparo estático ejecutado!");
    }
}