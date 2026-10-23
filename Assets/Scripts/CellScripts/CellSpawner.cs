using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSpawner : MonoBehaviour
{
    private GameObject cell;
    public CinemachineSmoothPath path;

    void Start()
    {
        cell = (GameObject)Instantiate(Resources.Load("Cells/HealthyCell"));
        cell.GetComponent<CinemachineDollyCart>().m_Path = path;
    }
}
