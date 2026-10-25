using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_T_Tower : MonoBehaviour
{
    public float FireSpeed = 15.0f;
    private float ReloadTimer = 0.0f;

    private int AmmoType = 1;


    [SerializeField] private GameObject AmmoPrefab;
    [SerializeField] private float projectileSpeed = 30f;
    [SerializeField] private GameObject currentTarget;


    // Start is called before the first frame update
    void Start()
    {
        AmmoPrefab = Resources.Load<GameObject>("Towers/Car-T Tower/Car-T ammo");
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    // Changes the ammo type to match the current Cancer Cell. 
    private void OnMouseDown()
    {
        switch (AmmoType)
        {
            case 1:
                Debug.Log("Ammo type 2 \"B\"");
                AmmoType = 2;
                break;

            case 2:
                Debug.Log("Ammo type 3 \"AB\"");
                AmmoType = 3;
                break;

            case 3:
                Debug.Log("Ammo type 3 \"A\"");
                AmmoType = 1;
                break;
        }

    }

    // Credit to Storms
    void TargetFinding(int targeting)
    {
        GameObject[] CarT_A = GameObject.FindGameObjectsWithTag("Car-T-A");
        GameObject[] CarT_B = GameObject.FindGameObjectsWithTag("Car-T-B");
        GameObject[] CarT_AB = GameObject.FindGameObjectsWithTag("Car-T-AB");


        float bestPosition = 0;
        switch (targeting)
        {
            case 1:
                Debug.Log("Targeting CarT_A");
                foreach (GameObject enemy in CarT_A)
                {
                    if (enemy.GetComponent<CinemachineDollyCart>() != null)
                    {
                        CinemachineDollyCart cart = enemy.GetComponent<CinemachineDollyCart>();

                        if (currentTarget == null)
                        {
                            currentTarget = enemy;
                        }
                        else if (cart.m_Position > bestPosition)
                        {
                            bestPosition = cart.m_Position;
                            currentTarget = enemy;
                        }

                        Debug.Log("Checking Enemy: " + currentTarget.name + "Distance: " + cart.m_Position);
                    }
                }
                break;

            case 2:
                Debug.Log("Targeting CarT_B");
                foreach (GameObject enemy in CarT_B)
                {
                    if (enemy.GetComponent<CinemachineDollyCart>() != null)
                    {
                        CinemachineDollyCart cart = enemy.GetComponent<CinemachineDollyCart>();

                        if (currentTarget == null)
                        {
                            currentTarget = enemy;
                        }
                        else if (cart.m_Position > bestPosition)
                        {
                            bestPosition = cart.m_Position;
                            currentTarget = enemy;
                        }

                        Debug.Log("Checking Enemy: " + currentTarget.name + "Distance: " + cart.m_Position);
                    }
                }
                break;

            case 3:
                Debug.Log("Targeting CarT_AB");
                foreach (GameObject enemy in CarT_AB)
                {
                    if (enemy.GetComponent<CinemachineDollyCart>() != null)
                    {
                        CinemachineDollyCart cart = enemy.GetComponent<CinemachineDollyCart>();

                        if (currentTarget == null)
                        {
                            currentTarget = enemy;
                        }
                        else if (cart.m_Position > bestPosition)
                        {
                            bestPosition = cart.m_Position;
                            currentTarget = enemy;
                        }

                        Debug.Log("Checking Enemy: " + currentTarget.name + "Distance: " + cart.m_Position);
                    }
                }
                break;
        }


    }

    void Fire()
    {
        if (currentTarget == null)
        {
            TargetFinding(AmmoType);
        }

        if (ReloadTimer <= 0)
        {
            if (currentTarget != null)
            {
                GameObject Ammo = Instantiate(AmmoPrefab, transform.position, Quaternion.identity);
                Ammo.GetComponent<Projectile>().SetTarget(currentTarget);
                Ammo.GetComponent<Projectile>().SetSpeed(projectileSpeed);
                ReloadTimer = FireSpeed;
            }
  
        }

        else
        {
            ReloadTimer -= Time.deltaTime;
        }

    }
}
