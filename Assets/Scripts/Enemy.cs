using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private  Rigidbody2D rb;
    private Vector3 direction;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject destroyEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.Instance.gameObject.activeSelf) {
            if (PlayerController.Instance.transform.position.x > transform.position.x) 
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }

            direction = (PlayerController.Instance.transform.position - transform.position);
            rb.linearVelocity = new Vector2 (direction.x * moveSpeed, direction.y * moveSpeed);

        } else
        {
            rb.linearVelocity = Vector2.zero;
        }
    
    }

    void OnCollisionStay2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            PlayerController.Instance.TakeDamage(1);
            Destroy(gameObject);
            Instantiate(destroyEffect,transform.position, transform.rotation);
        }
    }
}
