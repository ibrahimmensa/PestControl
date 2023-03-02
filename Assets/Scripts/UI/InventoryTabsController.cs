using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTabsController : MonoBehaviour
{
    public GameObject GunsButton, GrenadeButton, ShieldButton;
    public GameObject GunsButtonSelected, GrenadeButtonSelected, ShieldButtonSelected;
    public GameObject GunPanel, GrenadePanel, ShieldPanel;
    public List<GameObject> GunInfoPanels;
    public static InventoryTabsController instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        ActivateGuns();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeactivatePanels()
    {
        GunPanel.SetActive(false);
        GrenadePanel.SetActive(false);
        ShieldPanel.SetActive(false);
    }
    public void DeactivateButtons()
    {
        GunsButtonSelected.SetActive(false);
        GrenadeButtonSelected.SetActive(false);
        ShieldButtonSelected.SetActive(false);
        GunsButton.SetActive(true);
        GrenadeButton.SetActive(true);
        ShieldButton.SetActive(true);
    }
    public void ActivateGuns()
    {
        DeactivatePanels();
        DeactivateButtons();
        GunPanel.SetActive(true);
        GunsButtonSelected.SetActive(true);
        GunsButton.SetActive(false);
    }
    public void ActivateGrenades()
    {
        DeactivatePanels();
        DeactivateButtons();
        GrenadePanel.SetActive(true);
        GrenadeButtonSelected.SetActive(true);
        GrenadeButton.SetActive(false);
    }
    public void ActivateShields()
    {
        DeactivatePanels();
        DeactivateButtons();
        ShieldPanel.SetActive(true);
        ShieldButtonSelected.SetActive(true);
        ShieldButton.SetActive(false);
    }
    public void SetEquippedGun()
    {
        for (int i = 0; i < GunInfoPanels.Count; i++)
        {
            GunInfoPanels[i].GetComponent<InfoPanelDetails>().CheckSelection();
        }
    }
}
