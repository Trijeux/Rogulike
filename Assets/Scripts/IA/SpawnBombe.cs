
using System.Collections.Generic;
using UnityEngine;
public class SpawnBombe : MonoBehaviour
{
    [SerializeField] private GameObject _prefabeBombe;

    [SerializeField] private NumKillEnnemie _ennemie;

    [SerializeField] private List<GameObject> _spawnList;

    private GameObject _bombe;
    private bool _destory = false;
    // Start is called before the first frame update
    void Start()
    {
        _spawnList.Clear();
        if (gameObject != null)
        {
            Transform parentTransform = gameObject.transform;

            for (int i = 0; i < parentTransform.childCount; i++)
            {
                Transform childTransform = parentTransform.GetChild(i);
                GameObject childObject = childTransform.gameObject;

                _spawnList.Add(childObject);
            }

            foreach (GameObject child in _spawnList)
            {
                Debug.Log("Enfant trouvé : " + child.name);
            }
        }
        else
        {
            Debug.LogWarning("La référence au parentObject n'est pas définie.");
        }

        int numb = Random.Range(0, 4);
        
        _bombe = Instantiate(_prefabeBombe, _spawnList[numb].gameObject.transform);
        _ennemie._numEnnemie++;
    }


    // Update is called once per frame
    void Update()
    {
            if (_bombe == null && !_destory)
            {
                _ennemie._numEnnemie--;
                _destory = true;
            }
        
    }
}