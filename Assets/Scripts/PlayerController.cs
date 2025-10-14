using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private  Rigidbody2D rb;
    [SerializeField] private  Animator animator;

    [SerializeField] private  float moveSpeed = 1;
    public Vector3 playerMoveDirection;
    public float playerMaxHealth;
    public float playerHealth;



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
        playerHealth = playerMaxHealth;
        UIController.Instance.UpdateHealthSlider();
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


}

