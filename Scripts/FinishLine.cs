using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    Vector3 startingPosition = new Vector3(-1.5f, 2.8f, 0);

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "FinishLine")
        {
            transform.position = startingPosition;
        }    
    }
}
