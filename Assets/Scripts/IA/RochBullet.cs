using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RochBullet : MonoBehaviour
{
    [SerializeField] private GameObject _hitZone;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Hit());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Hit()
    {
        yield return new WaitForSeconds(1f);
        _hitZone.SetActive(true);
    }
}
