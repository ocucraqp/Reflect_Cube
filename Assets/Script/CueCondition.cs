using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueCondition : MonoBehaviour
{
    private GameObject refObj;

    void Start()
    {
        refObj = GameObject.Find("GameManager");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "WhiteBall")
        {
            GameManager gm = refObj.GetComponent<GameManager>();
            gm.SetFlagToChangePlayer();
        }
    }
}
