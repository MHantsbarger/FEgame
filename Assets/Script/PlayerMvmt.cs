using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMvmt : MonoBehaviour
{
    public bool playerControlEnabled = true;
    public float moveSpeed = 6f;
    public bool isJumping = true;
    public bool isGrounded = false;
    public bool m_FacingRight;
    public float timeLeftPlatform;
    public float coyoteTime = .1f;
    public float jumpForce = 20f;
    public LoadScene sceneLoader;
    public Animator animator;
    Vector3 movement = new Vector3(0f, 0f, 0f);
    public float speed;

    void Update()
    {
        
        if (playerControlEnabled == true) {
            Jump();
            // if (isGrounded == true) {
                movement.Set(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));     
                animator.SetFloat("Vertical", speed);
            //  Debug.Log(speed);
            // }

            if (movement.x < 0)
            {
                m_FacingRight = false;
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else if (movement.x > 0)
            {
                m_FacingRight = true;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else {
            movement.Set(0f, 0f, 0f);
        }
        
    }

    void FixedUpdate() {
        if(playerControlEnabled == true) {
            transform.position += movement * Time.deltaTime * moveSpeed;
        }
        if (this.transform.position.y < -15) {
            Death();
        }
    }

    void Jump() {
        Vector3 veltest = gameObject.GetComponent<Rigidbody2D>().velocity;
        if(veltest.y == 0f && (veltest.x == 0f || isJumping==false)) {
            isGrounded = true;
            speed = 0;

        }
        if (Input.GetButtonDown("Jump") && (isGrounded == true || (isJumping == false && Time.time-timeLeftPlatform < coyoteTime))) {
            isJumping = true;
            isGrounded = false;
            Vector3 vel = gameObject.GetComponent<Rigidbody2D>().velocity;
            vel.y = 0f;
            gameObject.GetComponent<Rigidbody2D>().velocity = vel;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            speed = jumpForce;
        }

    }

    void Death() {
        sceneLoader.SceneLoader(sceneLoader.currentScene);
    }
}
