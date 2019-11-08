using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public const int PLAYER_COUNT = 2;
    public const int BALL_COUNT = 21;

    private int[] point = new int[PLAYER_COUNT];
    private int current_player = 0, flag_to_change_player = 0;
    private bool[] remaining_ball = new bool[21];
    [SerializeField] private GameObject BallParent;
    public GameObject[] Balls;
    public GameObject[] point_fields=new GameObject[PLAYER_COUNT];
    public GameObject text_current_player;

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
                var rectTransform=text_current_player.GetComponent<RectTransform>();
                if(current_player==0){
                    rectTransform.anchoredPosition3D=new Vector3(-680,310,0);
                }else{
                    rectTransform.anchoredPosition3D=new Vector3(300,310,0);
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
