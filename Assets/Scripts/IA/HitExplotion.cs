using UnityEngine;

public class HitExplotion : MonoBehaviour
{
    private StatsPlayer _stats;
    private CharacterControllerAnimation _animation;

    private bool _isHit;
    
    // Start is called before the first frame update
    void Start()
    {
        _stats = FindFirstObjectByType<StatsPlayer>();
        _animation = FindFirstObjectByType<CharacterControllerAnimation>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!_isHit)
            {
                _stats.Life--;
                _animation.IsHit1 = true;
                _isHit = true;
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
