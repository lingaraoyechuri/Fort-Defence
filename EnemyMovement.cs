using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject target;
    public Animator anmie1;
    public GameObject Explosionprefab;
    public GameObject Fireprefab;
    public AudioSource explosionSound;
    public int enemyAliveCount;
    public GameObject objUi;
    public bool  check1 =  true;

    
   // public enemyCount ec;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("end point");
        explosionSound = GetComponent<AudioSource>();
        // objUi = GameObject.FindGameObjectWithTag("End");
        // objUi.SetActive(false);
        enemyAliveCount = 180;
        
    }

    private void Update()
    {   
        // this will set the enemy destination as player position to move towards payer.
        Debug.Log("enemyAliveCount"+enemyAliveCount);
        if(enemyAliveCount==0){
            Debug.Log("game over");
            objUi.SetActive(true);
        }
        agent.SetDestination(target.transform.position);
        anmie1.SetBool("Walking", true);
        // Debug.Log("agent.transform.position.x"+ agent.transform.position.x);
        // Debug.Log("target.transform.position.x"+ target.transform.position.x);
        float dist = Vector3.Distance(agent.transform.position, target.transform.position);
   
            if(dist<3f)
            {

                Debug.Log("checking");
                int count = livesCount.SharedInstance.GetLivesCount();
                count = count-1;
                Destroy(this.gameObject);
                if (count > -1){

                    livesCount.SharedInstance.SetLivesCount(count);
                
                }
            
                //int count = enemyCount.SharedInstance.GetEnemyCount();

            }



    }

    void OnCollisionEnter(Collision collision)
    {   
        Debug.Log("fire"+ collision.gameObject.name);
        if (collision.gameObject.name == "Bullet(Clone)" || collision.gameObject.name == "Sphere")
        {     
               // int count = ec.GetEnemyCount();
               // ec.SetEnemyCount(count);
               

               // int count = enemyCount.SharedInstance.GetEnemyCount();
                //count = count-1;
                //if (count > -1){
                //  enemyCount.SharedInstance.SetEnemyCount(count);
                //}
                //Debug.Log("enemy count"+ count);

                // money code
                //int money = defenceToolBuilder.instance.getMoney();
                //money = money+5;
                //defenceToolBuilder.instance.setMoney(money);
                // money code end
                
                //Debug.Log("its working");
                //Destroy(gameObject);
               // GameObject Explosionobj = (GameObject)Instantiate(Explosionprefab, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                //Destroy(collision.gameObject);
               // enemyAliveCount = enemyAliveCount-1;
               // explosionSound.Play();
               // Destroy(Explosionobj, 1f);
                //GameObject Fireobj = (GameObject)Instantiate(Fireprefab, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                //Destroy(Fireobj, 1f);
                //enemyHealth = enemyHealth-1.0f;
                //TakeDamage(20);
                //int ch = eHealth.GetCurrentHealth();
                //Debug.Log("current h" +ch);

           
        }
 
    }
}
