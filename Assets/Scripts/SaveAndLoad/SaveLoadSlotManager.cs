// using UnityEngine;

// public class SaveLoadSlotManager : MonoBehaviour
// {
//     [Header("References")]
//     public GameManager gameManager;       
//     public GameUIManager uiManager;       

//     private void Start()
//     {
//         if (PlayerPrefs.HasKey("SlotToLoadOnStart"))
//         {
//             int slotYangDiminta = PlayerPrefs.GetInt("SlotToLoadOnStart");
//             ExecuteLoad(slotYangDiminta);
//             PlayerPrefs.DeleteKey("SlotToLoadOnStart");
//         }
//     }
    
//     public void TriggerLoadSlot1() { MainMenuLoadSequence(1); }
//     public void TriggerLoadSlot2() { MainMenuLoadSequence(2); }
//     public void TriggerLoadSlot3() { MainMenuLoadSequence(3); }

//     private void MainMenuLoadSequence(int slotNumber)
//     {
//         PlayerPrefs.SetInt("SlotToLoadOnStart", slotNumber);
//         PlayerPrefs.Save();

//         if (MainMenuManager.instance != null)
//         {
//             MainMenuManager.instance.ChangeToMainGame();
//         }
//         else
//         {
//             UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
//         }
//     }

//     public void ClickSaveSlot1() { ExecuteSave(1); }
//     public void ClickSaveSlot2() { ExecuteSave(2); }
//     public void ClickSaveSlot3() { ExecuteSave(3); }

//     private void ExecuteSave(int slotNumber)
//     {
//         if (gameManager == null) return;
//         SaveSystem.SavePlayer(gameManager, slotNumber);
//         Debug.Log("Game berhasil disave ke slot " + slotNumber);
//     }

//     public void ExecuteLoad(int slotNumber)
//     {
//         if (gameManager == null) return;

//         PlayerData data = SaveSystem.LoadPlayer(slotNumber);

//         if (data != null)
//         {
//             gameManager.resources.dayCount = data.dayCount;
//             gameManager.resources.dateString = data.dateString;
//             gameManager.resources.money = data.money;
//             gameManager.resources.ambulanceStatus = data.ambulanceStatus;
//             gameManager.resources.upgradeLevel = data.upgradeLevel;
//             gameManager.resources.ambulanceCount = data.ambulanceCount;
            
//             Debug.Log("Load Berhasil dari Slot " + slotNumber);

//             if (uiManager != null)
//             {
//                 uiManager.ChangeState(GameState.Playing);
//             }
//         }
//     }
// }