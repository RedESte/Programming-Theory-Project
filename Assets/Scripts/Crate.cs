using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionPs;
    GameObject crateContent;
    Renderer objRenderer;

    public GameObject CrateContent { private get => crateContent; set => crateContent = value; }
    

    // Start is called before the first frame update
    void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        explosionPs.Play();
        objRenderer.enabled = false;
        CrateContent.SetActive(true);
        CrateContent.transform.position = transform.position;
        CrateContent.GetComponent<Content>().SelectContent();
    }
    public void Reactivate()
    {
        objRenderer.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
