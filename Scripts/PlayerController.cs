using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables 

    //Physics
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;

    //Bools
    public bool gameOver;

    //Audio
    public AudioClip deathSound;
    public AudioClip swimSound;
    private AudioSource playerAudio;

    //Animation
    private Animator playerAnim;

    //Particles
    public ParticleSystem crashParticle;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver) 
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(swimSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            Debug.Log("Game Over");
            crashParticle.Play();
            playerAudio.PlayOneShot(deathSound, 1.0f);
        }
    }
}
