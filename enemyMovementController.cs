using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementController : MonoBehaviour
{
    public Vector3 movementDirection;
    public float movementSpeed;
   // public float DirectionChangeTimer = 0;
    public int value=0;

    private Enemies controller;
    private ScoreManager scoreM;
    private CollectablesManager CM;
    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyController").GetComponent<Enemies>();
        scoreM = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        CM = GameObject.FindGameObjectWithTag("CollectablesManager").GetComponent<CollectablesManager>();

    }
    private void FixedUpdate()
    {
     
        this.transform.Translate(this.movementDirection * this.movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player Bullet")
        {
            Destroy(collision.gameObject);
            DestroyEnemy(this.value);
        }
        else if (collision.gameObject.tag == "OuterBoarder")
        {
            DestroyEnemy(0);
        }
        else if (collision.gameObject.tag == "Laser")
        {
            DestroyEnemy(this.value);
        }
        else if (collision.gameObject.tag == "Berserk")
        {
            DestroyEnemy(this.value);
        }

    }



    //private void ChangeDirection()
    //{
    //    DirectionChangeTimer = Random.Range(2, 6);
    //    movementDirection.x = Random.Range(-1f, 1f);
    //    movementDirection.y = Random.Range(-1f, 1f);

    //}
    public void DestroyEnemy(int val)
    {
        CM.CreateCollectable(this.transform.position);
        controller.currentEnemiesNumber--;
        scoreM.score += val;
        Destroy(this.gameObject);
    }
}
