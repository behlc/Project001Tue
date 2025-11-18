using UnityEngine;
using System.Collections.Generic;

public class Weapon : MonoBehaviour
{
    public int weaponLevel;
    public List<WeaponStats> stats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    [System.Serializable]
    public class WeaponStats
    {
        public float coolDown;
        public float duration;
        public float damage;
        public float range;
    }


}
