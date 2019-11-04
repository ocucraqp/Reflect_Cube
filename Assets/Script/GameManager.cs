using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const int player_count = 2;

    private int[] point = new int[player_count];
    private int current_player = 0;
    private float timeleft;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < player_count; i++)
        {
            point[i] = 0;
        }
    }

    void Update()
    {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0)
        {
            timeleft = 1.0f;

            Debug.Log(point[current_player]);
        }
    }

    public void point_count()
    {
        point[current_player]++;
    }
}
