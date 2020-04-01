using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public bool menuIsPause = false;
    public GameObject menu;
    public GameObject player;
    public int currentScene;

    private void Start() {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void SceneLoader(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }

    public void doExitGame() {
        Application.Quit();
    }


    public void Update() { 
        if (Input.GetKeyDown(KeyCode.P) && menuIsPause) {
            ToggleMenu();
        }
    }

    public void ToggleMenu() {
        if (menu.GetComponent<MenuNav>().menuIsShown == false) {
            menu.SetActive(true);
            menu.GetComponent<MenuNav>().menuIsShown = true;
            menu.GetComponent<MenuNav>().controlEnabled = true;
            player.GetComponent<PlayerMvmt>().playerControlEnabled = false;
                    
        }
        else {
            menu.GetComponent<MenuNav>().menuIsShown = false;
            menu.GetComponent<MenuNav>().controlEnabled = false;
            menu.SetActive(false);
            player.GetComponent<PlayerMvmt>().playerControlEnabled = true;
        }
    }
}
