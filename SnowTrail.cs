using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowEffect;

    CircleCollider2D playerHead;
    CapsuleCollider2D playerBoard;

    private void Start() 
    {
        playerHead = GetComponent<CircleCollider2D>();
        playerBoard = GetComponent<CapsuleCollider2D>();
    }

    private void OnCollisionStay2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ground" && playerBoard.IsTouching(other.collider)) 
        {
            snowEffect.Play();
        }
    }
}
