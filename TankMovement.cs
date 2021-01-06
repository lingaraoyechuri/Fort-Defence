using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankMovement : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
   // GameObject target;
    Quaternion playerRot;
    Vector3 lookAtTarget;
    float rotSpeed = 5f;
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public Transform firePoint;
    private Transform target;
    public float range = 20f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // target = GameObject.Find("Tower");
        // Debug.Log("target" + target);
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    // we can use after
   void UpdateTarget()
    {
        Debug.Log("Checking new code");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Tower");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            Debug.Log("enemy" + enemy);
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null )
        {
            target = nearestEnemy.transform;
            //targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }

    }
    // we can use after
    // Update is called once per frame
    void Update()
    {
        Debug.Log("target" + target);
        agent.SetDestination(target.position);
        float dist = Vector3.Distance(agent.transform.position, target.position);
        Debug.Log("dist" + dist);
        if (dist < 25f)
        {
            Debug.Log("ready to kill canon");
            lookAtTarget = new Vector3(target.position.x - transform.position.x, 0,
                            target.position.z - transform.position.z);
            Debug.Log("lookAtTarget" + lookAtTarget);

            playerRot = Quaternion.LookRotation(lookAtTarget);
            Debug.Log("playerRot" + playerRot);
            transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, rotSpeed * Time.deltaTime);

            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }


    }


    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //canonSound.Play();
        bulletGO.GetComponent<Rigidbody>().velocity = transform.forward * 30;
        bulletGO.SetActive(true);
        Destroy(bulletGO, 3F);

    }
}
