using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject crateObj;
    public GameObject pool;
    [SerializeField] List<GameObject> crateContentsPf;
    List<GameObject> crateContents = new List<GameObject>();
    List<Content[]> contentList; 
    int numberOfRows = 2;
    int numberOfColumns = 2;
    int selectedId = int.MaxValue;

    // Start is called before the first frame update
    void Start()
    {
        PopulatePool();
        SpawnCrates();
    }
    void SpawnCrates()
    {
        Vector3 offset = new Vector3(numberOfColumns, 0, numberOfRows);
        for (int i = 0; i < numberOfRows; i++)
        {
            for (int j = 0; j < numberOfColumns; j++)
            {
                Vector3 position = new Vector3(2*j, 0, 2*i) - offset;
                Crate crate = Instantiate(crateObj, position, crateObj.transform.rotation).GetComponent<Crate>();
                AppendContent(crate);
            }
        }
    }
    void AppendContent(Crate crate)
    {
        int index = Random.Range(0, crateContents.Count);
        crate.CrateContent = crateContents[index];
        crateContents.RemoveAt(index);
    }
    void PopulatePool()
    {
        int numberOfObj = numberOfColumns * numberOfRows / 2;
        for(int i=0; i<numberOfObj; i++)
        {
            Content[] array = new Content[2];
            array[0] = InstantiateContentAt(i);
            array[1] = InstantiateContentAt(i);
            contentList.Add(array);
        }
    }
    Content InstantiateContentAt(int index)
    {
        GameObject obj = Instantiate(crateContentsPf[index], pool.transform);
        Content content = obj.GetComponent<Content>();
        content.ObjId = index;
        content.gameManager = this;
        crateContents.Add(obj);
        obj.SetActive(false);
        return content;
    }
    public void ContentSelected(int id)
    {
        if(selectedId == int.MaxValue)
        {
            selectedId = id;
        }
        else if(selectedId == id)
        {
            RightCouple();
        }
        else
        {
            CloseCrates();
        }
    }
    void RightCouple()
    {
        Content content = contentList[selectedId][0];
        selectedId = int.MaxValue;
    }
    void CloseCrates()
    {
        selectedId = int.MaxValue;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
