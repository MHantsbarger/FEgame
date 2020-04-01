using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public GameObject menu;
    public LoadScene sceneLoader;
    public Text pauseText;
    public Text resumeOption;
    // Start is called before the first frame update
    void Start()
    {
        // menu = GameObject.FindWithTag("Menu");
        // menu.menuIsPause = true;

        pauseText.text = "Pause";
        resumeOption.text = "Resume";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Trigger");
        if (collision.tag == "Player") {
            Debug.Log("Player Detected");
            pauseText.text = "You Win!";
            resumeOption.text = "Restart";
            resumeOption.tag = "RestartOption";
            // menu.menuIsPause = false;
            sceneLoader.ToggleMenu();
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {

    }
}
