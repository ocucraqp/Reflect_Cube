using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private Vector3 lastVelocity;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        this.rb.velocity *= 0.995f;
        this.lastVelocity = this.rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wall1" || collision.gameObject.name == "Wall2"
            || collision.gameObject.name == "Wall3" || collision.gameObject.name == "Wall4"
            || collision.gameObject.name == "Wall5" || collision.gameObject.name == "Wall6")
        {
            Vector3 refrectVec = Vector3.Reflect(this.lastVelocity, collision.contacts[0].normal);
            this.rb.velocity = refrectVec;
        }
    }
}
