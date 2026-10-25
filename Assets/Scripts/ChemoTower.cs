using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemoTower : MonoBehaviour
{
    [SerializeField] private float range = 5f;
    [SerializeField] private float fireRate = 1f;
    private float timeTillFire = 0f;
    [SerializeField] private LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        timeTillFire = fireRate;
    }

    void Update()
    {
        Attack();
    }

    // Update is called once per frame
    void Attack()
    {
        if (timeTillFire > 0)
        {
            timeTillFire -= Time.deltaTime;
        }
        else
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, range, layer);
            foreach (Collider hit in hits)
            {
                Destroy(hit.gameObject);
            }
            timeTillFire = fireRate;
        }
    }

    // gizmo for range (only in editor)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    
}
