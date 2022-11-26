using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueMagnitude = 1f;
    [SerializeField] float normalSpeed = 20;
    [SerializeField] float boostedSpeed = 50;

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            rb2d.AddTorque(torqueMagnitude);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueMagnitude);
        }
    }

    private void RespondToBoost() 
    {
        // speed up if user press up arrow key
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostedSpeed;
        }
        else
        {
            surfaceEffector2D.speed = normalSpeed;
        }
    }
}
