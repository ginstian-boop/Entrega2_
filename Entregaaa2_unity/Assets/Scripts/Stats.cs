using UnityEngine;

public class Stats : MonoBehaviour
{
    public float _vida = 50f;
    public float _maxvida = 100f;
    public float _veloci = 5f;
    public bool _escudoboo = false;

public void Heal(float amount) => _vida = Mathf.Min(_vida + amount, _maxvida);

public void TakeDamage(float amount)
    {

        if (_escudoboo)
        {
            _escudoboo = false;
            return;
        }
        _vida = Mathf.Max(_vida - amount, 0);

    }

 public void SetSpeedMultiplier(float multiplier) => _veloci *= multiplier;

public void SetShield(bool active) => _escudoboo = active;
}
