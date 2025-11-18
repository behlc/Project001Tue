using UnityEngine;

public class AreaWeapon : Weapon
{   
    [SerializeField] private GameObject prefab;
    private float spawnCounter;

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
            spawnCounter = stats[weaponLevel].coolDown;
            Instantiate(prefab, transform.position, transform.rotation, transform);
        }
        
    }
}
