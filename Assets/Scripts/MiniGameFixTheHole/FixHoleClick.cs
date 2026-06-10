using UnityEngine;

public class FixHoleClick : MonoBehaviour
{
    private MinigameFixTheHoleManager managerUtama;

    [Header("Pengaturan Klik")]
    public int jumlahKlikDibutuhkan = 5; // Jumlah klik untuk menghancurkan lubang
    private int sisaKlik;

    void Start()
    {
        // Set nilai sisa klik awal sesuai target (5 kali)
        sisaKlik = jumlahKlikDibutuhkan;
    }

    public void HubungkanKeManager(MinigameFixTheHoleManager manager)
    {
        managerUtama = manager;
    }

    // Fungsi otomatis Unity saat mendeteksi klik mouse di atas Collider 2D lubang
    private void OnMouseDown()
    {
        // Kurangi sisa klik setiap kali lubang di-klik
        sisaKlik--;

        // OPSIONAL: Efek visual saat di-klik (bisa ditambahkan animasi/suara di sini nanti)
        Debug.Log("Lubang di-klik! Sisa ketukan: " + sisaKlik);

        // Jika sisa klik sudah habis (0), baru lubang hancur
        if (sisaKlik <= 0)
        {
            if (managerUtama != null)
            {
                managerUtama.LaporkanLubangDitambal(); // Lapor ke pusat manager
            }
            
            Destroy(gameObject); // Hancurkan lubang dari layar
        }
    }
}