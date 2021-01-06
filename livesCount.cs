using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class livesCount : MonoBehaviour
{
    public static livesCount SharedInstance;
    public int currentlivesCount;
    public Text livesCountText;
    public GameObject gameover;
    public bool firtTime = true;

    private void Awake()
    {
        SharedInstance = this;
    }

    public void SetLivesCount(int livesCount)
	{
		
        currentlivesCount = livesCount;
        livesCountText.text = " " + currentlivesCount ;
        if(currentlivesCount < 1){
            gameover.SetActive(true);
        }
		
	}

    public int GetLivesCount()
    {
        if(currentlivesCount == 0 & firtTime == true){
            int MaxH = 10;
            firtTime = false;
            return MaxH;

        }
        else{
            return currentlivesCount;
        }
    }
}
