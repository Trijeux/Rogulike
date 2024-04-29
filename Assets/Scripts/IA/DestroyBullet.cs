using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private WizzardFire _fire;
    
    // Start is called before the first frame update
    void Start()
    {
        _fire = FindFirstObjectByType<WizzardFire>();
        StartCoroutine(FireRange());
    }
    
    
    IEnumerator FireRange()
    {
        yield return new WaitForSeconds(_fire.BulletRange);
        
        Destroy(gameObject);
    }
}
