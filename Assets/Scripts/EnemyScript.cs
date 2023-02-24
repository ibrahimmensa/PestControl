using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    GameObject Player;
    public float MoveSpeed;
    public Animator EnemyAnimator;
    public float AttackDistance;
    public int AttackDamage;
    public float EnemyHealth;
    public Image HealthBar;
    public float HealthBarMax;
    GameObject AI;

    GameObject[] AttackDots;
    GameObject Target;

    float EnemyResetHealth;
    PlayerController PlayerScript; //Rename this type to match the player script we will use.........................

    // Start is called before the first frame update
    void Start()
    {
        //HealthBarMax = HealthBar.rectTransform.rect.width;
        if(gameObject.tag == "EnemyPest")
        {
            //This will get all the player positions in an array
            AttackDots = GameObject.FindGameObjectsWithTag("PlayerPositions");
            Player = GameObject.FindGameObjectWithTag("Player");
            PlayerScript = Player.GetComponent<PlayerController>();
            //this for loop will find the closest point to the enemy's pest
            for(int i = 0; i < AttackDots.Length; i++)
            {
                if (Target == null)
                {
                    Target = AttackDots[i];
                }
                else if(Vector2.Distance(transform.position, Target.transform.position) > Vector2.Distance(transform.position, AttackDots[i].transform.position))
                {
                    Target = AttackDots[i];
                }
            }
        }
        else if(gameObject.tag == "PlayerPest")
        {
            //This gets all the enemy positions in an array
            AttackDots = GameObject.FindGameObjectsWithTag("EnemyPositions");
            Player = GameObject.FindGameObjectWithTag("PlayerEnemy");
            //this for loop will find the closest point to the player's pest
            for (int i = 0; i < AttackDots.Length; i++)
            {
                if (Target == null)
                {
                    Target = AttackDots[i];
                }
                else if (Vector2.Distance(transform.position, Target.transform.position) > Vector2.Distance(transform.position, AttackDots[i].transform.position))
                {
                    Target = AttackDots[i];
                }
            }
            if (GameObject.FindGameObjectWithTag("AI"))
            {
                AI = GameObject.FindGameObjectWithTag("AI");
                AI.GetComponent<AIBehavior>().AddEnemies(gameObject);
            }
        }
        EnemyResetHealth = EnemyHealth;
        //This is getting a reference to the player script.
         //Rename the component we are getting to match the player script we will use.........................
    }

    // Update is called once per frame
    void Update()
    {   //Checks if there is still distance between enemy and closest attack point.
        if (Vector2.Distance(transform.position, Target.transform.position) > AttackDistance)
        {
            //Moves the enemy to the closest attack point.
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, MoveSpeed * Time.deltaTime);
        }
        else
        {
            //Sets the animator bool to true to let the enemy start its attack animation.
            EnemyAnimator.SetBool("IsNearPlayer", true);
        }
        
        if (EnemyHealth <= 0)
        {
            //gameObject.SetActive(false);
            
            //EnemyHealth = EnemyResetHealth; //Resetting the enemy HP to full HP so it can be used again in a pool.
            //UpdateHealthBar();
            if (gameObject.tag == "PlayerPest")
            {
                AI.GetComponent<AIBehavior>().RemoveEnemies(gameObject);
            }
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PlayerBullet") && gameObject.CompareTag("EnemyPest"))
        {

                //Getting the damage amount from the bullet that hits the enemy.
                BulletScript bulletscript = col.gameObject.GetComponent<BulletScript>();
                EnemyHealth -= bulletscript.BulletDamage;
                UpdateHealthBar();
        }
        else if (col.gameObject.CompareTag("AIBullet") && gameObject.CompareTag("PlayerPest"))
        {
            BulletScript bulletscript = col.gameObject.GetComponent<BulletScript>();
            EnemyHealth -= bulletscript.BulletDamage;
            UpdateHealthBar();
        }
    }

    public void EnemyAttack()
    {
        //This is applying damage to the player through the player script reference.
        PlayerScript.PlayerHealth -= AttackDamage; //Rename the variable health to whatever the health vairable is in the player script we will use.........................
        PlayerScript.UpdateHealth();
    }

    void UpdateHealthBar()
    {
        HealthBar.fillAmount = EnemyHealth / EnemyResetHealth;
    }
}
