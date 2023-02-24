using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGun : MonoBehaviour
{
    public GameObject Bullet;
    public int BulletsPerClip;
    public GameObject BulletSpawnPos;
    public float ReloadTime;
    public float FireRate;
    public float BulletSpeed;
    public int BulletDamage;

    bool ReadyToFire;
    bool Reloading;
    int BulletsInClip;

    List<GameObject> BulletPool = new();
    List<Rigidbody2D> BulletRigidBodyPool = new();
    public bool EnemiesAvailable;

    // Start is called before the first frame update
    void Start()
    {
        BulletsInClip = BulletsPerClip;
        for (int i = 0; i < BulletsPerClip; i++)
        {
            GameObject TempBullet = Instantiate(Bullet, BulletSpawnPos.transform.position, Quaternion.identity);
            TempBullet.tag = "AIBullet";
            TempBullet.GetComponent<BulletScript>().BulletDamage = BulletDamage;
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
        //Mouse Controls
        if (!Reloading && ReadyToFire && EnemiesAvailable)
        {
            //Play VFX
            //Play SFX
            BulletPool[BulletsInClip - 1].transform.position = BulletSpawnPos.transform.position;
            BulletPool[BulletsInClip - 1].transform.rotation = transform.rotation;
            BulletPool[BulletsInClip - 1].SetActive(true);
            BulletRigidBodyPool[BulletsInClip - 1].AddForce(-transform.right * BulletSpeed);
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
    }
    IEnumerator FireReady()
    {
        gameObject.GetComponentInParent<AIBehavior>().ShootAnimation();
        ReadyToFire = false;
        yield return new WaitForSeconds(FireRate);
        ReadyToFire = true;
    }
}
