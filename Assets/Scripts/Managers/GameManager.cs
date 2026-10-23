using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;

    private int currentHealth;
    [SerializeField] private int maxHealth;

    private void Awake()
    {
        uiManager = GetComponent<UIManager>();
        currentHealth = maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        else if (currentHealth <= 0) GameOver();

        uiManager.UpdateHealthText(currentHealth);
    }

    public void GameOver()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
