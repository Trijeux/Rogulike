
using UnityEngine;

public class Heal : MonoBehaviour
{
    private StatsPlayer _player;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_player.Life < _player.MaxLife)
            {
                _player.Life++;
            }
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _player = FindFirstObjectByType<StatsPlayer>();
    }
}
