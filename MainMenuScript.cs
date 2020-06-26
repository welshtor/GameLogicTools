using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject CurrentScene;


    private void Start()
    {
        CurrentScene = GameObject.Find("MainMenu");    
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NextScene()
    {
        if(CurrentScene == GameObject.Find("MainMenu"))
        {
            CurrentScene.SetActive(false);

            GameObject.Find("Name Screen").SetActive(true);

            Debug.Log("Trying to Set the Name Screen Active");

            CurrentScene = GameObject.Find("Name Screen");
        }

        if(CurrentScene == GameObject.Find("Name Screen"))
        {
            CurrentScene.SetActive(false);

            GameObject.Find("Pit Customize Screen").SetActive(true);

            CurrentScene = GameObject.Find("Pit Customize Screen");
        }

        
    }

    public void PreviousScene()
    {

        if (CurrentScene == GameObject.Find("Pit Customize Screen"))
        {
            CurrentScene.SetActive(false);

            GameObject.Find("Name Screen").SetActive(true);

            CurrentScene = GameObject.Find("Name Screen");
        }

        if (CurrentScene == GameObject.Find("Urban Description") || CurrentScene == GameObject.Find("Rural Description")
            || CurrentScene == GameObject.Find("Suburban Description"))
        {
            CurrentScene.SetActive(false);

            GameObject.Find("Pit Customize Screen").SetActive(true);

            CurrentScene = GameObject.Find("Pit Customize Screen");
        }
    }

    public void OpenUrbanDescription()
    {
        CurrentScene.SetActive(false);

        GameObject.Find("Urban Description").SetActive(true);

        CurrentScene = GameObject.Find("Urban Description");
    }

    public void OpenRuralDescription()
    {
        CurrentScene.SetActive(false);

        GameObject.Find("Rural Description").SetActive(true);

        CurrentScene = GameObject.Find("Rural Description");
    }

    public void OpenSuburbanDescription()
    {
        CurrentScene.SetActive(false);

        GameObject.Find("Suburban Description").SetActive(true);

        CurrentScene = GameObject.Find("Suburban Description");
    }

}
