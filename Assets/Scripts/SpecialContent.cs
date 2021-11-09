using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialContent : Content
{
    ParticleSystem fireworksPs;
    float angularSpeed = 40f;
    private void Reset()
    {
        contentScore = 10;
    }
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }
    public override void CorrectSelection()
    {
        fireworksPs = GameObject.Find("Firework").GetComponent<ParticleSystem>();
        fireworksPs.Play();
        base.CorrectSelection();
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.back, angularSpeed * Time.deltaTime);
    }
}
