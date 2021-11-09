using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class SpecialContent : Content
{
    ParticleSystem fireworksPs;
    float angularSpeed = 40f;
    AudioSource audioSource;
    private void Reset()
    {
        contentScore = 10;
    }

    void Start()
    {
        
        Reset();
    }

    // POLYMORPHISM
    public override void CorrectSelection()
    {
        fireworksPs = GameObject.Find("Firework").GetComponent<ParticleSystem>();
        audioSource = fireworksPs.gameObject.GetComponent<AudioSource>();
        fireworksPs.Play();
        audioSource.Play();
        base.CorrectSelection();
    }

    void Update()
    {
        gameObject.transform.Rotate(Vector3.back, angularSpeed * Time.deltaTime);
    }
}
