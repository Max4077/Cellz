using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSpawner : MonoBehaviour
{
    /// <summary>
    /// the cell prefab to spawn
    /// </summary>
    private GameObject cell;
    [SerializeField] private CinemachineSmoothPath path;
    [SerializeField] private GameManager gameManager;

    public int spawnAmount = 10;
    public float spawnDelay = 1;

    private IEnumerator spawnCells;

    void Start()
    {
        spawnCells = SpawnCells(spawnAmount, spawnDelay);
        StartCoroutine(spawnCells);
    }

    public IEnumerator SpawnCells(int amount, float delay)
    {
        for(int i = 0; i < amount; i++)
        {
            SpawnRandomCell();
            yield return new WaitForSeconds(delay);
        }
    }
    public void SpawnRandomCell()
    {
        int random = Random.Range(1, 5);

        if(random == 1)
        {
            cell = (GameObject)Instantiate(Resources.Load("Cells/CancerCell"));
        }
        else
        {
            cell = (GameObject)Instantiate(Resources.Load("Cells/HealthyCell"));
        }

        cell.GetComponent<CinemachineDollyCart>().m_Path = path;
        cell.GetComponent<CellBase>().SetGameManager(gameManager);
    }
}
