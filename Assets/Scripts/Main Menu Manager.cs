using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject settings;
    public GameObject mainMenu;
    public GameObject saveFiles;

    public void OpenSave()
    {
        saveFiles.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void CloseSave()
    {
        saveFiles.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OpenSettings()
    {
        settings.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void CloseSettings()
    {
        settings.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
