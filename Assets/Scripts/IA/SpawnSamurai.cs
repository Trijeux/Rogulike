
using UnityEngine;

public class SpawnSamurai
    : MonoBehaviour
{
    [SerializeField] private GameObject _prefabeSamurai;

    [SerializeField] private NumKillEnnemie _ennemie;
    
    private GameObject _samurai;
    private bool _destory = false;
    // Start is called before the first frame update
    void Start()
    {
        _samurai = Instantiate(_prefabeSamurai, gameObject.transform);
        _ennemie._numEnnemie++;
    }

    // Update is called once per frame
    void Update()
    {
            if (_samurai == null && !_destory)
            {
                _ennemie._numEnnemie--;
                _destory = true;
            }
    }
}
