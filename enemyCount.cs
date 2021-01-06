using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemyCount : MonoBehaviour
{
    // Start is called before the first frame update

    // public void SetMaxHealth(int health )
	// {

	// }
    public static enemyCount SharedInstance;
    public int currentHealth;
    public Text enemyCountText;
    public GameObject gameover;
    public bool firtTime = true;
    public int MaxH;
    Scene m_Scene;

    private void Awake()
    {
        SharedInstance = this;
    }

    public void SetEnemyCount(int health)
	{
		
        currentHealth = health;
        enemyCountText.text = "Enemys Left "+ currentHealth ;
        if(currentHealth < 10){
            gameover.SetActive(true);
        }
		
	}

    public int GetEnemyCount()
    {
        m_Scene = SceneManager.GetActiveScene();

        if (currentHealth == 0 & firtTime == true){
            
            if (m_Scene.name == "level1")
            {
                 MaxH = 249;
            }
            else if(m_Scene.name == "level2")
            {
                 MaxH = 400;
            }
            else if (m_Scene.name == "level3")
            {
                MaxH = 710;
            }

            firtTime = false;
            return MaxH;

        }
        else{
            return currentHealth;
        }
    }
}
