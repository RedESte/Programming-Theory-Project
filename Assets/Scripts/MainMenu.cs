using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MainMenu : MonoBehaviour
{
    public RectTransform initialMenu;
    public RectTransform nameMenu;
    public TMP_InputField inputField;
    float transitionTime = 0.2f;
    enum MenuName
    {
        StartMenu,
        NameMenu
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void NewGame()
    {
        StartCoroutine(RotateMenu());
    }
    IEnumerator RotateMenu()
    {
        float fromAngle = 0;
        float toAngle = 90f;
        yield return StartCoroutine(Rotate(MenuName.StartMenu, fromAngle, toAngle, false));
        yield return StartCoroutine(Rotate(MenuName.NameMenu, -toAngle, fromAngle, true));
    }
    IEnumerator RotateBack()
    {
        float fromAngle = 0;
        float toAngle = 90f;
        yield return StartCoroutine(Rotate(MenuName.NameMenu, fromAngle, -toAngle, false));
        yield return StartCoroutine(Rotate(MenuName.StartMenu, toAngle, fromAngle, true));
        
    }
    IEnumerator Rotate(MenuName name, float fromAngle, float toAngle, bool setActive)
    {
        float time = 0;
        if (name == MenuName.StartMenu) initialMenu.gameObject.SetActive(true);
        else if (name == MenuName.NameMenu) nameMenu.gameObject.SetActive(true);
        while (time < transitionTime)
        {
            Vector3 rotation = new Vector3(0, Mathf.Lerp(fromAngle, toAngle, time / transitionTime), 0);

            if (name == MenuName.StartMenu)
                initialMenu.rotation = Quaternion.Euler(rotation);
            else if (name == MenuName.NameMenu)
                nameMenu.rotation = Quaternion.Euler(rotation);
            else Debug.LogError("Wrong enum set in Rotate");

            time += Time.deltaTime;
            yield return true;
        }
        if (name == MenuName.StartMenu) initialMenu.gameObject.SetActive(setActive);
        else if (name == MenuName.NameMenu) nameMenu.gameObject.SetActive(setActive);
        else Debug.LogError("Wrong enum set in Rotate");
    }
    public void Back()
    {
        StartCoroutine(RotateBack());
    }
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    
    public void LoadNewScene()
    {
        GameData.playerName = inputField.text;
        SceneManager.LoadScene(1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
