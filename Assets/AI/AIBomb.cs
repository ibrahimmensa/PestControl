using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBomb : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject EnemyToInstantiate, Environment;
    int BombCoolDown;
    bool BombReady;
    public int BombDelayUpper;
    public int BombDelayLower;
    int BombDelay;
    // Start is called before the first frame update
    void Start()
    {
        BombCoolDown = PlayerPrefs.GetInt(gameObject.name, 8);
        BombReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (BombReady)
        {
            int Position = Random.Range(1, 4);
            switch(Position)
            {
                case 1:
                    launchGrenade1();
                    break;
                case 2:
                    launchGrenade2();
                    break;
                case 3:
                    launchGrenade3();
                    break;
            }
            BombDelay = Random.Range(BombDelayLower, BombDelayUpper);
            StartCoroutine(Cooldown());
        }
    }
    public void launchGrenade1()
    {
        if (gameObject.GetComponent<SpriteRenderer>().enabled == false)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            rb.simulated = true;
            rb.AddForce(Vector3.up * 400);
            rb.AddForce(Vector3.left * 390);
            StartCoroutine(TakeGrenadeBack(1.45f, new Vector3(-3.39f, 1.65f, 0)));
        }
    }
    public void launchGrenade2()
    {
        if (gameObject.GetComponent<SpriteRenderer>().enabled == false)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            rb.simulated = true;
            rb.AddForce(Vector3.up * 400);
            rb.AddForce(Vector3.left * 350);
            StartCoroutine(TakeGrenadeBack(1.6f, new Vector3(-3.39f, 0.27f, 0)));
        }
    }
    public void launchGrenade3()
    {
        if (gameObject.GetComponent<SpriteRenderer>().enabled == false)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            rb.simulated = true;
            rb.AddForce(Vector3.up * 400);
            rb.AddForce(Vector3.left * 310);
            StartCoroutine(TakeGrenadeBack(1.8f, new Vector3(-3.39f, -1.17f, 0)));
        }
    }
    IEnumerator TakeGrenadeBack(float i, Vector3 pos)
    {
        yield return new WaitForSeconds(i);
        GameObject enemy = Instantiate(EnemyToInstantiate, Environment.transform);
        enemy.transform.localPosition = pos;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        rb.simulated = false;
        rb.velocity = Vector3.zero;
        transform.localPosition = Vector3.zero;
    }
    IEnumerator Cooldown()
    {
        BombReady = false;
        yield return new WaitForSeconds(BombCoolDown + BombDelay);
        BombReady = true;
    }
}
