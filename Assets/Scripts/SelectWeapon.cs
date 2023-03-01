using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
