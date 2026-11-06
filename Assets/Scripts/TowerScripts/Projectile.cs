using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private Vector3 targetDirection;
    private float speed = 50f;

    public void SetTarget(GameObject t)
    {
        targetDirection = (t.transform.position - transform.position).normalized;
    }

    public void SetSpeed(float s)
    {
        speed = s;
    }

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        if (targetDirection != null)
        {
            transform.position += targetDirection * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CancerCellA"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("CancerCellB"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("CancerCellC"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
