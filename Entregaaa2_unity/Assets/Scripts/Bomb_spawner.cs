using System.Collections;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private GameObject bombPrefab; // El prefab de la MiniBomba

    [Header("Configuración de Generación")]
    [SerializeField] private float spawnRate = 0.5f; // Cada cuántos segundos cae una bomba
    [SerializeField] private float spawnWidth = 10f; // Ancho del área en el eje X
    [SerializeField] private float spawnDepth = 10f; // Largo del área en el eje Z

    private void Start()
    {
        if (bombPrefab == null)
        {
            Debug.LogError("[BombSpawner] Falta asignar el Prefab de la bomba.");
            return;
        }

        // Iniciar la lluvia de bombas
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            SpawnBomb();
        }
    }

    private void SpawnBomb()
    {
        // Calcular una posición aleatoria dentro del rectángulo del Spawner
        float randomX = Random.Range(-spawnWidth / 2f, spawnWidth / 2f);
        float randomZ = Random.Range(-spawnDepth / 2f, spawnDepth / 2f);

        Vector3 spawnPosition = transform.position + new Vector3(randomX, 0f, randomZ);

        // Crear la bomba en el cielo
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
    }

    // Dibuja la zona de peligro en el editor de Unity (Caja amarilla)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnWidth, 0.5f, spawnDepth));
    }
}