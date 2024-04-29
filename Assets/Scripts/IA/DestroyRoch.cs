using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRoch : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 5f)] private float _timeDestroy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destoryer());
    }
    
    
    IEnumerator Destoryer()
    {
        yield return new WaitForSeconds(_timeDestroy);
        Destroy(gameObject);
    }
}
