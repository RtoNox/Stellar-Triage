using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    MainMenu,
    SaveFiles,
    Settings
}

public class MainMenuManager : MonoBehaviour
{
    public GameObject settingsUI;
    public GameObject mainMenuUI;
    public GameObject saveFilesUI;

    public static MainMenuManager instance;
    public GameState currentState { get; private set; }

    public void ChangeState(GameState newState)
    {
        StartCoroutine(TransitionToState(newState));

        currentState = newState;
    }
    
    public void ChangeToSaveFiles()
    {
        ChangeState(GameState.SaveFiles);
    }

    public void ChangeToMainMenu()
    {
        ChangeState(GameState.MainMenu);
    }

    public void ChangeToSettings()
    {
        ChangeState(GameState.Settings);
    }

    private IEnumerator TransitionToState(GameState newState)
    {
        if(newState != GameState.MainMenu)
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
            case GameState.MainMenu:
                mainMenuUI.SetActive(true);
                break;
            case GameState.Settings:
                settingsUI.SetActive(true);
                break;
            case GameState.SaveFiles:
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
