using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Wizzard : MonoBehaviour
{
    [SerializeField] private StartAssetInputPlayer _player;
    [SerializeField] private TP _tp;
    [SerializeField] private List<GameObject> _tpList;
    [SerializeField] private WizzardFire _wizzardFire;
    private int _numbtp;
    private int _numAction;
    private bool _temp = true;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindFirstObjectByType<StartAssetInputPlayer>();
        _wizzardFire = GetComponent<WizzardFire>();
        Debug.Log(_player.transform.position);
        _tp = FindFirstObjectByType<TP>();

        _tpList.Clear();
        if (_tp != null)
        {
            Transform parentTransform = _tp.transform;

            for (int i = 0; i < parentTransform.childCount; i++)
            {
                Transform childTransform = parentTransform.GetChild(i);
                GameObject childObject = childTransform.gameObject;

                _tpList.Add(childObject);
            }

            foreach (GameObject child in _tpList)
            {
                Debug.Log("Enfant trouvé : " + child.name);
            }
        }
        else
        {
            Debug.LogWarning("La référence au parentObject n'est pas définie.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_temp)
        {
            _temp = false;
            StartCoroutine(WaitForOneSecond());
            
        }
        
    }

    private void Teleport()
    {
        _numbtp = Random.Range(0, _tpList.Count);
        //Debug.Log(_numbtp);
        gameObject.transform.position = _tpList[_numbtp].transform.position;
    }

    IEnumerator WaitForOneSecond()
    {
        Debug.Log("Coroutine started");

        // Attend une seconde
        _numAction = Random.Range(1, 3);
        switch (_numAction)
        {
            case 1:
                Teleport();
                break;
            case 2:
                _wizzardFire.Shoot();
                break;
            default:
                Debug.Log("Erreur");
                break;
    }
        
        
        yield return new WaitForSeconds(1f);

        _temp = true;

        Debug.Log("One second has passed");
    }
}