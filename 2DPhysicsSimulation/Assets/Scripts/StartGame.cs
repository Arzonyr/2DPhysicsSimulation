using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public GameObject MainMenuButtons;
    public GameObject LoadLevelMenuButtons;
    public GameObject Tutorial;
    public GameObject Credits;


     public void LoadLevel01()
    {
        SceneManager.LoadScene("Level01");
    }
    public void LoadLevel02()
    {
        SceneManager.LoadScene("Level02");
    }
    public void LoadLevel03()
    {
        SceneManager.LoadScene("Level03");
    }
    public void LoadLevel04()
    {
        SceneManager.LoadScene("Level04");
    }
    public void LoadLevel05()
    {
        SceneManager.LoadScene("Level05");
    }
    public void LoadLevel06()
    {
        SceneManager.LoadScene("Level06");
    }
    public void BackToMainMenu()
    {
        LoadLevelMenuButtons.SetActive(false);
        Tutorial.SetActive(false);
        Credits.SetActive(false);
        MainMenuButtons.SetActive(true);

    }
    public void EnterLoadLevelMenu()
    {
        
        MainMenuButtons.SetActive(false);
        LoadLevelMenuButtons.SetActive(true);

    }
    public void OpenTutorial()
    {
        MainMenuButtons.SetActive(false);
        Tutorial.SetActive(true);
    }
    public void OpenCredits()
    {
        MainMenuButtons.SetActive(false);
        Credits.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
