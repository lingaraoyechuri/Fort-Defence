using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roadcoliderScript : MonoBehaviour
{
    public GameObject Explosionprefab;
    public GameObject Fireprefab;
    public GameObject smokeprefab;
    public AudioSource explosionSound;
    // Start is called before the first frame update

    //tank health
    void Start()
    {
        explosionSound = GetComponent<AudioSource>();
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("inside defence slot");

        if (collision.gameObject.name == "Bullet(Clone)")
        {
            Debug.Log("inside defence slot if condition");

            GameObject Explosionobj = (GameObject)Instantiate(Explosionprefab, collision.gameObject.transform.position, collision.gameObject.transform.rotation);

            Collider[] hitColliders = Physics.OverlapSphere(Explosionobj.transform.position, 4f);
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



            }
            GameObject Fireobj = (GameObject)Instantiate(Fireprefab, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(Fireobj, 2f);
            GameObject Smokeobj = (GameObject)Instantiate(smokeprefab, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(Smokeobj, 3f);
            explosionSound.Play();

            Destroy(Explosionobj, 1f);

        }
    }



}
