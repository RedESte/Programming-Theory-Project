using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionPs;
    GameObject crateContent;
    Renderer objRenderer;
    BoxCollider boxCollider;
    GameManager gameManager;

    public GameObject CrateContent { private get => crateContent; set => crateContent = value; }
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        objRenderer = GetComponent<Renderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnMouseDown()
    {
        if (!gameManager.IsPossibleToSelect) return;
        explosionPs.Play();
        objRenderer.enabled = false;
        boxCollider.enabled = false;
        CrateContent.SetActive(true);
        CrateContent.transform.position = transform.position;
        CrateContent.GetComponent<Content>().SelectContent(this);
    }
    public void Reactivate()
    {
        objRenderer.enabled = true;
        boxCollider.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
