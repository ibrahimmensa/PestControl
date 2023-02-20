using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIBehavior : MonoBehaviour
{
    public GameObject ArmPivot;
    public int EnemyHealth;
    public Slider healthSlider;
    public List<GameObject> Guns, Grenade;
    List<GameObject> Enemies = new();
    GameObject CurrentTarget;
    int AILevel = 1;
    public float AimSpeed;
    GameObject Gun;
    public float Offset;

    // Start is called before the first frame update
    void Start()
    {
        switch (AILevel)
        {
            case 1:
                Guns[0].SetActive(true);
                Gun = Guns[0];
                break;

            case 2:
                //Do something here for AI level 2
                break;

            case 3:
                //Do something for AI level 3
                break;

            case 4:

                break;

            case 5:

                break;

            case 6:

                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentTarget)
        {
            Vector2 direction = CurrentTarget.transform.position - ArmPivot.transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(Vector3.forward * (angle + 180f));
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
        Guns[0].GetComponent<AIGun>().EnemiesAvailable = true;
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
}
