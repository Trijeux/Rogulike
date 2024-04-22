using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using Random = UnityEngine.Random;

public class Wizzard : MonoBehaviour
{
    private SpriteRenderer _sr;
    private StartAssetInputPlayer _player;
    private WizzardFire _wizzardFire;
    private TP _tp;
    private int _numbtp;
    private int _numAction;
    [SerializeField] private bool _tempIsDead;
    [SerializeField] private Animator _tpWizzard;
    [SerializeField] private Animator _tpDestination;
    [SerializeField] private Animator _casteWizzard;
    [SerializeField] private GameObject _tpDestinationTransform;
    [SerializeField] [Range(0.1f, 5f)] private float _WahtForChose;
    [SerializeField] [Range(0.1f, 5f)] private float _tpTemp;
    [SerializeField] [Range(0.1f, 5f)] private float _casteTemp;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindFirstObjectByType<StartAssetInputPlayer>();
        _sr = GetComponent<SpriteRenderer>();
        _wizzardFire = GetComponent<WizzardFire>();
        Debug.Log(_player.transform.position);
        _tp = FindFirstObjectByType<TP>();
        StartCoroutine(WizardSequence());
    }

    private void Teleport()
    {
        _numbtp = Random.Range(0, _tp.TpList.Count);
        _tpDestinationTransform.transform.position = _tp.TpList[_numbtp].transform.position;
        _tpWizzard.SetFloat("TpWizzard", 1);
        _tpDestination.SetFloat("TpDestination", 1);
        //Debug.Log(_numbtp);
    }

    private void Update()
    {
        if (_player.transform.position.x < transform.position.x)
        {
            _sr.flipX = true;
        }
        else
        {
            _sr.flipX = false;
        }
    }

    IEnumerator WizardSequence()
    {
        Debug.Log("Coroutine started");

        // Attend une seconde
        do
        {
            _numAction = Random.Range(1, 3);
            switch (_numAction)
            {
                case 1:
                    Teleport();
                    yield return new WaitForSeconds(_tpTemp);
                    _tpWizzard.SetFloat("TpWizzard", 0);
                    _tpDestination.SetFloat("TpDestination", 0);
                    gameObject.transform.position = _tp.TpList[_numbtp].transform.position;
                    break;
                case 2:
                    _casteWizzard.SetFloat("Caste", 1);
                    yield return new WaitForSeconds(_casteTemp);
                    _casteWizzard.SetFloat("Caste", 0);
                    _wizzardFire.Shoot();
                    break;
                default:
                    Debug.Log("Erreur");
                    break;
            }
            
        yield return new WaitForSeconds(_WahtForChose);

        Debug.Log("One second has passed");
        } while (_tempIsDead);
    }
}