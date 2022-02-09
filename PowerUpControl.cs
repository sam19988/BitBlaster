using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerUpControl : MonoBehaviour
{
    [Header("General")]
    public GameObject[] shields;
    public GameObject[] bombs;
    public Animator anim;

    [Header("MultiShot Stuff")]
    public GameObject multiShotIcon;
    public bool multiShot = false;
    public float multiShotFrequency;
    public float multiShotTime;

    [Header("Laser Stuff")]
    public GameObject laserIcon;
    public GameObject laserPrefab;
    public bool laser = false;
    public float laserTime;

    [Header("Berserk Stuff")]
    public GameObject bersekIcon;
    public GameObject berserkPrefab;
    public bool berserk = false;
    public float berserkTime;


     bool activePanel= false;
    int bombsNum;
    int ShieldsNum;
    enemyMovementController[] enemies;
    shootingController player;
    float tempTimer;
    float tempShotTime;
    // Start is called before the first frame update
    void Start()
    {
        bombsNum =0;
        ShieldsNum = 2;
        tempTimer =0;
        tempShotTime = multiShotTime;
         player = GameObject.FindGameObjectWithTag("Player").GetComponent<shootingController>();
        UpdateBombs();
        UpdateShields();
    }

    // Update is called once per frame
    void Update()
    {
        ShowIcons();

        if (Input.GetKeyDown(KeyCode.P))
            ShowPanel();

        if (Input.GetKeyDown(KeyCode.X))
            UseBomb();

        if (Input.GetKey(KeyCode.M) && multiShot && tempShotTime > 0 )
        {
            tempShotTime -= Time.deltaTime;
            MultiShot();
            if (tempShotTime <= 0)
            {
                tempShotTime = multiShotTime;
                multiShot = false;
                player.canShotNoramlly = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.L) && laser)
        {
            StartCoroutine(UseLaser());
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(UseBerserk());
        }
    }

    private void ShowPanel()
    {
        activePanel = !activePanel;
        anim.SetBool("ShowPanel", activePanel);
    }

    private void UpdateBombs()
    {
        for(int i = 0; i < bombsNum; i++)
        {
            bombs[i].SetActive(true);
        }
        for(int i = bombs.Length-1; i >= bombsNum; i--)
        {
            bombs[i].SetActive(false);
        }
    }

    private void UpdateShields()
    {
        for (int i = 0; i < ShieldsNum; i++)
        {
            shields[i].SetActive(true);
        }
        for (int i = shields.Length - 1; i >= ShieldsNum; i--)
        {
            shields[i].SetActive(false);
        }
    } 

    private void UseBomb()
    {
        if (bombsNum > 0)
        {
            enemies = FindObjectsOfType<enemyMovementController>();
            foreach(enemyMovementController i in enemies)
            {
                i.DestroyEnemy(i.value);
            }
            bombsNum--;
            // bombs[bombsNum].SetActive(false);
            UpdateBombs();
        }
    }

    public void AddBomb()
    {
        if (bombsNum <= 4)
        {
            bombsNum++;
            //bombs[bombsNum-1].SetActive(true);
            UpdateBombs();
        }
            
    }

    public  bool UseShield()
    {
        if (ShieldsNum > 0)
        {
            ShieldsNum--;
            //  shields[ShieldsNum].SetActive(false);
            UpdateShields();
            Debug.Log("used shield");
            return true;
        }
        else
            return false;
    }

    public void AddShield()
    {
        if (ShieldsNum <= 4)
        {
            ShieldsNum++;
            UpdateShields();
            // shields[ShieldsNum-1].SetActive(true);
        }
    }

    public void MultiShot()
    {
        if (Time.time> tempTimer+ multiShotFrequency)
        {
            player.canShotNoramlly = false;
            tempTimer = Time.time;
            player.MultiShot();
        }
    }

    public IEnumerator UseLaser()
    {
        laserPrefab.SetActive(true);
        yield return new WaitForSeconds(laserTime);
        laserPrefab.SetActive(false);
        laser = false;
    }

    public IEnumerator UseBerserk()
    {
        berserkPrefab.SetActive(true);
        yield return new WaitForSeconds(berserkTime);
        berserkPrefab.SetActive(false);
        berserk = false;
    }
    private void ShowIcons()
    {
        multiShotIcon.SetActive(multiShot);
        laserIcon.SetActive(laser);
        bersekIcon.SetActive(berserk);
    }


}
