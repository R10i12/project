using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpawner : MonoBehaviour
{
    public GameObject[] characterPrefabs;

    void Start()
    {
        // PlayerPrefs'ten seçilen karakterin adını alıyoruz
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter", "stealthWarrior");

        // Tüm prefablar arasında seçilen karakterle eşleşeni bul
        foreach (GameObject prefab in characterPrefabs)
        {
            if (prefab.name == selectedCharacter)
            {
                // Karakter prefabını instantiate et ve bu GameObject'in içine yerleştir
                GameObject character = Instantiate(prefab, transform.position, prefab.transform.rotation);
                character.transform.SetParent(transform); // karakter GameObject objesinin çocuğu olur
                character.transform.localPosition = Vector3.zero; // tam ortasına yerleşsin
                break;
            }
        }
    }
}
