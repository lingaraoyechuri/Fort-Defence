using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastForwordScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SpeedButton;
    public GameObject normalButton;

    public void speedup()
    {
        normalButton.SetActive(true);
        SpeedButton.SetActive(false);
        Time.timeScale = 2f;
    }

    public void normalSpeed()
    {
        normalButton.SetActive(false);
        SpeedButton.SetActive(true);
        Time.timeScale = 1f;
    }

}
