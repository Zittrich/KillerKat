using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public SceneAsset GameScene;
    public GameObject LoadoutMenu;
    public GameObject GameHandler;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Instantiate(GameHandler);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(GameScene.name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenLoadoutMenu()
    {
        LoadoutMenu.SetActive(true);
    }

    public void CloseLoadoutMenu()
    {
        LoadoutMenu.SetActive(false);
    }
}
