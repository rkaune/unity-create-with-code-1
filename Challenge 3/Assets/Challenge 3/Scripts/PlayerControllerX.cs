using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public static PlayerControllerX Instance { get; private set; }

    public bool gameOver = false;

    public float floatForce;
    private float gravityModifier = 1.5f;
    public Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    public bool isLowEnough = true;


    // Start is called before the first frame update
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);


    }

    // Update is called once per frame
    void Update()
    {
        // float the ball on the top bound
        if (playerRb.transform.position.y > 15.6f)
        {
            isLowEnough = false;
            gameObject.transform.position = new Vector3(-3,15.8f,0);
            playerRb.AddForce(Vector3.up * (-floatForce + -floatForce));
        }
        isLowEnough = true;

        // float the ball on the ground
        if (gameObject.transform.position.y < 1.2f)
        {
            playerRb.AddForce(Vector3.up * 0.3f, ForceMode.Impulse);
        }

        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && isLowEnough && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}
