using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.VFX;

public class Sayac : MonoBehaviour
{
    private Rigidbody rb;
    public Text can;
    public Text oyunDurumText;
    public Text oyunTamamText;
    
    public Button nextlevel;
    public Button restart;
    public Button quit;
    public Button playgame;
    public coinText coinText;
    float canSayaci = 5;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        restart.onClick.AddListener(RestartGame);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (canSayaci <= 0)
        {
            OyunuBitir();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        string objIsmi = other.gameObject.name;
        if (objIsmi.Equals("Bitis"))
        {
            //print("Geri Dönüþüm Tamamlandý. Sizin adýnýza doðaya bir aðaç dikilecek.");

        }

        if (other.gameObject.CompareTag("car"))
        {
            if (canSayaci > 0)
            {
                canSayaci -= 1;
                can.text = "" + canSayaci.ToString();
            }
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bitis"))
        {
            oyunTamamText.text = "Geri Dönüþüm Tamamlandý.50 ve üzeri atýk topladýysanýz sizin adýnýza doðaya bir aðaç dikilecek.";
            nextlevel.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

    }
    private void OyunuBitir()
    {
        oyunDurumText.text = "Game Over"; 
        restart.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);

        Debug.Log("Oyun Bitti");
        Time.timeScale = 0; 
    }
    public void RestartGame()
    {
        
        Time.timeScale = 1; 
        canSayaci = 5; 
        can.text = "" + canSayaci.ToString(); 
        coinText.ResetCoins();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
}
   