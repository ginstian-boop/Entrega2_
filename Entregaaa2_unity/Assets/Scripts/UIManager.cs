using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private TMP_Text vidaText;
    [SerializeField] private TMP_Text escudoText;

    public Stats _stats; // Arrastra al jugador aquí en el Inspector

    void Update()
    {
        if (_stats != null)
        {
            // Actualizamos el texto de vida (0 decimales para que se vea limpio)
            vidaText.text = "Vida: " + Mathf.RoundToInt(_stats._vida).ToString();

            // Mostramos si el escudo está activo o no
            if (_stats._escudoboo)
            {
                escudoText.text = "ESCUDO: ACTIVO";
                escudoText.color = Color.cyan;
            }
            else
            {
                escudoText.text = "ESCUDO: AGOTADO";
                escudoText.color = Color.red;
            }
        }
    }
    // Añade esto a tus variables actuales en UIManager.cs
    [SerializeField] private GameObject panelVictoria;

    // Añade esta función al final del script
    public void MostrarVictoria()
    {
        if (panelVictoria != null)
        {
            panelVictoria.SetActive(true);

            // Opcional: Pausar el juego para que el jugador no siga moviéndose
            Time.timeScale = 0f;
        }
    }
}