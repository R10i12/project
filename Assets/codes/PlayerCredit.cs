using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCredit : MonoBehaviour
{
    public static PlayerCredit instance;
    public int credits =100;

    private void Awake()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Oyunu başlatınca kayıtlı kredi var mı kontrol et
            credits = PlayerPrefs.GetInt("PlayerCredits", 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCredit(int amount)
    {
        credits += amount;
        SaveCredits(); // Her değişimde kaydet
        Debug.Log("Kredi: " + credits);
    }

    public bool TrySpendCredit(int amount)
    {
        if (credits >= amount)
        {
            credits -= amount;
            SaveCredits(); // Harcarken de kaydet
            return true;
        }
        else
        {
            Debug.Log("Yetersiz kredi!");
            return false;
        }
    }

    public void SaveCredits()
    {
        PlayerPrefs.SetInt("PlayerCredits", credits);
        PlayerPrefs.Save();
    }
    public void SetCredit(int value)
    {
        credits = value;
        SaveCredits(); // İstersen bu satırı ekle, kayıt dosyasına da yazar
    }
}

