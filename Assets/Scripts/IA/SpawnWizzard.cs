
using UnityEngine;

public class SpawnWizzard : MonoBehaviour
{
    [SerializeField] private GameObject _prefabeWizzard;

    [SerializeField] private NumKillEnnemie _ennemie;

    private GameObject _wizzard;
    private bool _destory = false;
    // Start is called before the first frame update
    void Start()
    {
        _wizzard = Instantiate(_prefabeWizzard, gameObject.transform);
        _ennemie._numEnnemie++;
    }

    // Update is called once per frame
    void Update()
    {
        if (_wizzard == null && !_destory)
        {
            _ennemie._numEnnemie--;
            _destory = true;
        }
    }
}
