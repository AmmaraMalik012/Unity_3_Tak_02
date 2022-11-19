using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 20f;
    public int kills = 0;
    public Rigidbody2D rb;
    public GameObject Balls;
    public GameObject smallBalls;
    public GameObject smallestBalls;
    public GameObject spawnBalls;
    public GameObject spawnsmallestBalls;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        // not updating most probably bcz the bullet is different every time and it also destroys at collision 
        Debug.Log("Kills: " + kills);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Big_Ball")
        {
            // Destroy(other.gameObject);
            Vector3 spawnPos = new Vector3(Balls.transform.position.x, Balls.transform.position.y, 0);
            Instantiate(smallBalls, spawnPos, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Small_Balls")
        {
            Destroy(other.gameObject);
            Instantiate(smallestBalls);
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Smallest_Balls")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
