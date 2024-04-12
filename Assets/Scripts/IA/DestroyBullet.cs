using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private Transform player;
    private bool _temp;
    
    // Start is called before the first frame update
    void Start()
    {
        player = player = GameObject.FindGameObjectWithTag("Player").transform;;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            StartCoroutine(WaitForOneSecond());
        }
    }

    private void DestroysBullet()
    {
            Destroy(gameObject);
    }
    
    IEnumerator WaitForOneSecond()
    {
        Debug.Log("Coroutine started");
        
        yield return new WaitForSeconds(2f);
        
        Destroy(gameObject);

        _temp = true;

        Debug.Log("One second has passed");
    }
}
