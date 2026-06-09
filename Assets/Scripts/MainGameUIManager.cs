// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;

// public enum GameState
// {
//     Playing,
//     Pause,
//     SaveFiles,
//     MainMenu,
//     Settings,
//     Shopping,
//     LeftPanel,
//     MinigameSide
// }

// public class MiniGameUIManager : MonoBehaviour
// {
//     public GameObject pauseUI;
//     public GameObject gameUI;
//     public GameObject saveFilesUI;
//     public GameObject settingsUI;
//     public GameObject shopUI;
//     public GameObject leftPanelUI;
//     public GameObject minigameSideInterface;

//     public Button pauseButt;
//     public Button shopButt;
//     public Button leftPanelButt;

//     public GameState currentState { get; private set; }

//     void Start()
//     {
//         minigameSideInterface.SetActive(false);
//     }

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Escape))
//         {
//             if (currentState == GameState.Shopping || currentState == GameState.LeftPanel)
//             {
//                 ChangeState(GameState.Playing);
//             }
//             else if (currentState != GameState.Pause)
//             {
//                 ChangeState(GameState.Pause);
//             }
//             else
//             {
//                 ChangeState(GameState.Playing);
//             }
//         }
//     }

//     public void ChangeState(GameState newState)
//     {
//         StartCoroutine(TransitionToState(newState));

//         currentState = newState;
//     }
    
//     public void ChangeToPlaying()
//     {
//         ChangeState(GameState.Playing);
//         EnableAllButton();
//     }

//     public void ChangeToPause()
//     {
//         ChangeState(GameState.Pause);
//         DisableAllButton();
//     }

//     public void ChangeToSaveFiles()
//     {
//         ChangeState(GameState.SaveFiles);
//     }

//     public void ChangeToSettings()
//     {
//         ChangeState(GameState.Settings);
//     }

//     public void ChangeToShopping()
//     {
//         ChangeState(GameState.Shopping);
//         DisableAllButton();
//     }

//     public void ChangeToLeftPanel()
//     {
//         ChangeState(GameState.LeftPanel);
//         DisableAllButton();
//     }

//     public void ChangeToMinigameSide()
//     {
//         ChangeState(GameState.MinigameSide);
//     }

//     public void ChangeToMainMenu()
//     {
//         UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
//     }

//     private IEnumerator TransitionToState(GameState newState)
//     {
//         if(newState != GameState.MainMenu)
//         {
//             yield return new WaitForSecondsRealtime(0);
//         }

//         currentState = newState;
//         HandleStateChange();
//     }
    
//     private void HandleStateChange()
//     {
//         HideAllMenu();

//         switch (currentState)
//         {
//             case GameState.Playing:
//                 Time.timeScale = 1;
//                 gameUI.SetActive(true);
//                 break;
//             case GameState.Pause:
//                 Time.timeScale = 0;
//                 pauseUI.SetActive(true);
//                 break;
//             case GameState.SaveFiles:
//                 Time.timeScale = 0;
//                 saveFilesUI.SetActive(true);
//                 break;
//             case GameState.Settings:
//                 Time.timeScale = 0;
//                 settingsUI.SetActive(true);
//                 break;
//             case GameState.Shopping:
//                 Time.timeScale = 1;
//                 shopUI.SetActive(true);
//                 break;
//             case GameState.LeftPanel:
//                 Time.timeScale = 1;
//                 leftPanelUI.SetActive(true);
//                 break;
//             case GameState.MinigameSide:
//                 Time.timeScale = 1;
//                 minigameSideInterface.SetActive(true);
//                 break;
//         }
//     }

    
//     private void HideAllMenu()
//     {
//         pauseUI.SetActive(false);
//         saveFilesUI.SetActive(false);
//         settingsUI.SetActive(false);
//         shopUI.SetActive(false);
//         leftPanelUI.SetActive(false);
//     }

//     private void DisableAllButton()
//     {
//         pauseButt.interactable = false;
//         leftPanelButt.interactable = false;
//         shopButt.interactable = false;
//     }

//     private void EnableAllButton()
//     {
//         pauseButt.interactable = true;
//         leftPanelButt.interactable = true;
//         shopButt.interactable = true;
//     }

//     public void QuitGame()
//     {
//         Application.Quit();
//     }
// }
