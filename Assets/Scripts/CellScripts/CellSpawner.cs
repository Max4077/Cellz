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

    /// <summary>
    /// Check this to spawn only cancer cells for debugging
    /// </summary>
    public bool onlyCancerCells = false;
    private int cancerAmount = 5;

    private IEnumerator spawnCells;

    private void Awake()
    {
        if (onlyCancerCells) cancerAmount = 2;
    }

    void Start()
    {
        //spawnCells = SpawnCells(spawnAmount, spawnDelay);
        //StartCoroutine(spawnCells);
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
        int random = Random.Range(1, cancerAmount);

        if(random == 1)
        {
            int cellType = Random .Range(0, 3);
            switch (cellType)
            {
                case 0:
                    cell = (GameObject)Instantiate(Resources.Load("Cells/CancerCellA"));
                    break;
                case 1:
                    cell = (GameObject)Instantiate(Resources.Load("Cells/CancerCellB"));
                    break;
                case 2:
                    cell = (GameObject)Instantiate(Resources.Load("Cells/CancerCellC"));
                    break;
            }
            cell.GetComponent<CancerCell>().cellType = cellType;
        }
        else
        {
            cell = (GameObject)Instantiate(Resources.Load("Cells/HealthyCell"));
        }

        cell.GetComponent<CinemachineDollyCart>().m_Path = path;
        cell.GetComponent<CellBase>().SetGameManager(gameManager);
    }

    public void SpawnMixedCells()
    {
        cancerAmount = 5;
        spawnCells = SpawnCells(spawnAmount, spawnDelay);
        StartCoroutine(spawnCells);
    }
    public void SpawnCancerCells()
    {
        cancerAmount = 2;
        spawnCells = SpawnCells(spawnAmount, spawnDelay);
        StartCoroutine(spawnCells);
    }
}
