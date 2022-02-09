using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject[] spawnAreas;
    public GameObject[] enemiesToSpawn;
    public Transform enemiesHolder;
    public int currentEnemiesNumber = 0;
    public int maxEnemiesNumber = 0;

    // Update is called once per frame
    void Update()
    {
       

        if(currentEnemiesNumber<maxEnemiesNumber)
        {
            this.SpawnRandomEnemy();
        }
        
    }


    public void SpawnRandomEnemy()
    {
        int tempNum = Random.Range(0, enemiesToSpawn.Length);
        int tempArea= Random.Range(0, spawnAreas.Length);
        GameObject enemy = Instantiate(enemiesToSpawn[tempNum], getSpawnPosition(spawnAreas[tempArea]), Quaternion.identity);
        SetEnemyMovement(enemy, spawnAreas[tempArea]);
        enemy.transform.SetParent(enemiesHolder);
        currentEnemiesNumber++;
    }

    //public void setNewEnemey(CreateEnemy enemy , GameObject spawnArea= null)
    //{
    //    if(spawnArea==null)
    //    {
    //        int i = Random.Range(0, this.spawnAreas.Length);
    //        spawnArea = spawnAreas[i];
    //    }

    //    Vector3 spawnPosition = getSpawnPosition(spawnArea);

    //    enemy.transform.position = spawnPosition;
    //    enemy.transform.parent = this.transform;

    //    enemyMovementController EMC = enemy.MC;

    //    if (spawnArea.name == "Left")
    //    {
    //        EMC.movementDirection = Vector3.right;
    //    }
    //    else if (spawnArea.name == "Right")
    //    {
    //        EMC.movementDirection = Vector3.left;
    //    }
    //    else if (spawnArea.name == "Top")
    //    {
    //        EMC.movementDirection = Vector3.down;
    //    }
    //    else if (spawnArea.name == "Bottom")
    //    {
    //        EMC.movementDirection = Vector3.up;
    //    }
       
    //}

    Vector3 getSpawnPosition(GameObject spawnArea)
    {
        float x=0;
        float y=0;
        Vector3 scale = spawnArea.transform.localScale;
        if (spawnArea.name == "Left" || spawnArea.name == "Right")
        {
           x = spawnArea.transform.position.x + Random.Range(-scale.y/2, scale.y/2);
           y = spawnArea.transform.position.y + Random.Range(-scale.x/2, scale.x/2);
        }
        else if (spawnArea.name == "Top" || spawnArea.name == "Buttom")
        {
            x = spawnArea.transform.position.x + Random.Range(-scale.x / 2, scale.x / 2);
            y = spawnArea.transform.position.y + Random.Range(-scale.y / 2, scale.y / 2);
        }
      
        Vector3 location = new Vector3(x, y, 0);
        return location;

    }

    public void SetEnemyMovement(GameObject enemy, GameObject spawnPlace)
    {
        enemyMovementController controll = enemy.GetComponent<enemyMovementController>();
        if (controll)
        {
            if (spawnPlace.name == "Left")
            {
                controll.movementDirection = Vector3.right;
            }
            else if(spawnPlace.name == "Right")
            {
                controll.movementDirection = Vector3.left;

            }
            else if (spawnPlace.name == "Top")
            {
                controll.movementDirection = Vector3.down;

            }
            else if (spawnPlace.name == "Buttom")
            {
                controll.movementDirection = Vector3.up;

            }
        }
        else
        {
            return;
        }
    }
}
