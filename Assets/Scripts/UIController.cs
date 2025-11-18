using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIController : MonoBehaviour
{
    public static UIController Instance;
    [SerializeField] private Slider playerHealthSlider;
    [SerializeField] private TMP_Text healthText;
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    [SerializeField] private Slider playerExperienceSlider;
    [SerializeField] private TMP_Text experienceText;

    public GameObject levelUpPanel;
    [SerializeField] private TMP_Text levelText;
    private AreaWeapon UIWeapon;

    void Awake()
 {
     if (Instance != null && Instance != this) 
     {
         Destroy(this);
     }
     else 
     { 
         Instance = this;
     }
 }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIWeapon = GameObject.Find("AreaWeapon").GetComponent<AreaWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if(levelUpPanel.activeSelf == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                levelUpPanel.SetActive(false);
                Time.timeScale = 1f;
                //UIWeapon.LevelUp();
            }
        }
    }

    public void UpdateHealthSlider()
    {
        playerHealthSlider.maxValue = PlayerController.Instance.playerMaxHealth;
        playerHealthSlider.value = PlayerController.Instance.playerHealth;
        healthText.text = playerHealthSlider.value + "/" + playerHealthSlider.maxValue;
    
    }

    public void UpdateExperienceSlider()
    {
        playerExperienceSlider.maxValue = PlayerController.Instance.playerLevels[PlayerController.Instance.currentLevel-1];
        playerExperienceSlider.value = PlayerController.Instance.experience;
        experienceText.text = playerExperienceSlider.value + "/" + playerExperienceSlider.maxValue;
    
    }

    public void LevelUpPanelOpen()
    {
        levelText.text = "Level " + PlayerController.Instance.currentLevel + " Completed";
        levelUpPanel.SetActive(true);
        Time.timeScale = 0f;
    }


}
