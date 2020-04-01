using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "EndLevel") {
            Player.GetComponent<PlayerMvmt>().isGrounded = true;
            Player.GetComponent<PlayerMvmt>().isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "EndLevel") {
            Player.GetComponent<PlayerMvmt>().timeLeftPlatform = Time.time;
            Player.GetComponent<PlayerMvmt>().isGrounded = false;
        }
    }
}
