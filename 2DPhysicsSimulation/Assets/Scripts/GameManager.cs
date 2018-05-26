using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    
    
    public GameObject Shot;
    public GameObject NextLevelButton;
    public GameObject Menu;
    private bool LevelIsFinished = false;
    private bool MenuIsOpen = false;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Menu.SetActive(true);






        if (GameObject.FindGameObjectWithTag("Enemy") != null)
            return;

        if( LevelIsFinished==false)
        FinishLevel();

	}

    void FinishLevel()
    {
        
        LevelIsFinished = true;
        Destroy(Shot);
        NextLevelButton.SetActive(true);
            
       

    }
    
}
