using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class Player_Controller : MonoBehaviour
{
    public int lifeCount = 3;
    public float horizontalInput;
    public float forceSpeed = 10;
    private float restartDelay = 1.5f;
    private bool faceRight;
    public GameObject firePoint;
    private Rigidbody2D playerRb;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    { 
        // player input
        if (Input.GetKey("right"))
        {
            // applying force for moving player (bad idea > going out of colliders... ajeeb)
            // playerRb.AddForce(Vector3.right * forceSpeed, ForceMode2D.Impulse);
            // moving player using it's transform component
            transform.Translate (Vector3.right * Time.deltaTime * forceSpeed);
            faceRight = true;
        }
        else if (Input.GetKey("left"))
        {
            // playerRb.AddForce(Vector3.left * forceSpeed, ForceMode2D.Impulse);
            transform.Translate (Vector3.left * Time.deltaTime * forceSpeed);
            faceRight = false;
        }

        // rotating player to face it towards the side its moving
        if(faceRight)
        {
            transform.localScale = new Vector2(6, 6);
            firePoint.transform.Rotate(0, 180 , 0);
        }
        if(!faceRight)
        {
            transform.localScale = new Vector2(-6, 6);
            firePoint.transform.Rotate(0, -180 , 0);
        }
        
            Debug.Log("LifeCount: " + lifeCount);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // reduce life on hit by balls
        if(col.gameObject.tag == "Big_Ball" || col.gameObject.tag == "Small_Balls" || col.gameObject.tag == "Smallest_Balls")
        {
            lifeCount -= 1;
            // Debug.Log("LifeCount: " + lifeCount);
            // Debug.Log("Kills: " + kills);
            if(lifeCount <= 0)
            {
                Debug.Log("GameOver");
                playerAudio.PlayOneShot(crashSound, 1.0f);
                explosionParticle.Play();
                Invoke("ReStart", restartDelay);
            }
        }
        if(col.gameObject.tag == "Life")
        {
            lifeCount += 1;
            Destroy(col.gameObject);
        }
    }

    void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
