using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int BulletDamage;
    public Rigidbody2D RB;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D()
    {
        RB.velocity = Vector2.zero;
        this.gameObject.SetActive(false);
    }
}
