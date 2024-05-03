

    using UnityEngine;

    public class DestroySlash : MonoBehaviour
    {
        private bool _temp;
        private Samurai _samurai;
        private StatsPlayer _stats;
        private CharacterControllerAnimation _animation;
        [SerializeField] private GameObject _slash;
    
        // Start is called before the first frame update
        void Start()
        {
            _samurai = FindFirstObjectByType<Samurai>();
            _stats = FindFirstObjectByType<StatsPlayer>();
            _animation = FindFirstObjectByType<CharacterControllerAnimation>();
        }
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _stats.Life--;
                _animation.IsHit1 = true;
                gameObject.SetActive(false);
            }
        }
    }
