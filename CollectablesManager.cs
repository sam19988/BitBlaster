using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesManager : MonoBehaviour
{
    public GameObject[] collectablesPrefabs;
    public Transform parentHolder;
    // 0 for bomb , 1 for a shield, 2 for laser, 3 for multishot, 4 for berserk, 5 for ammo

  public void CreateCollectable(Vector2 positionToSpawn)
    {
        int percent = Random.Range(0, 100);
        if(percent < 5)  // create a bomb
        {
            GameObject obj = Instantiate(collectablesPrefabs[0], positionToSpawn, Quaternion.identity);
            obj.transform.SetParent(parentHolder);
        }
        else if (percent >= 5 && percent <20)  // create a shield
        {
            GameObject obj = Instantiate(collectablesPrefabs[1], positionToSpawn, Quaternion.identity);
            obj.transform.SetParent(parentHolder);
        }
        else if (percent >= 20 && percent <40)   // create a Laser
        {
            GameObject obj = Instantiate(collectablesPrefabs[2], positionToSpawn, Quaternion.identity);
            obj.transform.SetParent(parentHolder);
        }
        else if (percent >= 40 && percent <50)  // create a multishot
        {
            GameObject obj = Instantiate(collectablesPrefabs[3], positionToSpawn, Quaternion.identity);
            obj.transform.SetParent(parentHolder);
        }
        else if (percent >= 50 && percent <55)  // create a berserk
        {
            GameObject obj = Instantiate(collectablesPrefabs[4], positionToSpawn, Quaternion.identity);
            obj.transform.SetParent(parentHolder);
        }
        else if (percent >= 55&& percent <85) // create a ammo
        {
            GameObject obj = Instantiate(collectablesPrefabs[5], positionToSpawn, Quaternion.identity);
            obj.transform.SetParent(parentHolder);
        }
        else if (percent >= 85 && percent<100)  // do nothing
        {
            return;
        }
        
    }
}
