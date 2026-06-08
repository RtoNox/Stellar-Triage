using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MenuState
{
    MainMenu,
    SaveFiles,
    Settings,
    MainGame
}

public class MainMenuManager : MonoBehaviour
{
    public GameObject settingsUI;
    public GameObject mainMenuUI;
    public GameObject saveFilesUI;

    public static MainMenuManager instance;
    public MenuState currentState { get; private set; }

    public void ChangeState(MenuState newState)
    {
        StartCoroutine(TransitionToState(newState));

        currentState = newState;
    }
    
    public void ChangeToSaveFiles()
    {
        ChangeState(MenuState.SaveFiles);
    }

    public void ChangeToMainMenu()
    {
        ChangeState(MenuState.MainMenu);
    }

    public void ChangeToSettings()
    {
        ChangeState(MenuState.Settings);
    }

    public void ChangeToMainGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
    }

    private IEnumerator TransitionToState(MenuState newState)
    {
        if(newState != MenuState.MainMenu)
        {
            yield return new WaitForSecondsRealtime(0);
        }

        currentState = newState;
        HandleStateChange();
    }
    
    private void HandleStateChange()
    {
        HideAllMenu();

        switch (currentState)
        {
            case MenuState.MainMenu:
                mainMenuUI.SetActive(true);
                break;
            case MenuState.Settings:
                settingsUI.SetActive(true);
                break;
            case MenuState.SaveFiles:
                saveFilesUI.SetActive(true);
                break;
        }
    }

    
    private void HideAllMenu()
    {
        mainMenuUI.SetActive(false);
        settingsUI.SetActive(false);
        saveFilesUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
