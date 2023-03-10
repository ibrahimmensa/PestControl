using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject EnemyToInstantiate, Environment;
    public ParticleSystem Explosion;
    public float ExplosionDelay;
    public Vector3 ExplosionOffset;
    bool BombReady;
    // Start is called before the first frame update


    void Start()
    {
        Explosion.transform.SetParent(null);
        BombReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void launchGrenade1()
    {
        if (gameObject.GetComponent<SpriteRenderer>().enabled == false && BombReady)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            rb.simulated = true;
            rb.AddForce(Vector3.up * 380);
            rb.AddForce(Vector3.right * 390);
            StartCoroutine(TakeGrenadeBack(1.35f, new Vector3(2.5f,1.65f,0)));
        }
    }
    public void launchGrenade2()
    {
        if (gameObject.GetComponent<SpriteRenderer>().enabled == false && BombReady)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            rb.simulated = true;
            rb.AddForce(Vector3.up * 380);
            rb.AddForce(Vector3.right * 350);
            StartCoroutine(TakeGrenadeBack(1.5f, new Vector3(2.5f, 0.27f, 0)));
        }
    }
    public void launchGrenade3()
    {
        if (gameObject.GetComponent<SpriteRenderer>().enabled == false && BombReady)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            rb.simulated = true;
            rb.AddForce(Vector3.up * 380);
            rb.AddForce(Vector3.right * 310);
            StartCoroutine(TakeGrenadeBack(1.7f, new Vector3(2.5f, -1.17f, 0)));
        }
    }
    IEnumerator TakeGrenadeBack(float i,Vector3 pos)
    {
        BombReady = false;
        //Explosion.transform.SetParent(transform);
        yield return new WaitForSeconds(i);
        //Explosion.transform.SetParent(null);
        Explosion.transform.position = transform.position + ExplosionOffset;
        Explosion.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(ExplosionDelay);
        GameObject enemy = Instantiate(EnemyToInstantiate, Environment.transform);
        enemy.transform.localPosition = pos;
        rb.simulated = false;
        rb.velocity = Vector3.zero;
        transform.localPosition = Vector3.zero;
        BombReady = true;
    }
}
