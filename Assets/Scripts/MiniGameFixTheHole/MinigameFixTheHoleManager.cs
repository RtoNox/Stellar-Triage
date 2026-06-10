using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameFixTheHoleManager : MonoBehaviour
{
    [Header("Aset Lubang")]
    public GameObject holePrefab;       

    [Header("Pengaturan Area Sebaran Lubang (2D)")]
    public float minX = -3f;
    public float maxX = 3f;
    public float minY = -2f;
    public float maxY = 2f;

    [Header("Pengaturan Waktu & Target")]
    public int totalHolesToSpawn = 5;   
    public float timeLimit = 8f;        

    [Header("Sistem Saklar Mandiri (Seret dari Hierarchy)")]
    public GameObject gameUIUtama;      // Tempat menyeret objek 'GameUI'
    public GameObject minigameTeman;    // Tempat menyeret objek 'MinigameSide'

    private int holesRemaining;
    private float currentTimer;
    private bool isGameActive = false;
    private List<GameObject> activeHolesList = new List<GameObject>();

    void Update()
    {
        if (!isGameActive) return;

        currentTimer -= Time.deltaTime;
        if (currentTimer <= 0)
        {
            SelesaiMinigame(false);
        }
    }

    // FUNGSI UTAMA: Dipanggil langsung oleh tombol FIX AMBULANCE di GameUI
    public void BukaMinigame()
    {
        // 1. Nyalakan objek area minigame ini dulu
        this.gameObject.SetActive(true);

        // 2. Matikan menu utama bawaan agar tombol pause, shop, dll hilang bersih
        if (gameUIUtama != null) gameUIUtama.SetActive(false);

        // 3. Matikan game pesawat teman secara paksa agar tidak tabrakan
        if (minigameTeman != null) minigameTeman.SetActive(false);

        // 4. Sembunyikan tombol FIX AMBULANCE secara global agar monitor bersih saat main
        GameObject tombolSaya = GameObject.Find("FixAmbulanceButton");
        if (tombolSaya != null) tombolSaya.SetActive(false);

        // 5. Mulai tebar lubang
        MulaiMinigameTambal();
    }

    void MulaiMinigameTambal()
    {
        BersihkanLubangSisa();

        currentTimer = timeLimit;
        holesRemaining = totalHolesToSpawn;
        isGameActive = true;

        for (int i = 0; i < totalHolesToSpawn; i++)
        {
            SpawnLubangAcak();
        }
    }

    void SpawnLubangAcak()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
       
        Vector3 spawnPosition = new Vector3(randomX, randomY, -1f);

        GameObject newHole = Instantiate(holePrefab, spawnPosition, Quaternion.identity);
        newHole.transform.SetParent(this.transform);
        activeHolesList.Add(newHole);

        FixHoleClick holeScript = newHole.GetComponent<FixHoleClick>();
        if (holeScript != null)
        {
            holeScript.HubungkanKeManager(this);
        }
    }

    public void LaporkanLubangDitambal()
    {
        if (!isGameActive) return;

        holesRemaining--;
        if (holesRemaining <= 0)
        {
            SelesaiMinigame(true);
        }
    }

    void SelesaiMinigame(bool apakahMenang)
    {
        isGameActive = false;
        GameManager gm = FindObjectOfType<GameManager>();

        if (apakahMenang)
        {
            Debug.Log("MINIGAME AMBULANS: MENANG!");
            if (gm != null && gm.resources != null) gm.resources.ambulanceStatus = "Ready";
        }
        else
        {
            Debug.Log("MINIGAME AMBULANS: KALAH!");
            if (gm != null && gm.resources != null) gm.resources.ambulanceStatus = "Broken";
        }

        BersihkanLubangSisa();

        
        if (gameUIUtama != null) gameUIUtama.SetActive(true);

        GameObject tombolSaya = GameObject.Find("FixAmbulanceButton");
        if (tombolSaya != null) tombolSaya.SetActive(true);

        // Matikan area minigame kembali
        this.gameObject.SetActive(false);
    }

    void BersihkanLubangSisa()
    {
        foreach (GameObject h in activeHolesList)
        {
            if (h != null) Destroy(h);
        }
        activeHolesList.Clear();
    }
}