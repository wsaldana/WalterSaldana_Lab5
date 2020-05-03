using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Pause : MonoBehaviour{

    public GameObject pauseMenu;
    public bool isPaused;
    public GameObject controller;
    public Canvas canvas;

    void Start(){
        isPaused = false;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape))
            togglePause();
        if (isPaused) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } else {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void togglePause() {
        if (pauseMenu) {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0f : 1f;
            if (controller) controller.GetComponent<FirstPersonController>().enabled = !controller.GetComponent<FirstPersonController>().enabled;
            canvas.enabled = !canvas.enabled;
        }
    }

    public void restartGame() {
        SceneManager.LoadScene(0);
        togglePause();
    }
}
