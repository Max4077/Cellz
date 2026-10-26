using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class ImmunoTower : MonoBehaviour
{
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float projectileSpeed = 30f;
    private float timeTillFire = 0f;

    [SerializeField] private GameObject currentTarget;

    [SerializeField] private GameObject projectilePrefab;
    void Start()
    {
        timeTillFire = fireRate;
        projectilePrefab = Resources.Load<GameObject>("Towers/Immuno Tower/Immuno Projectile");
    }

    void Update()
    {
        ShootEnemy();
    }

    void TargetFinding()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("CancerCell");

        float bestPosition = 0;
        
        foreach (GameObject enemy in enemies)
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
    }

/// <summary>
///  if tower is on cooldown, it will decrease the time, if not it will shoot and reset the tower to be 
///  on cooldown
/// </summary>
    void ShootEnemy()
    {
        if (currentTarget == null)
        {
            TargetFinding();
        }
        
        if (timeTillFire > 0)
        {
            timeTillFire -= Time.deltaTime;
        }
        else
        {
            if (timeTillFire < 0)
            { 
                if (currentTarget != null)
                {
                    GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                    projectile.GetComponent<Projectile>().SetTarget(currentTarget);
                    projectile.GetComponent<Projectile>().SetSpeed(projectileSpeed);
                    timeTillFire = fireRate;
                }
            }
        }
    }
}

