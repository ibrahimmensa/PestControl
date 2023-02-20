using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPanelController : MonoBehaviour
{
    public GameObject CoinsBtn, GemsBtn, CardsBtn, SpecialOffersBtn, InventoryBtn;
    // Start is called before the first frame update
    void Start()
    {
        CoinsBtn.GetComponent<StoreLeftPanelButton>().ActiveButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeactivateAll()
    {
        CoinsBtn.GetComponent<StoreLeftPanelButton>().DeactiveButton();
        GemsBtn.GetComponent<StoreLeftPanelButton>().DeactiveButton();
        CardsBtn.GetComponent<StoreLeftPanelButton>().DeactiveButton();
        SpecialOffersBtn.GetComponent<StoreLeftPanelButton>().DeactiveButton();
        InventoryBtn.GetComponent<StoreLeftPanelButton>().DeactiveButton();
    }
    public void ActivateCurrentButton(StoreLeftPanelButton refrence)
    {
        DeactivateAll();
        refrence.ActiveButton();
    }
}
