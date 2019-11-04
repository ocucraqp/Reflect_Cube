using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_HP : MonoBehaviour
{
    public const int MAX_BALL = 20;

    private int[] ball_hp = new int[MAX_BALL];
    private GameObject[] ball = new GameObject[MAX_BALL];

    // Start is called before the first frame update
    void Start()
    {
        ball[0] = GameObject.Find("Ball11");
        for (int i = 0; i < MAX_BALL; i++)
        {
            ball_hp[i] = i + 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane" || collision.gameObject.name == "Plane (1)"
            || collision.gameObject.name == "Plane (2)" || collision.gameObject.name == "Plane (3)"
            || collision.gameObject.name == "Plane (4)" || collision.gameObject.name == "Plane (5)")
        {
            ball_hp[0]--;
            if (ball_hp[0] <= 0)
            {
                Destroy(ball[0].gameObject);
            }
        }
    }
}
