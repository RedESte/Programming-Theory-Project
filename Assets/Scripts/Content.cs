using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Content : MonoBehaviour
{
    int objId;
    Crate m_Crate;
    protected int contentScore = 5;
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
    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void SelectContent(Crate crate)
    {
        m_Crate = crate;
        gameManager.ContentSelected(objId, contentScore);
    }
    public virtual void CorrectSelection()
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

}
