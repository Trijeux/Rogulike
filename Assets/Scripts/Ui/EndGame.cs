using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(End());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(2f);
        Application.Quit();
    }
}
