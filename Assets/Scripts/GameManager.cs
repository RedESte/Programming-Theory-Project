using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject crateObj;
    public GameObject pool;
    [SerializeField] List<GameObject> crateContentsPf;
    List<GameObject> crateContents = new List<GameObject>();
    List<Content[]> contentList = new List<Content[]>(); 
    int numberOfRows = 4;
    int numberOfColumns = 3;
    int selectedId = int.MaxValue;
    int score = 0;
    bool isPossibleToSelect = true;
    public bool IsPossibleToSelect { get => isPossibleToSelect; private set => isPossibleToSelect = value; }
    public int Score { get => score; private set => score = value; }
    int numberOfObj = 4;
    // Start is called before the first frame update
    private void Awake()
    {
        GetVariables();
    }
    void Start()
    {
        PopulatePool();
        SpawnCrates();
    }
    void GetVariables()
    {
        score = GameData.score;
        numberOfObj = GameData.numberOfCrates;
        numberOfRows = 4;
        numberOfColumns = numberOfObj / numberOfRows;
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
        //numberOfObj = numberOfColumns * numberOfRows / 2;
        for(int i=0; i<numberOfObj/2; i++)
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
            StartCoroutine(RightCouple());
        }
        else
        {
            StartCoroutine(CloseCrates(id));
        }
    }
    IEnumerator RightCouple()
    {
        IsPossibleToSelect = false;
        yield return new WaitForSeconds(2);
        contentList[selectedId][0].CorrectSelection();
        contentList[selectedId][1].CorrectSelection();
        Score++;
        selectedId = int.MaxValue;
        isPossibleToSelect = true;
        numberOfObj -= 2;
    
    }
    IEnumerator CloseCrates(int id)
    {
        IsPossibleToSelect = false;
        yield return new WaitForSeconds(2);
        contentList[selectedId][0].WrongSelection();
        contentList[selectedId][1].WrongSelection();

        contentList[id][0].WrongSelection();
        contentList[id][1].WrongSelection();

        selectedId = int.MaxValue;
        isPossibleToSelect = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(numberOfObj == 0)
        {
            GameData.score = score;
            int numberOfObject = GameData.numberOfCrates;
            if (numberOfObject != crateContentsPf.Count)
            {
                GameData.numberOfCrates += 4;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
