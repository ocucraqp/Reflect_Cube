using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour {
    // Update is called once per frame
    public void OnClick () {
        if (SceneManager.GetActiveScene().name == "TitleScene") {
            SceneManager.LoadScene ("GameScene");
        } else if (SceneManager.GetActiveScene().name == "ResultScene") {
            SceneManager.LoadScene ("TitleScene");
        }
    }
}