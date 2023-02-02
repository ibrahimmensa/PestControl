using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
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
    public void launchGrenade()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        rb.simulated = true;
        rb.AddForce(Vector3.up * 400);
        rb.AddForce(Vector3.right * 400);
        StartCoroutine("TakeGrenadeBack");
    }
    IEnumerator TakeGrenadeBack()
    {
        yield return new WaitForSeconds(1.6f);
        GameObject enemy = Instantiate(EnemyToInstantiate, Environment.transform);
        enemy.transform.localPosition = new Vector3(4, 0.81f, 0);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        rb.simulated = false;
        rb.velocity = Vector3.zero;
        transform.localPosition = Vector3.zero;
    }
}
