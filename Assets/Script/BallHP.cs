using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHP : MonoBehaviour
{
    [SerializeField]
    private int ball_hp;
    private int ball_no;
    private GameObject refObj;

    void Start()
    {
        ball_no = ball_hp;
        refObj = GameObject.Find("GameManager");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wall1" || collision.gameObject.name == "Wall2"
            || collision.gameObject.name == "Wall3" || collision.gameObject.name == "Wall4"
            || collision.gameObject.name == "Wall5" || collision.gameObject.name == "Wall6")
        {
            ball_hp--;
            if (ball_hp <= 0)
            {
                GameManager gm = refObj.GetComponent<GameManager>();
                gm.FalseBall(ball_no);
                gm.PointCount(ball_no);
                //Destroy(this.gameObject);
                this.gameObject.SetActive(false);
            }
        }
    }
}
