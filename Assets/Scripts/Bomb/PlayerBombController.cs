using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombController : MonoBehaviour
{
    bool Reloaded;
    public List<GameObject> Bomb;
    public GameObject Buttons;
    int reloadTime;
    int CurrentBombIndex;
    // Start is called before the first frame update
    void Start()
    {
        SetReloadTimeIndex();
        Reloaded = true;
        reloadTime = PlayerPrefs.GetInt(PlayerPrefs.GetString("SelectedBomb", "CuteButSavage") + "Time", 8);
        CurrentBombIndex = PlayerPrefs.GetInt(PlayerPrefs.GetString("SelectedBomb", "CuteButSavage") + "Index", 0);
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
                    Bomb[CurrentBombIndex].GetComponent<PlayerBomb>().launchGrenade1();
                    StartCoroutine(ReloadTime());
                    break;
                case 2:
                    Bomb[CurrentBombIndex].GetComponent<PlayerBomb>().launchGrenade2();
                    StartCoroutine(ReloadTime());
                    break;
                case 3:
                    Bomb[CurrentBombIndex].GetComponent<PlayerBomb>().launchGrenade3();
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
    public void SetReloadTimeIndex()
    {
        PlayerPrefs.SetInt("CuteButSavageTime", 8);
        PlayerPrefs.SetInt("RideOrDieTime", 12);
        PlayerPrefs.SetInt("SlenderBombTime", 18);
        PlayerPrefs.SetInt("StinkerTime", 20);
        PlayerPrefs.SetInt("JokeOnYouTime", 22);
        PlayerPrefs.SetInt("CuteButSavageIndex", 0);
        PlayerPrefs.SetInt("RideOrDieIndex", 1);
        PlayerPrefs.SetInt("SlenderBombIndex", 2);
        PlayerPrefs.SetInt("StinkerIndex", 3);
        PlayerPrefs.SetInt("JokeOnYouIndex", 4);
    }
}
