using UnityEngine;

public class AreaWeaponPrefab : MonoBehaviour
{
    public AreaWeapon weapon;
    private Vector3 targetSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weapon = GameObject.Find("AreaWeapon").GetComponent<AreaWeapon>();

        Destroy(gameObject, weapon.stats[weapon.weaponLevel].duration);
        
        targetSize = Vector3.one * weapon.stats[weapon.weaponLevel].range;
        transform.localScale = targetSize;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collider) 
    {
        if(collider.CompareTag("Enemy"))
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.TakeDamage(weapon.stats[weapon.weaponLevel].damage);
        }
    }


}
