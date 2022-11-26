using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashAudio;

    bool hasCrashed = false;

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
            // check if user has already crashed to prevent sound and particle effects playing multiple times
            if (hasCrashed) return;

            // prevent player from moving after crash
            FindObjectOfType<PlayerController>().DisableControls();
            // prevent player from sliding along course after crash
            FindObjectOfType<PlayerController>().surfaceEffector2D.speed = 0;
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashAudio);
            Invoke("ReloadScene", delay);
            hasCrashed = true;
        }
    }
}
