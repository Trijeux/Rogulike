    using System.Collections;
    using UnityEngine;

    public class DestroySlashSprit : MonoBehaviour
    {
        private Samurai _samurai;
        
        void Start()
        {
            _samurai = FindFirstObjectByType<Samurai>();
            StartCoroutine(SlashTime());
        }
        
        IEnumerator SlashTime()
        {
            yield return new WaitForSeconds(_samurai.TempSlash);
        
            Destroy(gameObject);
        }
    }
