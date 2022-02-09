using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class shootingController : MonoBehaviour
{
    public float shootingFrequency;
    public float bulletSpeed;
    public int ammoAmount;
    float nextShoot = 0;
    public Text ammoText;

    public GameObject playerBulletPrefab;
    public GameObject bulletsHolder;
    public Transform[] spawnPoints;
    public bool canShotNoramlly = true;
    private void Start()
    {
       ammoText.text = "Ammo : " + ammoAmount.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > this.nextShoot&& ammoAmount>0 && canShotNoramlly)
            Shoot();
    }

    private void FixedUpdate()
    {
        ammoText.text = "Ammo : " + ammoAmount.ToString();

    }

    void Shoot()
    {
        this.nextShoot = Time.time + this.shootingFrequency;

        GameObject newBullet = GameObject.Instantiate(this.playerBulletPrefab);
        newBullet.transform.position = this.spawnPoints[1].position;
        newBullet.transform.parent = this.bulletsHolder.transform;

        Rigidbody2D newBulletRB = newBullet.GetComponent<Rigidbody2D>();
        newBulletRB.AddForce(this.transform.up * bulletSpeed);

        this.ammoAmount--;
    }

    public void MultiShot()
    {
        for(int i=0; i<spawnPoints.Length;i++)
        {
            GameObject newBullet = GameObject.Instantiate(this.playerBulletPrefab,spawnPoints[i].position,spawnPoints[i].rotation);
            //newBullet.transform.position = this.spawnPoints[i].position;
            newBullet.transform.parent = this.bulletsHolder.transform;

            Rigidbody2D newBulletRB = newBullet.GetComponent<Rigidbody2D>();
            newBulletRB.AddForce(spawnPoints[i].transform.up * bulletSpeed);
        }
    }
}
