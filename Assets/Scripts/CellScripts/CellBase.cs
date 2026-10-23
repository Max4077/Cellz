using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CellBase : MonoBehaviour
{
    private GameManager gameManager;
    private CinemachineDollyCart cart; //may be uneccesary

    [SerializeField] protected int healthChangeAmount;

    private void Awake()
    {
        cart = GetComponent<CinemachineDollyCart>();
    }

    public void SetGameManager(GameManager gameManager)
    {
        //print("setting game manager for one cell");
        this.gameManager = gameManager;
    }
    public void ChangeHealth()
    {
        if(gameManager == null) print("gameManager is null for some reason ");
        gameManager.ChangeHealth(healthChangeAmount);
    }
}
