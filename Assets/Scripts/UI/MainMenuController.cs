using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainMenu, StorePanel, SettingPanel, StartGamePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenStore()
    {
        DisableAllPanles();
        StorePanel.SetActive(true);
    }
    public void OpenSetting()
    {
        DisableAllPanles();
        SettingPanel.SetActive(true);
    }
    public void DisableAllPanles()
    {
        MainMenu.SetActive(false);
        StorePanel.SetActive(false);
        SettingPanel.SetActive(false);
        StartGamePanel.SetActive(false);
    }
    public void BackToMain()
    {
        DisableAllPanles();
        MainMenu.SetActive(true);
    }
}
