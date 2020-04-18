using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNav : MonoBehaviour
{
    static public bool conditionYES = false; 
    // public static string levelDifficulty = "Normal";
    public LoadScene sceneLoader;
    // public AudioClip menuNavSound;
    // public AudioClip menuSelectSound;
    // public AudioSource menuSounds;
    // [SerializeField] [Range(0, 1)] float volume = 1f;
    // [SerializeField] [Range(0, 1)] float selectVolume = 1f;
    // public Text difficultyText;

    public bool menuIsPause = false;
    public bool controlEnabled = true;
    public bool menuIsShown;
    private Color32 selectedColor = new Color32(0, 180, 0, 255);
    private Color32 unselectedColor = new Color32(255, 255, 255, 255);
    private Color32 clickedColor = new Color32(0, 255, 0, 255);
    // private Color32 easyColor = new Color32(0, 180, 0, 255);
    // private Color32 normalColor = new Color32(180, 180, 0, 255);
    // private Color32 hardColor = new Color32(180, 0, 0, 255);

    // public const int POINTERXPOS = 400;
    public Image pointer;

    public Text[] options;

    private int selectedOption;

    // Use this for initialization
    void Start () {
        selectedOption = 0;
        foreach (Text option in options) {
            option.color = unselectedColor;
        }
        options[0].color = selectedColor;
        // if (difficultyText != null)
        // {   
        //     if (levelDifficulty == "Easy") {
        //         difficultyText.text = "Easy";
        //         difficultyText.color = easyColor;
        //     }
        //     else if (levelDifficulty == "Hard") {
        //         difficultyText.text = "Hard";
        //         difficultyText.color = hardColor;
        //     }
        //     else {
        //         difficultyText.text = "Normal";
        //         difficultyText.color = normalColor;
        //     }
        // }
        pointer.transform.position = new Vector3(pointer.transform.position.x, options[0].transform.position.y);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.DownArrow) && controlEnabled == true && menuIsShown == true/*|| Controller input*/)
        { //Input telling it to go up or down.
            selectedOption += 1;
            if (selectedOption >= options.Length) //If at end of list go back to top
            {
                selectedOption = 0;
            }

            foreach (Text option in options) {
                option.color = unselectedColor;
            }
            options[selectedOption].color = selectedColor;
            pointer.transform.position = new Vector3(pointer.transform.position.x, options[selectedOption].transform.position.y);
            // menuSounds.PlayOneShot(menuNavSound, volume);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && controlEnabled == true && menuIsShown == true /*|| Controller input*/)
        { //Input telling it to go up or down.
            selectedOption -= 1;
            if (selectedOption < 0) //If at end of list go back to top
            {
                selectedOption = options.Length-1;
            }

            foreach (Text option in options) {
                option.color = unselectedColor;
            }
            options[selectedOption].color = selectedColor;
            pointer.transform.position = new Vector3(pointer.transform.position.x, options[selectedOption].transform.position.y);
            // menuSounds.PlayOneShot(menuNavSound, volume);
        }

        if (controlEnabled == true && menuIsShown == true && (Input.GetKeyDown(KeyCode.Space) ||  Input.GetKeyDown("joystick button 0"))){
            controlEnabled = false;
            // Debug.Log("Picked: " + selectedOption); //For testing as the switch statment does nothing right now.
            // menuSounds.PlayOneShot(menuSelectSound, selectVolume);
            options[selectedOption].color = clickedColor;
            StartCoroutine(MenuOptionSceneChange());
            
        }

        if (Input.GetKeyDown(KeyCode.O) && menuIsPause == false) {
            if (conditionYES == false) {
                print("condition to= "+ conditionYES);
                conditionYES = true;
                // GameObject[] level1 = GameObject.FindGameObjectsWithTag("Level1YES");
                // GameObject[] level2 = GameObject.FindGameObjectsWithTag("Level2YES");
                // foreach (GameObject level in level1) {
                //     level.tag = "Level1NO";
                // }
                // foreach (GameObject level in level2) {
                //     level.tag = "Level2NO";
                // }
            }
            else {
                print("condition to= "+ conditionYES);
                conditionYES = false;
                // GameObject[] level1 = GameObject.FindGameObjectsWithTag("Level1NO");
                // GameObject[] level2 = GameObject.FindGameObjectsWithTag("Level2NO");
                // foreach (GameObject level in level1) {
                //     level.tag = "Level1YES";
                // }
                // foreach (GameObject level in level2) {
                //     level.tag = "Level2YES";
                // }
            }
        }

    }
    IEnumerator MenuOptionSceneChange() {
            yield return new WaitForSeconds(0.3f);
            if (options[selectedOption].tag == "MenuOption") {
                sceneLoader.SceneLoader(0);
            }
            if (options[selectedOption].tag == "Level1NO") {
                if (conditionYES == false) {
                    sceneLoader.SceneLoader(1);
                }
                else {
                    sceneLoader.SceneLoader(2);
                }
            }
            // if (options[selectedOption].tag == "Level1YES") {
            //     sceneLoader.SceneLoader(2);
            // }
            if (options[selectedOption].tag == "Level2NO") {
                if (conditionYES == false) {
                    sceneLoader.SceneLoader(3);
                }
                else {
                    sceneLoader.SceneLoader(4);
                }
            }
            if (options[selectedOption].tag == "Level3NO") {
                if (conditionYES == false) {
                    sceneLoader.SceneLoader(5);
                }
                else {
                    sceneLoader.SceneLoader(6);
                }
            }
            if (options[selectedOption].tag == "Level4NO") {
                if (conditionYES == false) {
                    sceneLoader.SceneLoader(7);
                }
                else {
                    sceneLoader.SceneLoader(8);
                }
            }
            if (options[selectedOption].tag == "Level5NO") {
                if (conditionYES == false) {
                    sceneLoader.SceneLoader(9);
                }
                else {
                    sceneLoader.SceneLoader(10);
                }
            }
            // if (options[selectedOption].tag == "Level2YES") {
            //     sceneLoader.SceneLoader(4);
            // }
            else if (options[selectedOption].tag == "QuitOption") {
                sceneLoader.doExitGame();
            }
            else if (options[selectedOption].tag == "ResumeOption") {
                sceneLoader.ToggleMenu();
                // gameObject.SetActive(false);
            }
            else if (options[selectedOption].tag == "RestartOption") {
                sceneLoader.SceneLoader(sceneLoader.currentScene);
            }
            
            // if (options[selectedOption].tag == "StartOption") {
            //     sceneLoader.SceneLoader(6);
            // }
            // else if (options[selectedOption].tag == "MainMenuOption") {
            //     sceneLoader.SceneLoader(0);
            // }
            // else if (options[selectedOption].tag == "PlayerMvmtOption") {
            //     sceneLoader.SceneLoader(1);
            // }
            // else if (options[selectedOption].tag == "HomeGoalOption") {
            //     sceneLoader.SceneLoader(2);
            // }
            // else if (options[selectedOption].tag == "AvoidHazardsOption") {
            //     sceneLoader.SceneLoader(3);
            // }
            // else if (options[selectedOption].tag == "HazardsNearOption") {
            //     sceneLoader.SceneLoader(4);
            // }
            // else if (options[selectedOption].tag == "CandleOption") {
            //     sceneLoader.SceneLoader(5);
            // }
            // else if (options[selectedOption].tag == "QuitOption") {
            //     sceneLoader.doExitGame();
            // }
            // else if (options[selectedOption].tag == "SettingsOption") {
            //     sceneLoader.SceneLoader(7);
            // }
            // else if (options[selectedOption].tag == "CreditsOption") {
            //     sceneLoader.SceneLoader(8);
            // }
            // else if (options[selectedOption].tag == "EasyDifficulty") {
            //     difficultyText.text = "Easy";
            //     difficultyText.color = easyColor;
            //     levelDifficulty = "Easy";
            // }
            // else if (options[selectedOption].tag == "MediumDifficulty") {
            //     difficultyText.text = "Normal";
            //     difficultyText.color = normalColor;
            //     levelDifficulty = "Medium";
            // }
            // else if (options[selectedOption].tag == "HardDifficulty") {
            //     difficultyText.text = "Hard";
            //     difficultyText.color = hardColor;
            //     levelDifficulty = "Hard";
            // }
            controlEnabled = true;
            options[selectedOption].color = selectedColor;
        }
}
