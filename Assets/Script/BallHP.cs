using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHP : MonoBehaviour
{
    [SerializeField]
    private int ball_hp;
    private int ball_no;
    private GameObject refObj;
    [SerializeField]
    private ParticleSystem sparkParticle;

    void Start()
    {
        // if ball_no is 4 or 13, you must get minus point.
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
                if (ball_no == 4 || ball_no == 13)
                {
                    gm.PointCount(-ball_no);
                }
                else
                {
                    gm.PointCount(ball_no);
                }
                //Destroy(this.gameObject);
                Instantiate(sparkParticle, transform.position, transform.rotation);              
                this.gameObject.SetActive(false);
            }
        }
    }
}
