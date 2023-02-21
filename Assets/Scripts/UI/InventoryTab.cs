using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTab : MonoBehaviour
{
    public List<GameObject> InventoryButtons;
    public List<GameObject> InventoryInfo;
    // Start is called before the first frame update
    private void OnEnable()
    {
        OpenInfoPanel(0);
    }
    void Start()
    {
        OpenInfoPanel(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisbleInfo()
    {
        for (int i = 0; i < InventoryInfo.Count; i++)
        {
            InventoryInfo[i].SetActive(false);
        }
    }
    public void DisbleSelectedButton()
    {
        for (int i = 0; i < InventoryButtons.Count; i++)
        {
            InventoryButtons[i].GetComponent<InfoTabButton>().Deselected();
        }
    }
    public void OpenInfoPanel(int i)
    {
        DisbleInfo();
        DisbleSelectedButton();
        InventoryInfo[i].SetActive(true);
        InventoryButtons[i].GetComponent<InfoTabButton>().Selected();
    }
}
