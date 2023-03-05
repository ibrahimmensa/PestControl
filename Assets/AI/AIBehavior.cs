using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIBehavior : MonoBehaviour
{
    public GameObject ArmPivot;
    public int Health;
    public Slider healthSlider;
    public List<GameObject> Guns, Bombs;
    List<GameObject> Enemies = new();
    GameObject CurrentTarget;
    public int AILevel;
    public float AimSpeed;
    GameObject Gun;
    public float Offset;
    float OffsetUpper;
    float OffsetLower;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject gun in Guns)
        {
            gun.SetActive(false);
        }
        foreach(GameObject Bomb in Bombs)
        {
            Bomb.SetActive(false);
        }
        AILevel = PlayerPrefs.GetInt("PlayerLevel", AILevel);
        switch (AILevel)
        {
            case 1:
                OffsetLower = 0;
                OffsetUpper = 0;
                Gun = Guns[0];
                foreach(GameObject Bomb in Bombs)
                {
                    Bomb.GetComponent<AIBomb>().BombDelayLower = 2;
                    Bomb.GetComponent<AIBomb>().BombDelayUpper = 5;
                }
                Bombs[0].SetActive(true);
                break;

            case 2:
                OffsetLower = 0;
                OffsetUpper = 0;
                Gun = Guns[1];
                foreach (GameObject Bomb in Bombs)
                {
                    Bomb.GetComponent<AIBomb>().BombDelayLower = 1;
                    Bomb.GetComponent<AIBomb>().BombDelayUpper = 5;
                }
                Bombs[1].SetActive(true);
                break;

            case 3:
                Gun = Guns[1];
                foreach (GameObject Bomb in Bombs)
                {
                    Bomb.GetComponent<AIBomb>().BombDelayLower = 1;
                    Bomb.GetComponent<AIBomb>().BombDelayUpper = 4;
                }
                Bombs[0].SetActive(true);
                Bombs[1].SetActive(true);
                break;

            case 4:
                Gun = Guns[2];
                foreach (GameObject Bomb in Bombs)
                {
                    Bomb.GetComponent<AIBomb>().BombDelayLower = 1;
                    Bomb.GetComponent<AIBomb>().BombDelayUpper = 4;
                }
                Bombs[2].SetActive(true);
                break;

            case 5:
                Gun = Guns[2];
                foreach (GameObject Bomb in Bombs)
                {
                    Bomb.GetComponent<AIBomb>().BombDelayLower = 1;
                    Bomb.GetComponent<AIBomb>().BombDelayUpper = 3;
                }
                Bombs[1].SetActive(true);
                Bombs[2].SetActive(true);
                break;

            case 6:
                Gun = Guns[3];
                foreach (GameObject Bomb in Bombs)
                {
                    Bomb.GetComponent<AIBomb>().BombDelayLower = 1;
                    Bomb.GetComponent<AIBomb>().BombDelayUpper = 2;
                }
                Bombs[1].SetActive(true);
                Bombs[2].SetActive(true);
                break;

            case 7:
                Gun = Guns[3];
                foreach (GameObject Bomb in Bombs)
                {
                    Bomb.GetComponent<AIBomb>().BombDelayLower = 0;
                    Bomb.GetComponent<AIBomb>().BombDelayUpper = 1;
                }
                Bombs[2].SetActive(true);
                Bombs[3].SetActive(true);
                break;

            case 8:
                Gun = Guns[4];
                foreach (GameObject Bomb in Bombs)
                {
                    Bomb.GetComponent<AIBomb>().BombDelayLower = 0;
                    Bomb.GetComponent<AIBomb>().BombDelayUpper = 0;
                }
                Bombs[2].SetActive(true);
                Bombs[3].SetActive(true);
                break;
        }
        Gun.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentTarget)
        {
            Offset = Random.Range(OffsetLower, OffsetUpper);
            Vector2 direction = CurrentTarget.transform.position - ArmPivot.transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(Vector3.forward * (angle + 180f + Offset));
            ArmPivot.transform.rotation = Quaternion.Slerp(ArmPivot.transform.rotation, rotation, AimSpeed * Time.deltaTime);
        }
    }

    public void AddEnemies(GameObject Enemy)
    {
        Enemies.Add(Enemy);
        if (Enemies.Count == 1)
        {
            CurrentTarget = Enemies[0];
        }
        Gun.GetComponent<AIGun>().EnemiesAvailable = true;
    }

    public void RemoveEnemies(GameObject Enemy)
    {
        Enemies.Remove(Enemy);
        Enemies.TrimExcess();
        CurrentTarget = null;
        if (Enemies.Count > 0)
        {
            for(int i = 0; i < Enemies.Count; i++)
            {
                if (CurrentTarget == null)
                {
                    CurrentTarget = Enemies[i];
                }
                else if(Vector2.Distance(transform.position, CurrentTarget.transform.position) > Vector2.Distance(transform.position, Enemies[i].transform.position))
                {
                    CurrentTarget = Enemies[i];
                }
            }
            Gun.GetComponent<AIGun>().EnemiesAvailable = true;
        }
        else
        {
            Gun.GetComponent<AIGun>().EnemiesAvailable = false;
        }
    }
    public void ShootAnimation()
    {
        StartCoroutine(ReturnAnimation());
    }
    IEnumerator ReturnAnimation()
    {
        ArmPivot.transform.localPosition = new Vector3(0.193f, 0.03f, 0);
        yield return new WaitForSeconds(0.05f);
        ArmPivot.transform.localPosition = new Vector3(0.173f, 0.03f, 0);
    }
    public void UpdateHealth()
    {
        if (Health >= 0)
        {
            healthSlider.value = Health;
        }
        else if(Health <= 0)
        {
            GameplayController.instance.GameWin();
        }
    }
}
