using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Content : MonoBehaviour
{
    int objId;
    Crate m_Crate;
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
    public void SelectContent(Crate crate)
    {
        m_Crate = crate;
        if (gameManager != null)
        {
            gameManager.ContentSelected(objId);
        }
        
    }
    public void CorrectSelection()
    {
        gameObject.SetActive(false);
    }
    public void WrongSelection()
    {
        if (m_Crate != null)
        {
            m_Crate.Reactivate();
            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
