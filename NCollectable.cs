using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCollectable : MonoBehaviour
{
    public float liveTime = 0;

    float tempTimer;

    // Start is called before the first frame update
    void Start()
    {
        tempTimer = liveTime;
    }

    // Update is called once per frame
    void Update()
    {
        tempTimer -= Time.deltaTime;
        if (tempTimer <= 0)
        {
            tempTimer = liveTime;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Destroy(this.gameObject);
        }
    }
}
