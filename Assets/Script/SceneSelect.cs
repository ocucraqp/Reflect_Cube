using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{
    // Update is called once per frame
    public void OnClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
