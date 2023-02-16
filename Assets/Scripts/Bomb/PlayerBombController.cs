using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombController : MonoBehaviour
{
    public GameObject Bomb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnBomb(int i)
    {
        switch(i)
        {
            case 1:
                Bomb.GetComponent<PlayerBomb>().launchGrenade1();
                break;
            case 2:
                Bomb.GetComponent<PlayerBomb>().launchGrenade2();
                break;
            case 3:
                Bomb.GetComponent<PlayerBomb>().launchGrenade3();
                break;
        }
    }
}
