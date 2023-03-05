using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameWin()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GameLose()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
