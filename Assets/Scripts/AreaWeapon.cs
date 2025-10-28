using UnityEngine;

public class AreaWeapon : MonoBehaviour
{   
    [SerializeField] private GameObject prefab;
    private float spawnCounter;

    public float coolDown = 5f;
    public float duration = 3f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnCounter -= Time.deltaTime;
        if (spawnCounter <= 0)
        {
            spawnCounter = coolDown;
            Instantiate(prefab, transform.position, transform.rotation, transform);
        }
        
    }
}
