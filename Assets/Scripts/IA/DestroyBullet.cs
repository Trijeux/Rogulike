using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private Transform player;
    private bool _temp;
    private WizzardFire _fire;
    
    // Start is called before the first frame update
    void Start()
    {
        player = player = GameObject.FindGameObjectWithTag("Player").transform;;
        _fire = GameObject.FindFirstObjectByType<WizzardFire>();
        StartCoroutine(FireRange());
    }
    
    
    IEnumerator FireRange()
    {
        yield return new WaitForSeconds(_fire.BulletRange);
        
        Destroy(gameObject);
    }
}
