using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndpointTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CellBase cell = other.GetComponent<CellBase>();

        if(cell != null)
        {
            cell.ChangeHealth();
            Destroy(cell.gameObject);
        }
    }
}
