using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //Sonidos
    public AudioClip jumpSound;
    public AudioSource audioSource;

    public bool pausado;
    public GameObject UI_Pausa;

	public SpriteRenderer spriteRenderer; // Flip
    public Animator animator; // Animations
    public Rigidbody2D rb; // Move

    [Range(1,10)]
    public float moveSpeed = 5;
    [Range(1,10)]
    public float jumpForce = 5;

    // Jump
    public GameObject groundDetector; // En los pies
    private bool isGrounded = false;
    public LayerMask layerMask; // Floor

    void Update()
    {
        //Pausando el juego
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                pausado = true;
                UI_Pausa.SetActive(true);
                Time.timeScale = 0;
                
            }
            else
            {
                pausado = false;
                UI_Pausa.SetActive(false);
                Time.timeScale = 1;
                
            }
        }
    }
    void FixedUpdate () { // Exacto
        // -1 <- 0 -> 1
        float horizontal = Input.GetAxisRaw("Horizontal"); // R -1, 0 y 1 
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        //                   < Dir                     > <Vel> <FIX>
        //transform.position += Vector3.right * horizontal * 5 * Time.deltaTime;

        if (horizontal == 0) { // No move
            animator.SetBool("isRunning", false); // Idle

        } else { // Move
            animator.SetBool("isRunning", true); // Run

            // Flip
            if (horizontal > 0) {
                spriteRenderer.flipX = false;
            }
            if (horizontal < 0) {
                spriteRenderer.flipX = true;
            }
        }

        // Collision con layer del piso
        isGrounded = Physics2D.OverlapCircle(groundDetector.transform.position, 0.1f, layerMask);
        animator.SetBool("isJumping", !isGrounded);

        if(isGrounded) {
            if (Input.GetButtonDown("Jump")) { // PC: Space
                rb.velocity += Vector2.up * jumpForce; // Add Force Upç
                audioSource.clip = jumpSound;
                audioSource.Play();
            }
        }


         
    }
}
