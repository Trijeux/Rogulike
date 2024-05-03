
using UnityEngine;

public class NextRoom : MonoBehaviour
{
    private SelectRoom _room;
    private NumKillEnnemie _roomEnnemie;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _room.NextRoom();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _room = FindFirstObjectByType<SelectRoom>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
