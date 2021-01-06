using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelChangeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public GameObject loadslider;
    public Text loadingProgress;
    public GameObject musicButton;
    public bool music = true;
    public GameObject musicCross;
    public GameObject controlText;

    public void levelChange(string scene){

        Debug.Log("working scene");
        Application.LoadLevel(scene);

    }

    public void startGame(int sceneIndex){

        StartCoroutine(loadlevelAsync(sceneIndex));

    }

    IEnumerator loadlevelAsync(int levelIndex){

       AsyncOperation oper = SceneManager.LoadSceneAsync(levelIndex);

       while (oper.isDone == false)
       {
           loadslider.SetActive(true);
           float progress = Mathf.Clamp01(oper.progress / .9f);
           slider.value = progress;
           loadingProgress.text = progress * 100f +"%";
           yield return null;
       }
        
    }

    public void quitGame()
    {
        Debug.Log("working quit");
        Application.Quit();
    }


    public void enableMusicicon()
    {
        musicButton.SetActive(true);
    }

    public void musicOnOff()
    {
        if(music == true)
        {
            music = false;
            musicCross.SetActive(true);

        }
        else
        {
            music = true;
            musicCross.SetActive(false);
        }

    }

    public void ControlTextOn()
    {
        controlText.SetActive(true);
    }

    public void ControlTextoff()
    {
        controlText.SetActive(false);
    }


}
