using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private  Rigidbody2D rb;
    [SerializeField] private  Animator animator;

    [SerializeField] private  float moveSpeed = 1;
    public Vector3 playerMoveDirection;
    public float playerMaxHealth;
    public float playerHealth;

    public int experience;

    public int currentLevel;
    public int maxLevel;
    public List<int> playerLevels;




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
        for (int i = playerLevels.Count; i < maxLevel; i++)
        {
            playerLevels.Add(Mathf.CeilToInt(playerLevels[playerLevels.Count - 1] * 1.1f + 15));
        }

        playerHealth = playerMaxHealth;
        UIController.Instance.UpdateHealthSlider();
        UIController.Instance.UpdateExperienceSlider();

    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        playerMoveDirection = new Vector3(inputX, inputY);

        animator.SetFloat("moveX", inputX);
        animator.SetFloat("moveY", inputY);


        if(playerMoveDirection == Vector3.zero)
        {
           animator.SetBool("moving",false);
        }
        else 
        {
            animator.SetBool("moving",true);
        }

        rb.linearVelocity = new Vector3(playerMoveDirection.x * moveSpeed,playerMoveDirection.y * moveSpeed);
    
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        UIController.Instance.UpdateHealthSlider();

        if (playerHealth <= 0) {
            gameObject.SetActive(false);
            GameManager.Instance.GameOver();
        }
    }

    public void GetExperience(int experienceToGet) 
    {
        experience += experienceToGet;
        UIController.Instance.UpdateExperienceSlider();
        if(experience >= playerLevels[currentLevel - 1])
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        experience -= playerLevels[currentLevel - 1];
        UIController.Instance.LevelUpPanelOpen();
        currentLevel++;
        UIController.Instance.UpdateExperienceSlider();
    }

}

