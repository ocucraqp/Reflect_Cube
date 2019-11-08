using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueCondition : MonoBehaviour
{
    private GameObject refObj, handObj;
    private Transform ht, ct;

    void Start()
    {
        refObj = GameObject.Find("GameManager");
        handObj = GameObject.Find("CustomHandRight");
        ht = handObj.GetComponent<Transform>();
        ct = this.GetComponent<Transform>();
    }

 //   private void Update()
 //   {
 //       ct.position = ht.position;
 //       ct.rotation = ht.rotation;
 //   }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "WhiteBall")
        {
            GameManager gm = refObj.GetComponent<GameManager>();
            gm.SetFlagToChangePlayer();
        }
    }
}
