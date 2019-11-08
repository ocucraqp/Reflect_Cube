using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public const int PLAYER_COUNT = 2;
    public const int BALL_COUNT = 21;

    public static int[] point = new int[PLAYER_COUNT];
    private int current_player = 0, flag_to_change_player = 0;
    private bool[] remaining_ball = new bool[21];
    [SerializeField] private GameObject BallParent;
    public GameObject[] Balls;
    public GameObject[] point_fields=new GameObject[PLAYER_COUNT];
    public GameObject Text_1P;
    public GameObject Text_2P;
    public GameObject Text_1P_Point;
    public GameObject Text_2P_Point;

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
                Text text_p1 = Text_1P.GetComponent<Text>();
                Text text_p2 = Text_2P.GetComponent<Text>();
                Text text_p1_point = Text_1P_Point.GetComponent<Text>();
                Text text_p2_point = Text_2P_Point.GetComponent<Text>();
                Color color_p1 = new Color(0f / 255f, 191f / 255f, 255f / 255f);
                Color color_p2 = new Color(255f / 255f, 32f / 255f, 54f / 255f);
                Color color_gray = new Color(118f / 255f, 118f / 255f, 118f / 255f);
                if (current_player==0){
                    text_p1.color = color_p1;
                    text_p1_point.color = color_p1;
                    text_p2.color = color_gray;
                    text_p2_point.color = color_gray;
                }else{
                    text_p1.color = color_gray;
                    text_p1_point.color = color_gray;
                    text_p2.color = color_p2;
                    text_p2_point.color = color_p2;
                }
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
        for(int i=1;i<BALL_COUNT;i++){
            if(remaining_ball[i]==true){
                return;
            }
        }
        SceneManager.LoadScene("ResultScene");
    }

    public void SetFlagToChangePlayer()
    {
        flag_to_change_player = 1;
    }

    public void PointCount(int ball_no)
    {
        Text target_text;

        point[current_player] += ball_no;
        
        target_text=point_fields[current_player].GetComponent<Text>();
        target_text.text=point[current_player].ToString();
    }
}
