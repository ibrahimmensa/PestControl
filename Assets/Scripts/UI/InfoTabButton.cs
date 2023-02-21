using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTabButton : MonoBehaviour
{
    public GameObject SelectedSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Selected()
    {
        SelectedSprite.GetComponent<Image>().enabled = true;
    }
    public void Deselected()
    {
        SelectedSprite.GetComponent<Image>().enabled = false;
    }
}
