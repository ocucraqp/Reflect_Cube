using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCorrectPoint : MonoBehaviour
{
    [SerializeField] public GameObject point_1P, point_2P;

    // Start is called before the first frame update
    void Start()
    {
        var text1=point_1P.GetComponent<Text>();
        text1.text=GameManager.point[0].ToString();
        var text2=point_2P.GetComponent<Text>();
        text2.text=GameManager.point[1].ToString();
    }
}
