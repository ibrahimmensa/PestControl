using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject EnemyToInstantiate, Environment;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void launchGrenade1()
    {
        if (gameObject.GetComponent<SpriteRenderer>().enabled == false)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            rb.simulated = true;
            rb.AddForce(Vector3.up * 400);
            rb.AddForce(Vector3.right * 390);
            StartCoroutine(TakeGrenadeBack(1.45f, new Vector3(3.39f,1.65f,0)));
        }
    }
    public void launchGrenade2()
    {
        if (gameObject.GetComponent<SpriteRenderer>().enabled == false)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            rb.simulated = true;
            rb.AddForce(Vector3.up * 400);
            rb.AddForce(Vector3.right * 350);
            StartCoroutine(TakeGrenadeBack(1.6f, new Vector3(3.39f, 0.27f, 0)));
        }
    }
    public void launchGrenade3()
    {
        if (gameObject.GetComponent<SpriteRenderer>().enabled == false)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            rb.simulated = true;
            rb.AddForce(Vector3.up * 400);
            rb.AddForce(Vector3.right * 310);
            StartCoroutine(TakeGrenadeBack(1.8f, new Vector3(3.39f, -1.17f, 0)));
        }
    }
    IEnumerator TakeGrenadeBack(float i,Vector3 pos)
    {
        yield return new WaitForSeconds(i);
        GameObject enemy = Instantiate(EnemyToInstantiate, Environment.transform);
        enemy.transform.localPosition = pos;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        rb.simulated = false;
        rb.velocity = Vector3.zero;
        transform.localPosition = Vector3.zero;
    }
}
