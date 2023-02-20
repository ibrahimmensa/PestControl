using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreLeftPanelButton : MonoBehaviour
{
    public GameObject LeftBar, SelectedText, deselectedText, CorrespondingPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActiveButton()
    {
        LeftBar.SetActive(true);
        SelectedText.SetActive(true);
        deselectedText.SetActive(false);
        ActivateCorrespondingPanel();
    }
    public void DeactiveButton()
    {
        LeftBar.SetActive(false);
        SelectedText.SetActive(false);
        deselectedText.SetActive(true);
        DeactivateCorrespondingPanel();
    }
    public void ActivateCorrespondingPanel()
    {
        CorrespondingPanel.SetActive(true);
    }
    public void DeactivateCorrespondingPanel()
    {
        CorrespondingPanel.SetActive(false);
    }
}
