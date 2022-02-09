using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementController : MonoBehaviour
{
  
    public  float defualtSpeed;
    public float extraAccelerationSpeed;
    public float breakingFactor;
    public float defaultTurningSpeed;
    public float invincibilityTime;
    public bool isDead = false;
    public bool isActive = true;


    PowerUpControl powerUp;
    shootingController shooter;
    Animator anim;
    float temp;
    GameOver GO;
    private void Start()
    {
        powerUp = GameObject.FindGameObjectWithTag("PowerUpController").GetComponent<PowerUpControl>();
        shooter = GameObject.FindGameObjectWithTag("Player").GetComponent<shootingController>();
        GO = GameObject.FindGameObjectWithTag("GameOver").GetComponent<GameOver>();

        anim = this.GetComponent<Animator>();
        temp = invincibilityTime;
    }

    private void FixedUpdate()
    {
        Move();
        if (!isActive)
        {
            temp -= Time.deltaTime;
            if (temp <= 0)
            {
                temp = invincibilityTime;
                isActive = true;
            }
        }
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && isActive == true)
        {
            isActive = false;
           
            if (powerUp.UseShield())
            {
                anim.SetTrigger("Dead");
            }
            else
            {
                isDead = true;
                GO.ActivatePanel();
                Time.timeScale = 0;
                Destroy(this.gameObject);
            }
        }
        else if(collision.gameObject.tag == "Border")
        {
            isDead = true;
            GO.ActivatePanel();
            Time.timeScale = 0;
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "MultiShotItem")
        {
            powerUp.multiShot = true;
        }
        else if (collision.gameObject.tag == "LaserItem")
        {
            powerUp.laser = true;
        }
        else if (collision.gameObject.tag == "BerserkItem")
        {
            powerUp.berserk = true;
        }else if(collision.gameObject.tag == "Bomb")
        {
            powerUp.AddBomb();
        }
        else if (collision.gameObject.tag == "Shield")
        {
            powerUp.AddShield();
        }
        else if (collision.gameObject.tag == "Ammo")
        {
            shooter.ammoAmount += 20;
        }
    }

    private void Move()
    {
        float movementSpeed = defualtSpeed;

        // boost
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movementSpeed += extraAccelerationSpeed;
        }
        // slow down 
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movementSpeed *= breakingFactor;
        }

        this.transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);

        //turn left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(Vector3.forward, defaultTurningSpeed * Time.deltaTime);
        }
        // turn right
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(-Vector3.forward, defaultTurningSpeed * Time.deltaTime);
        }
    }
}
