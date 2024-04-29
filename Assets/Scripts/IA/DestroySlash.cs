
    using System.Collections;
    using UnityEngine;

    public class DestroySlash : MonoBehaviour
    {
        private bool _temp;
        private Samurai _samurai;
    
        // Start is called before the first frame update
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
