using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;

    private int currentHealth;
    [SerializeField] private int maxHealth;

    #region Debug
    public CellSpawner spawner;
    public GameObject chemoTower;
    public GameObject immunoTower;

    public void SpawnMixedCells()
    {
        spawner.SpawnMixedCells();
    }
    public void SpawnCancerCells()
    {
        spawner.SpawnCancerCells();
    }
    public void ToggleChemoTower()
    {
        chemoTower.SetActive(!chemoTower.activeSelf);
    }
    public void ToggleImmunoTower()
    {
        immunoTower.SetActive(!immunoTower.activeSelf);
    }
    #endregion Debug

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
