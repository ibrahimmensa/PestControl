using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyController : MonoBehaviour
{
    public EnemyBombController BombController;
    bool Bombed;
    // Start is called before the first frame update
    void Start()
    {
        Bombed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Bombed)
        {
            StartCoroutine("LaunchBomb");
        }
    }
    IEnumerator LaunchBomb()
    {
        Bombed = true;
        BombController.Bomb.GetComponent<EnemyBomb>().launchGrenade();
        yield return new WaitForSeconds(5);
        Bombed = false;
    }
}
