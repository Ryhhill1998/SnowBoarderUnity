using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    
    AudioSource winAudio;

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    private void Start() 
    {
        winAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            // prevent player from moving after completing level
            FindObjectOfType<PlayerController>().DisableControls();
            // stop player from continuing to slide on course after completing level
            FindObjectOfType<PlayerController>().surfaceEffector2D.speed = 0;
            finishEffect.Play();
            winAudio.Play();
            Invoke("ReloadScene", delay);
        }
    }
}
