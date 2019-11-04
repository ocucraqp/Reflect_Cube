using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_HP : MonoBehaviour
{
    //public const int MAX_BALL = 20;

    //private int[] ball_hp = new int[MAX_BALL];
    //private GameObject[] ball = new GameObject[MAX_BALL];

    [SerializeField]
    private int ball_hp;

    private GameObject refObj;

    void Start()
    {
        refObj = GameObject.Find("GameManager");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wall1" || collision.gameObject.name == "Wall2"
            || collision.gameObject.name == "Wall3" || collision.gameObject.name == "Wall4"
            || collision.gameObject.name == "Wall5" || collision.gameObject.name == "Wall6)")
        {
            ball_hp--;
            if (ball_hp <= 0)
            {
                GameManager gm = refObj.GetComponent<GameManager>();
                gm.point_count();
                Destroy(this.gameObject);
            }
        }
    }
}
