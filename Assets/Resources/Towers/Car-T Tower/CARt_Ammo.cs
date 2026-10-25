using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CARt_Ammo : MonoBehaviour
{
    private float Speed = 30.0f;
    [SerializeField] private Vector3 targetDirection;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += targetDirection * Speed * Time.deltaTime;

    }

    public void SetSpeed(float s)
    {
        Speed = s;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CancerCell"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}
