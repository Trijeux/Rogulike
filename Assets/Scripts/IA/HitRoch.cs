using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitRoch : MonoBehaviour
{
    private StatsPlayer _stats;
    private CharacterControllerAnimation _animation;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _stats.Life--;
            _animation.IsHit1 = true;
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _stats = FindFirstObjectByType<StatsPlayer>();
        _animation = FindFirstObjectByType<CharacterControllerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
