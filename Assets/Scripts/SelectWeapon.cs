using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectWeapon : MonoBehaviour
{
    public List<GameObject> GrenadeButtons;
    public List<GameObject> ShieldButtons;
    public List<string> Grenades;
    public List<string> Shields;
    // Start is called before the first frame update
    void Start()
    {
        int g = 0;
        int s = 0;
        for (int i = Grenades.Count; i > 0 ; i--)
        {
            if (PlayerPrefs.GetString(Grenades[i-1]) == "Bought")
            {
                if(g < 3)
                {
                    GrenadeButtons[i-1].SetActive(true);
                    g++;
                }
            }
        }
        for (int i = Shields.Count; i > 0; i--)
        {
            if (PlayerPrefs.GetString(Shields[i - 1]) == "Bought")
            {
                if(s < 2)
                {
                    ShieldButtons[i-1].SetActive(true);
                    s++;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectGrenade(int i)
    {
        DisableSelectionG();
        PlayerPrefs.SetString("SelectedBomb", Grenades[i]);
        GrenadeButtons[i].transform.GetChild(0).transform.gameObject.SetActive(true);
    }
    public void SelectShield(int i)
    {
        DisableSelectionS();
        PlayerPrefs.SetString("SelectedBomb", Shields[i]);
        ShieldButtons[i].transform.GetChild(0).transform.gameObject.SetActive(true);
    }
    public void StartPlay()
    {
        SceneManager.LoadScene("TestScene");
    }
    public void DisableSelectionG()
    {
        for (int i = 0; i < GrenadeButtons.Count; i++)
        {
            GrenadeButtons[i].transform.GetChild(0).transform.gameObject.SetActive(false);
        }
    }
    public void DisableSelectionS()
    {
        for (int i = 0; i < ShieldButtons.Count; i++)
        {
            ShieldButtons[i].transform.GetChild(0).transform.gameObject.SetActive(false);
        }
    }
}
