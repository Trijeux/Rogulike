using System.Collections;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private WizzardFire _fire;
    private StatsPlayer _stats;
    private CharacterControllerAnimation _animation;
    
    // Start is called before the first frame update
    void Start()
    {
        _fire = FindFirstObjectByType<WizzardFire>();
        _stats = FindFirstObjectByType<StatsPlayer>();
        _animation = FindFirstObjectByType<CharacterControllerAnimation>();
        StartCoroutine(FireRange());
    }
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _stats.Life--;
            _animation.IsHit1 = true;
            Destroy(gameObject);
        }
    }
    
    IEnumerator FireRange()
    {
        yield return new WaitForSeconds(_fire.BulletRange);
        
        Destroy(gameObject);
    }
}
