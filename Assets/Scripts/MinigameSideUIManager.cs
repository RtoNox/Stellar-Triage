using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameStateMiniSide
{
    Playing,
    Pause,
    MainMenu,
    MainGame
}

public class MinigameSideUIManager : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject gameUI;
    public GameObject mainGameInterface;
    public GameObject minigameSideInterface;

    public GameStateMiniSide currentState { get; private set; }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState != GameStateMiniSide.Pause)
            {
                ChangeState(GameStateMiniSide.Pause);
            } 
            else
            {
                ChangeState(GameStateMiniSide.Playing);
            }
        }
    }

    public void ChangeState(GameStateMiniSide newState)
    {
        StartCoroutine(TransitionToState(newState));

        currentState = newState;
    }

    public void ChangeToPlaying()
    {
        ChangeState(GameStateMiniSide.Playing);
    }

    public void ChangeToPause()
    {
        ChangeState(GameStateMiniSide.Pause);
    }

    public void ChangeToAbort()
    {
        ChangeState(GameStateMiniSide.MainGame);
    }

    private IEnumerator TransitionToState(GameStateMiniSide newState)
    {
        if(newState != GameStateMiniSide.MainMenu)
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
            case GameStateMiniSide.Playing:
                Time.timeScale = 1;
                gameUI.SetActive(true);
                break;
            case GameStateMiniSide.Pause:
                Time.timeScale = 0;
                pauseUI.SetActive(true);
                break;
            case GameStateMiniSide.MainGame:
                gameUI.SetActive(true);
                Time.timeScale = 1;
                minigameSideInterface.SetActive(false);
                mainGameInterface.SetActive(true);
                break;
        }
    }

    private void HideAllMenu()
    {
        pauseUI.SetActive(false);
        gameUI.SetActive(false);
    }
}
