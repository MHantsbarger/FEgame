using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    int count;
    static int deathCount;
    string level;

    
    private List<string> Movement = new List<string>();
    private List<string[]> outputList = new List<string[]>();

    string move;
    string countStr;
     public static string deathStr;
    string levelStr;

    public static string str0;
    public static string str1;
    public static string str2;
    public static string str3;
    public static string str4;
    public static string str5;
    public static string str6;
    public static string str7;
    public static string str8;
    public static string str9;

    Vector3 originalPos;
 

    void Start()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        originalPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        if (sceneName == "Level 1 NO")
        {
            level = "1N";
        }
        if (sceneName == "Level 1 YES")
        {
            level = "1Y";
        }
        if (sceneName == "Level 2 NO")
        {
            level = "2N";
        }
        if (sceneName == "Level 2 YES")
        {
            level = "2Y";
        }
        if (sceneName == "Level 3 NO")
        {
            level = "3N";
        }
        if (sceneName == "Level 3 YES")
        {
            level = "3Y";
        }
        if (sceneName == "Level 4 NO")
        {
            level = "4N";
        }
        if (sceneName == "Level 4 YES")
        {
            level = "4Y";
        }
        if (sceneName == "Level 5 NO")
        {
            level = "5N";
        }
        if (sceneName == "Level 5 YES")
        {
            level = "5Y";
        }

    }
    void Update()
    {
        KeyDown();
        Savecsv();
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
        deathCount++;
        deathStr = deathCount.ToString();
        // sceneLoader.SceneLoader(sceneLoader.currentScene);
        this.transform.position = originalPos;
    }

    void KeyDown()
    {
        
        
            if (Input.GetKeyDown(KeyCode.Space))
            {
            count++;
                Movement.Add("J");
            //    Debug.Log("Yes");
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
            count++;
                Movement.Add("A");

            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
            count++;
                Movement.Add("A");

            }
    
    }

    void Savecsv()
    {
        countStr = count.ToString();
        deathStr = deathCount.ToString();
        levelStr = level;
        move = string.Join("", Movement);

        for (int i = 0; i < 10; ++i)
        {
            string[] output = new string[4];

            output[0] = level;
            output[1] = move;
            output[2] = countStr;
            output[3] = deathStr;

            outputList.Add(output);
        }

        string[][] outputlist = new string[outputList.Count][];


        for (int i = 0; i < outputlist.Length; i++)
        {
            outputlist[i] = outputList[i];
            if (level == "1N")
            {
                str0 = string.Join(",", outputlist[i]);
            }
            if (level == "2N")
            {
                str2 = string.Join(",", outputlist[i]);
            }
            if (level == "3N")
            {
                str4 = string.Join(",", outputlist[i]);
            }
            if (level == "4N")
            {
                str6 = string.Join(",", outputlist[i]);
            }
            if (level == "5N")
            {
                str8 = string.Join(",", outputlist[i]);
            }
            if (level == "1Y")
            {
                str1 = string.Join(",", outputlist[i]);
            }
            if (level == "2Y")
            {
                str3 = string.Join(",", outputlist[i]);
            }
            if (level == "3Y")
            {
                str5 = string.Join(",", outputlist[i]);
            }
            if (level == "4Y")
            {
                str7 = string.Join(",", outputlist[i]);
            }
            if (level == "5Y")
            {
                str9 = string.Join(",", outputlist[i]);
            }

        }

    }
}

