
using UnityEngine;

public class NumKillEnnemie : MonoBehaviour
{
    public int _numEnnemie;
    [SerializeField] private GameObject _door;

    private void Update()
    {
        if (_numEnnemie <= 0)
        {
            _door.SetActive(true);
        }
        else
        {
            _door.SetActive(false);
        }
    }
}
