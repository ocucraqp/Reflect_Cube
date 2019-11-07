using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const int PLAYER_COUNT = 2;
    public const int BALL_COUNT = 21;

    private int[] point = new int[PLAYER_COUNT];
    private int current_player = 0, flag_to_change_player = 0;
    [SerializeField] private GameObject BallParent;
    public GameObject[] Balls;
    private bool[] remaining_ball = new bool[21];

    public float timeOut = 1000f;
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < PLAYER_COUNT; i++)
        {
            point[i] = 0;
        }

        int num_ball = 0;
        Balls = new GameObject[BALL_COUNT];
        foreach (Transform childTransform in BallParent.transform)
        {
            Balls[num_ball] = childTransform.gameObject;
            Debug.Log(Balls[num_ball].name);
            num_ball++;
        }
        for (int i = 0; i < BALL_COUNT; i++)
        {
            remaining_ball[i] = true;
        }
    }

    void Update()
    {
        Invoke("ChangePlayer", 1);
    }

    public void ChangePlayer()
    {
        if (flag_to_change_player == 1)
        {
            if (ConfirmBallsVelocity() == 1)
            {
                if (current_player + 1 == PLAYER_COUNT)
                {
                    current_player = 0;
                }
                else
                {
                    current_player++;
                }
                Debug.Log("Player" + current_player.ToString());
                flag_to_change_player = 0;
            }
        }
    }

    public int ConfirmBallsVelocity()
    {
        for (int i = 0; i < BALL_COUNT; i++)
        {
            if (remaining_ball[i] == true)
            {
                Rigidbody rb = Balls[i].GetComponent<Rigidbody>();
                if (rb.velocity.magnitude > 0.1)
                {
                    return -1;
                }
            }
        }
        return 1;
    }

    public void FalseBall(int ball_no)
    {
        remaining_ball[ball_no] = false;
    }

    public void SetFlagToChangePlayer()
    {
        flag_to_change_player = 1;
    }

    public void PointCount(int ball_no)
    {
        point[current_player] += ball_no;
    }
}
