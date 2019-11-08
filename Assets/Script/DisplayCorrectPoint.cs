using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCorrectPoint : MonoBehaviour
{
    [SerializeField] public GameObject point_1P, point_2P, winner;

    // Start is called before the first frame update
    void Start()
    {
        var text1=point_1P.GetComponent<Text>();
        text1.text=GameManager.point[0].ToString();
        var text2=point_2P.GetComponent<Text>();
        text2.text=GameManager.point[1].ToString();
        var text3=winner.GetComponent<Text>();
        if(GameManager.point[0]>GameManager.point[1]){
            text3.text="1P WIN";
        }else if(GameManager.point[0]<GameManager.point[1]){
            text3.text="2P WIN";
        }else{
            text3.text="DRAW";
        }
    }
}
