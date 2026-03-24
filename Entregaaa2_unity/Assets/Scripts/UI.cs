using UnityEngine;  
using TMPro;


public class PowerUpUI : MonoBehaviour
{
 
    public Stats player;
    public TMP_InputField valueInput;
    public TMP_Text messageText;
    public TMP_Text selectedText;

    private PowerType currentSelection;


    public void SelectHeal() { currentSelection = PowerType.vida;
     selectedText.text = "Seleccionado: Vida"; }
    public void SelectShield() { currentSelection = PowerType.shield; 
    selectedText.text = "Seleccionado: Escudo"; }
    public void SelectSpeed() { currentSelection = PowerType.speed; 
    selectedText.text = "Seleccionado: Velocidad"; }
    public void SelectDamage() { currentSelection = PowerType.damage; 
    selectedText.text = "Seleccionado: Daño"; }

    public void ApplySelectedPowerUp()
    {
        if (!ValidateReferences()) return;

        float val = 0;
    
        if (currentSelection != PowerType.shield)
        {
            if (!TryReadValue(out val)) return;
            if (!ValidateRules(val)) return;
        }
        else
        {
         
            if (player._escudoboo)
            {
                messageText.text = "Error: Escudo ya activo";
                return;
            }
        }

        ApplyPowerUp(val); 
    }



    private bool ValidateReferences()
    {
        if (player == null) { messageText.text = " No hay Player"; return false; }
        return true;
    }

    private bool TryReadValue(out float value)
    {
        if (float.TryParse(valueInput.text, out value)) return true; 
        messageText.text = "Error: Introduce un número válido";
        return false;
    }

    private bool ValidateRules(float value)
    {
        if (value <= 0) { messageText.text = "Error: El valor debe ser > 0"; return false; }

        if (currentSelection == PowerType.vida && player._vida >= player._maxvida)
        {
            messageText.text = "Error: Vida ya al máximo"; return false; 
        }

        if (currentSelection == PowerType.shield && player._escudoboo)
        {
            messageText.text = "Error: Escudo ya activo"; return false; 
        }

        return true;
    }

    private void ApplyPowerUp(float value)
    {
       
        switch (currentSelection)
        {
            case PowerType.vida:
                player.Heal(value);
                messageText.text = $"Curado! Vida: {player._vida}";
                break;
            case PowerType.shield:
                player.SetShield(true);
                messageText.text = "Escudo Activado";
                break;
            case PowerType.speed:
                player.SetSpeedMultiplier(value);
                messageText.text = $"Velocidad actual: {player._veloci}"; 
                break;
            case PowerType.damage:
                player.TakeDamage(value);
                messageText.text = $"¡Daño recibido! Vida restante: {player._vida}"; 
                break;
        }
    }
}