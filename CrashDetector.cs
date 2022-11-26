using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;

    CircleCollider2D playerHead;

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    private void Start() 
    {
        playerHead = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ground" && playerHead.IsTouching(other.collider)) 
        {
            crashEffect.Play();
            Invoke("ReloadScene", delay);
        }    
    }
}
