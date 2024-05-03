using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class HitEnnemie : MonoBehaviour
{
    [FormerlySerializedAs("IsKill")] public bool IsHit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sword"))
        {
            IsHit = true;
            StartCoroutine(CoolDown());
        }
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        IsHit = false;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}