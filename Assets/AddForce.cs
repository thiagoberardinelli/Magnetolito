using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public GameObject ball;
    public GameObject square;
    public float forceLenght;
    public Rigidbody2D ballRigidBody;

    void Start()
    {
        ballRigidBody = ball.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ballRigidBody.AddForce((square.transform.localPosition - ball.transform.localPosition) * forceLenght);
    }
}
