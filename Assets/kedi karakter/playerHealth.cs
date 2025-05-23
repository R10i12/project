using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public GameObject gameOverImage;
    public GameObject cat;
    public int currentHealth;
    [SerializeField] private int maxHealth;
    [SerializeField] private Image healthBarFillImage;
    public bool isBlocking = false;
    private Animator animator;
    // Start is called before the first frame update
    public virtual void Awake()
    {
        currentHealth = maxHealth;
    }
    public void ChangeCurrentHealth(int value)
    {
        currentHealth += value;
    if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    if(currentHealth < 0)
        {
            die();
        }
        ChangeHealthBar();

    }
    public void IncreaseHealth(int value)
    {
        ChangeCurrentHealth(value);
    }
    public void DecreaseHealth(int value)
    {
        if (isBlocking)
        {
            ChangeCurrentHealth(-1); // blokluyorsa sadece 1 can gider
        }
        else
        {
            ChangeCurrentHealth(-value); // normaldeki gibi tam hasar
        }
    }
    public virtual void die()
    {
        //Destroy(this.gameObject);
      cat.SetActive(false);
        Time.timeScale = 0f;

         gameOverImage.SetActive(true);
    }
    private void ChangeHealthBar()
    {
        if(healthBarFillImage)
        healthBarFillImage.fillAmount = (float)currentHealth / maxHealth;
    }
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isBlocking = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isBlocking = false;
        }
        if (cat == null)
        {
            cat = transform.GetChild(0).gameObject; // ilk çocuk karakterin modeliyse

        }
        if (animator != null)
        {
            animator.SetBool("isBlocking", isBlocking); // ← BU satır eksikti
        }

    }
}
