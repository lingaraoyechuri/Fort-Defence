using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TowerCOlider : MonoBehaviour
{
    public GameObject Explosionprefab;
    public GameObject Fireprefab;
    public GameObject smokeprefab;
    public AudioSource explosionSound;
    float enemyHealth;
    public Health eHealth;
   // public int currentHealth;


    //
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public int currentHealth;

    //
    // Start is called before the first frame update
    void Start()
    {
        explosionSound = GetComponent<AudioSource>();
        enemyHealth = 5.0f;
        slider.maxValue = 100;
        slider.value = 100;
        currentHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("inside defence slot");

        if (collision.gameObject.name == "TankBullet(Clone)")
        {
            Debug.Log("inside defence slot if condition");

            GameObject Explosionobj = (GameObject)Instantiate(Explosionprefab, collision.gameObject.transform.position, collision.gameObject.transform.rotation);

            /* Collider[] hitColliders = Physics.OverlapSphere(Explosionobj.transform.position, 4f);
             foreach (Collider hitCollider in hitColliders)
             {
                 Debug.Log("hitCollider.gameObject.name" + hitCollider.gameObject.name);

                 if (hitCollider.gameObject.name == "enemy(Clone)")
                 {
                     Debug.Log("hitCollider in side" + hitCollider);

                     Destroy(hitCollider.gameObject);
                     int count = enemyCount.SharedInstance.GetEnemyCount();
                     count = count - 1;
                     if (count > -1)
                     {
                         enemyCount.SharedInstance.SetEnemyCount(count);
                     }

                     int money = defenceToolBuilder.instance.getMoney();
                     money = money + 5;
                     defenceToolBuilder.instance.setMoney(money);
                 }

             }*/
             
            enemyHealth = enemyHealth - 1.0f;
            Debug.Log("test5");
            if (enemyHealth < 1)
            {
                Destroy(gameObject);
            }
            TakeDamage(20);
            // int ch = eHealth.GetCurrentHealth();
            Debug.Log("test4");
            GameObject Fireobj = (GameObject)Instantiate(Fireprefab, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(Fireobj, 2f);
            GameObject Smokeobj = (GameObject)Instantiate(smokeprefab, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(Smokeobj, 3f);
            explosionSound.Play();

            Destroy(Explosionobj, 1f);

        }
    }

     void TakeDamage(int damage)
    {
        Debug.Log("test1");
        
        currentHealth -= damage;
        if (enemyHealth > -1)
        {
            slider.value = currentHealth;
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }

}
