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
    AudioSource audioSource;
    enum MenuName
    {
        StartMenu,
        NameMenu
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void NewGame()
    {
        audioSource.Play();
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
            else Debug.LogError("Invalid enum");

            time += Time.deltaTime;
            yield return true;
        }
        if (name == MenuName.StartMenu) initialMenu.gameObject.SetActive(setActive);
        else if (name == MenuName.NameMenu) nameMenu.gameObject.SetActive(setActive);
        else Debug.LogError("Invalid enum");
    }
    public void Back()
    {
        audioSource.Play();
        StartCoroutine(RotateBack());
    }
    public void Quit()
    {
        audioSource.Play();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    
    public void LoadNewScene()
    {
        audioSource.Play();
        GameData.Instance.playerName = inputField.text;
        SceneManager.LoadScene(1);
    }
}
