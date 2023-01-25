using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Vector3 BulletStartPosition;
    public Rigidbody2D RB;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        BulletStartPosition = transform.position;
    }

    void OnTriggerEnter2D()
    {
        RB.velocity = Vector2.zero;
        transform.position = BulletStartPosition;
        this.gameObject.SetActive(false);
    }
}
