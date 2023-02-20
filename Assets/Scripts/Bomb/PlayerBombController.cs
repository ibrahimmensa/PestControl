using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombController : MonoBehaviour
{
    bool Reloaded;
    public GameObject Bomb;
    public GameObject Buttons;
    int reloadTime;
    // Start is called before the first frame update
    void Start()
    {
        SetReloadTime();
        Reloaded = true;
        reloadTime = PlayerPrefs.GetInt(PlayerPrefs.GetString("SelectedBomb", "CuteButSavage"),8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnBomb(int i)
    {
        if (Reloaded)
        {
            switch (i)
            {
                case 1:
                    Bomb.GetComponent<PlayerBomb>().launchGrenade1();
                    StartCoroutine(ReloadTime());
                    break;
                case 2:
                    Bomb.GetComponent<PlayerBomb>().launchGrenade2();
                    StartCoroutine(ReloadTime());
                    break;
                case 3:
                    Bomb.GetComponent<PlayerBomb>().launchGrenade3();
                    StartCoroutine(ReloadTime());
                    break;
            }
        }
    }
    public void ShowButtons()
    {
        if(Reloaded)
        {
            Buttons.SetActive(true);
        }
    }
    IEnumerator ReloadTime()
    {
        Reloaded = false;
        yield return new WaitForSeconds(reloadTime);
        Reloaded = true;
    }
    public void SetReloadTime()
    {
        PlayerPrefs.SetInt("CuteButSavage", 8);
        PlayerPrefs.SetInt("RideOrDie", 12);
        PlayerPrefs.SetInt("SlenderBomb", 18);
        PlayerPrefs.SetInt("Stinker", 20);
        PlayerPrefs.SetInt("JokeOnYou", 22);
    }
}
