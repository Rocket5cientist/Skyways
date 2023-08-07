using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
    private Controls controls;

    private void Awake() {
        controls = new Controls();
    }

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }

    public void PlayScene() {
        SceneManager.LoadScene("PlayScene");
        controls.WorldControls.Enable();
    }

    private void Update() {
        if (SceneManager.GetActiveScene().name == "StartScene") {

            controls.StartScreenControls.Enable();

            if (controls.StartScreenControls.AnyKey.triggered) {
                PlayScene();
            }
        }
    }

}
