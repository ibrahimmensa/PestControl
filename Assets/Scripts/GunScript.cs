using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject Bullet;
    public int BulletsPerClip;
    public Vector3 BulletSpawnPos;
    public float ReloadTime;
    public float FireRate;
    public float BulletSpeed;

    bool ReadyToFire;
    bool Reloading;
    int BulletsInClip;

    List<GameObject> BulletPool = new List<GameObject>();
    List<Rigidbody2D> BulletRigidBodyPool = new List<Rigidbody2D>();

    // Start is called before the first frame update
    void Start()
    {
        BulletsInClip = BulletsPerClip;
        for (int i = 0; i < BulletsPerClip; i++)
        {
            GameObject TempBullet = Instantiate(Bullet, BulletSpawnPos, Quaternion.identity);   
            BulletPool.Add(TempBullet);
            BulletRigidBodyPool.Add(TempBullet.GetComponent<Rigidbody2D>());
            TempBullet.SetActive(false);
        }
        ReadyToFire = true;
        Reloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (BulletsInClip == 0 && !Reloading)
        {
            StartCoroutine(Reload());
        }
        if (Input.GetMouseButton(0) && !Reloading && ReadyToFire)
        {
            //Play VFX
            //Play SFX
            BulletPool[BulletsInClip - 1].SetActive(true);
            BulletRigidBodyPool[BulletsInClip - 1].AddForce(transform.right * BulletSpeed);
            BulletsInClip--;
            //Set the direction of the bullet in the bullet script
            StartCoroutine(FireReady());
        }
    }

    IEnumerator Reload()
    {
        Reloading = true;
        yield return new WaitForSeconds(ReloadTime);
        BulletsInClip = BulletsPerClip;
        Reloading = false;
        foreach(Rigidbody2D RB in BulletRigidBodyPool)
        {
            RB.velocity = Vector2.zero;
        }
    }
    IEnumerator FireReady()
    {
        ReadyToFire = false;
        yield return new WaitForSeconds(FireRate);
        ReadyToFire = true;
    }
}
