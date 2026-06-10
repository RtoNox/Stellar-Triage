using UnityEngine;

public class FixHoleClick : MonoBehaviour
{
    private MinigameFixTheHoleManager managerUtama;

    [Header("Pengaturan Klik")]
    public int jumlahKlikDibutuhkan = 5;
    private int sisaKlik;

    void Start()
    {
     
        sisaKlik = jumlahKlikDibutuhkan;
    }

    public void HubungkanKeManager(MinigameFixTheHoleManager manager)
    {
        managerUtama = manager;
    }

   
    private void OnMouseDown()
    {
       
        sisaKlik--;

     
        Debug.Log("Lubang di-klik! Sisa ketukan: " + sisaKlik);

        // Jika sisa klik sudah habis (0), baru lubang hancur
        if (sisaKlik <= 0)
        {
            if (managerUtama != null)
            {
                managerUtama.LaporkanLubangDitambal(); 
            }
            
            Destroy(gameObject); 
        }
    }
}