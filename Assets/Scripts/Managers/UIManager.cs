using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthTextObject;
    private string healthText = "Health: 100";

    public void UpdateHealthText(int newHealth)
    {
        healthText = "Health: " + newHealth;
        healthTextObject.text = healthText;
    }
}
