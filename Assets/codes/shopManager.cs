using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class shopManager : MonoBehaviour
{
    [System.Serializable]
    public class CharacterData
    {
        public string name;
        public int price;
        public bool isPurchased;
        public Sprite image;
    }

    public List<CharacterData> characters;
    public GameObject cardPrefab;
    public GameObject useButtonPrefab; // Satýn alýndýktan sonra gösterilecek görselli buton
    public Transform cardParent;

    void Start()
    {
        CreateShop();
    }

    void CreateShop()
    {
        foreach (CharacterData c in characters)
        {
            // Daha önce satýn alýnmýþ mý kontrol et
            if (PlayerPrefs.GetInt("Character_" + c.name, 0) == 1)
            {
                c.isPurchased = true;
            }

            GameObject card = Instantiate(cardPrefab, cardParent);

            // Karakter görseli
            var imageComponent = card.transform.Find("CharacterImage").GetComponent<Image>();
            if (c.image != null)
                imageComponent.sprite = c.image;

            var priceText = card.transform.Find("PriceText").GetComponent<TextMeshProUGUI>();

            if (c.isPurchased)
            {
                priceText.gameObject.SetActive(false);

                GameObject useBtn = Instantiate(useButtonPrefab, card.transform);
                useBtn.transform.SetAsLastSibling();

                useBtn.GetComponent<Button>().onClick.AddListener(() =>
                {
                    PlayerPrefs.SetString("SelectedCharacter", c.name);
                    Time.timeScale = 1f;
                    UnityEngine.SceneManagement.SceneManager.LoadScene(1);
                });

                continue;
            }

            priceText.text = c.price + " Kredi";

            Button buyBtn = card.transform.Find("BuyButton").GetComponent<Button>();
            var buyBtnText = buyBtn.GetComponentInChildren<TextMeshProUGUI>();

            buyBtn.onClick.AddListener(() =>
            {
                if (PlayerCredit.instance == null)
                    return;

                if (PlayerCredit.instance.TrySpendCredit(c.price))
                {
                    c.isPurchased = true;

                    // Kalýcý olarak kaydet
                    PlayerPrefs.SetInt("Character_" + c.name, 1);
                    PlayerPrefs.Save();

                    priceText.gameObject.SetActive(false);
                    Destroy(buyBtn.gameObject);

                    GameObject useBtn = Instantiate(useButtonPrefab, card.transform);
                    useBtn.transform.SetAsLastSibling();

                    useBtn.GetComponent<Button>().onClick.AddListener(() =>
                    {
                        PlayerPrefs.SetString("SelectedCharacter", c.name);
                        Time.timeScale = 1f;
                        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
                    });
                }
            });
        }
    }
}
