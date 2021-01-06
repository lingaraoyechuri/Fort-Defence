using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helpScript : MonoBehaviour
{
    public GameObject helpText;
    public bool help = true;
    public GameObject warning;
    public GameObject gameinfo;
    // Start is called before the first frame update
    public void helpTextOnOff()
    {   
        if(help == true)
        {
            helpText.SetActive(true);
            help = false;
        }
        else
        {
            helpText.SetActive(false);
            help = true;
        }
        
    }

    public void helpTextOff()
    {
        helpText.SetActive(false);
        help = true;
    }

    public void warningOff()
    {
        warning.SetActive(false);
    }

    public void StratInfoOff()
    {
        gameinfo.SetActive(false);
    }

}
