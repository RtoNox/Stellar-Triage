// using UnityEngine;
// using UnityEngine.Events;

// public class MinigameManager : MonoBehaviour
// {
//     public static MinigameManager Instance { get; private set; }

//     public enum VehicleState { Operational, Broken }
//     public VehicleState CurrentVehicleState { get; private set; } = VehicleState.Operational;

//     // Events for main game to subscribe to
//     public System.Action<VehicleState> OnVehicleStateChanged;
//     public System.Action OnGameOver;
//     public System.Action OnGameWin;  // NEW: win event for main game

//     [Header("Survival Timer")]
//     public float survivalTimeRequired = 180f; // 3 minutes = 180 seconds
//     private float currentTimer;
//     private bool isGameActive = true;
//     private bool hasWon = false;

//     [Header("UI References (Optional)")]
//     public UnityEngine.UI.Text timerText; // Drag a UI Text here
//     public GameObject gameOverPanel;
//     public GameObject winPanel;

//     void Awake()
//     {
//         if (Instance == null)
//         {
//             Instance = this;
//             DontDestroyOnLoad(gameObject);
//         }
//         else
//         {
//             Destroy(gameObject);
//             return;
//         }

//         currentTimer = survivalTimeRequired;
//         CurrentVehicleState = VehicleState.Operational;
//     }

//     void Start()
//     {
//         OnVehicleStateChanged?.Invoke(CurrentVehicleState);
        
//         // Hide panels at start
//         if (gameOverPanel) gameOverPanel.SetActive(false);
//         if (winPanel) winPanel.SetActive(false);
//     }

//     void Update()
//     {
//         if (!isGameActive || hasWon) return;

//         // Count down the timer
//         currentTimer -= Time.deltaTime;
        
//         // Update UI timer display
//         if (timerText != null)
//         {
//             int minutes = Mathf.FloorToInt(currentTimer / 60f);
//             int seconds = Mathf.FloorToInt(currentTimer % 60f);
//             timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
//         }

//         // Check for victory
//         if (currentTimer <= 0f && !hasWon)
//         {
//             WinGame();
//         }
//     }

//     void WinGame()
//     {
//         hasWon = true;
//         isGameActive = false;
        
//         Debug.Log("🎉 SURVIVED 3 MINUTES! VEHICLE OPERATIONAL - Mission Success!");
        
//         // Vehicle stays OPERATIONAL (not broken)
//         CurrentVehicleState = VehicleState.Operational;
        
//         // Notify main game of success
//         OnGameWin?.Invoke();
//         OnVehicleStateChanged?.Invoke(CurrentVehicleState);
        
//         // Freeze gameplay and show win UI
//         Time.timeScale = 0f;
        
//         if (winPanel) winPanel.SetActive(true);
//     }

//     public void PlayerHit()
//     {
//         if (!isGameActive || hasWon) return;

//         isGameActive = false;
//         CurrentVehicleState = VehicleState.Broken;
        
//         Debug.Log("💥 VEHICLE BROKEN - Failed to survive 3 minutes");
        
//         // Notify main game systems
//         OnVehicleStateChanged?.Invoke(CurrentVehicleState);
//         OnGameOver?.Invoke();
        
//         // Freeze gameplay and show loss UI
//         Time.timeScale = 0f;
        
//         if (gameOverPanel) gameOverPanel.SetActive(true);
//     }

//     public bool IsGameActive()
//     {
//         return isGameActive && !hasWon && CurrentVehicleState == VehicleState.Operational;
//     }

//     public bool HasWon()
//     {
//         return hasWon;
//     }

//     public float GetRemainingTime()
//     {
//         return currentTimer;
//     }

//     public void ResetMinigame()
//     {
//         isGameActive = true;
//         hasWon = false;
//         CurrentVehicleState = VehicleState.Operational;
//         currentTimer = survivalTimeRequired;
//         Time.timeScale = 1f;
        
//         if (gameOverPanel) gameOverPanel.SetActive(false);
//         if (winPanel) winPanel.SetActive(false);
        
//         OnVehicleStateChanged?.Invoke(CurrentVehicleState);
//     }

//     void OnDestroy()
//     {
//         if (Time.timeScale == 0f) Time.timeScale = 1f;
//     }
// }