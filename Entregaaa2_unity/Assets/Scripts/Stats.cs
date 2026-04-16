using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para reiniciar niveles

public class Stats : MonoBehaviour
{
    public float _vida = 50f;
    public float _maxvida = 100f;
    public float _veloci = 5f;
    public bool _escudoboo = false;

    public void Heal(float amount) => _vida = Mathf.Min(_vida + amount, _maxvida);

    public void TakeDamage(float amount)
    {
        // Si el escudo está activo, ignoramos el daño y NO lo desactivamos
        if (_escudoboo)
        {
            return;
        }

        // Si no hay escudo, restamos vida normalmente
        _vida = Mathf.Max(_vida - amount, 0);

        if (_vida <= 0)
        {
            ReiniciarNivel();
        }
    }

    public void SetSpeedMultiplier(float multiplier) => _veloci *= multiplier;
    public void SetShield(bool active) => _escudoboo = active;

    private void ReiniciarNivel()
    {
        // Esto obtiene el nombre de la escena actual y la vuelve a cargar
        Scene escenaActual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(escenaActual.name);
    }
}