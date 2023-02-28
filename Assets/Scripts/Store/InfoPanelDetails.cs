using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanelDetails : MonoBehaviour
{
    public string Name;
    public List<GameObject> UnlockButtons, OtherButtons;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString(Name) == "Bought")
        {
            if(OtherButtons.Count > 0)
            {
                for (int i = 0; i < OtherButtons.Count; i++)
                {
                    OtherButtons[i].SetActive(true);
                }
            }
            if (UnlockButtons.Count > 0)
            {
                for (int i = 0; i < UnlockButtons.Count; i++)
                {
                    UnlockButtons[i].SetActive(false);
                }
            }
        }
        else
        {
            if (OtherButtons.Count > 0)
            {
                for (int i = 0; i < OtherButtons.Count; i++)
                {
                    OtherButtons[i].SetActive(false);
                }
            }
            if (UnlockButtons.Count > 0)
            {
                for (int i = 0; i < UnlockButtons.Count; i++)
                {
                    UnlockButtons[i].SetActive(true);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
