using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Content : MonoBehaviour
{
    int objId;
    public int ObjId
    {
        get
        {
            return objId;
        }
        set
        {
            if (value < 0) return;
            objId = value;
        }
    }
    public GameManager gameManager;
    public void SelectContent()
    {
        if (gameManager != null)
        {
            gameManager.ContentSelected(objId);
        }
    }
    public void CorrectSelection()
    {
        gameObject.GetComponentInParent<Crate>();
    }
    public void WrongSelection()
    {
        gameObject.GetComponentInParent<Crate>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
