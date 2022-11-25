using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    Collider playerCollider;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        playerCollider = GetComponent<Collider>();
        Debug.Log(playerCollider.GetType().ToString() == "CircleCollider2D");
    }
}
