using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnterNextLevel : MonoBehaviour {

    public string SceneToLoad;
    public GameObject Menu;
    // Use this for initialization
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void CloseMenu()
    {
        Menu.SetActive(false);
    }
}
