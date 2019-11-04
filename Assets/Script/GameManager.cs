using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const int player_count = 2;

    private int[] point = new int[player_count];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < player_count; i++)
        {
            point[i] = 0;
        }
    }

    public void point_counter()
    {

    }
}
