using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GeneratorNv : MonoBehaviour
{
    #region Easy

    [Header("Easy")]

    #region Variable

    [SerializeField]
    private GameObject _nv11;

    [SerializeField] private GameObject _11H;
    [SerializeField] private GameObject _11C;
    [SerializeField] private GameObject _11I;
    [SerializeField] private GameObject _nv12;
    [SerializeField] private GameObject _12H;
    [SerializeField] private GameObject _12C;
    [SerializeField] private GameObject _12I;
    [SerializeField] private GameObject _nv13;
    [SerializeField] private GameObject _13H;
    [SerializeField] private GameObject _13C;
    [SerializeField] private GameObject _13I;
    [SerializeField] private GameObject _nv111;
    [SerializeField] private GameObject _111H;
    [SerializeField] private GameObject _111C;
    [SerializeField] private GameObject _111I;
    [SerializeField] private GameObject _nv112_121;
    [SerializeField] private GameObject _112_121H;
    [SerializeField] private GameObject _112_121C;
    [SerializeField] private GameObject _112_121I;
    [SerializeField] private GameObject _nv122;
    [SerializeField] private GameObject _122H;
    [SerializeField] private GameObject _122C;
    [SerializeField] private GameObject _122I;
    [SerializeField] private GameObject _nv123_131;
    [SerializeField] private GameObject _123_131H;
    [SerializeField] private GameObject _123_131C;
    [SerializeField] private GameObject _123_131I;
    [SerializeField] private GameObject _nv132;
    [SerializeField] private GameObject _132H;
    [SerializeField] private GameObject _132C;
    [SerializeField] private GameObject _132I;

    [SerializeField] public GameObject _arrow11;
    [SerializeField] public GameObject _arrow12;
    [SerializeField] public GameObject _arrow13;
    [SerializeField] public GameObject _arrow21;
    [SerializeField] public GameObject _arrow22;
    [SerializeField] public GameObject _arrow23;
    [SerializeField] public GameObject _arrow24;
    [SerializeField] public GameObject _arrow25;

    [SerializeField] private GameObject _arrowdiraction1;
    [SerializeField] private GameObject _arrowdiraction2;
    [SerializeField] private GameObject _arrowdiraction3;
    [SerializeField] private GameObject _arrowdiraction4;

    [SerializeField] private SelectRoomUi _selectRoom;

    private int _numbRoom = 1;
    private int _numbRand;

    private string _level;
    private List<KeyValuePair<string, MarkovLink>> _markovLevel = new List<KeyValuePair<string, MarkovLink>>();
    private string _lastRoom = "C";

    private int _numSelectNv1;
    private int _numSelectNv21;
    private int _numSelectNv22;
    private int _numSelectNv23;
    private bool _nvGenerate;

    public int NumSelectNv1 => _numSelectNv1;
    public int NumSelectNv21 => _numSelectNv21;

    public int NumSelectNv22 => _numSelectNv22;

    public int NumSelectNv23 => _numSelectNv23;

    #endregion

    void Start()
    {
        CreatCondition();
        CreatRun();
        GenerateRoom();
    }

    private void CreatCondition()
    {
        _markovLevel.Add(new KeyValuePair<string, MarkovLink>("C", new MarkovLink("C", 3)));
        _markovLevel.Add(new KeyValuePair<string, MarkovLink>("C", new MarkovLink("I", 2)));
        _markovLevel.Add(new KeyValuePair<string, MarkovLink>("C", new MarkovLink("H", 3)));

        _markovLevel.Add(new KeyValuePair<string, MarkovLink>("H", new MarkovLink("C", 3)));
        _markovLevel.Add(new KeyValuePair<string, MarkovLink>("H", new MarkovLink("I")));
        _markovLevel.Add(new KeyValuePair<string, MarkovLink>("H", new MarkovLink("H")));

        _markovLevel.Add(new KeyValuePair<string, MarkovLink>("I", new MarkovLink("C", 3)));
        _markovLevel.Add(new KeyValuePair<string, MarkovLink>("I", new MarkovLink("I")));
        _markovLevel.Add(new KeyValuePair<string, MarkovLink>("I", new MarkovLink("H")));
    }

    public void CreatRun()
    {
        do
        {
            ResetRun();
            _numSelectNv1 = 0;
            _numSelectNv21 = 0;
            _numSelectNv22 = 0;
            _numSelectNv23 = 0;

            _numbRand = Random.Range(1, 3);
            if (_numbRand == 1)
            {
                _nv11.SetActive(true);
                _arrow11.SetActive(true);
                _numSelectNv1++;
            }

            _numbRand = Random.Range(1, 3);
            if (_numbRand == 1)
            {
                _nv12.SetActive(true);
                _arrow12.SetActive(true);
                _numSelectNv1++;
            }

            _numbRand = Random.Range(1, 3);
            if (_numbRand == 1)
            {
                _nv13.SetActive(true);
                _arrow13.SetActive(true);
                _numSelectNv1++;
            }

            if (_nv11.activeSelf)
            {
                _numbRand = Random.Range(1, 3);
                if (_numbRand == 1)
                {
                    _nv111.SetActive(true);
                    _arrow21.SetActive(true);
                }

                _numbRand = Random.Range(1, 3);
                if (_numbRand == 1 && !_nv112_121.activeSelf)
                {
                    _nv112_121.SetActive(true);
                    _arrowdiraction1.SetActive(true);
                    _arrow22.SetActive(true);
                    if (_nv12.activeSelf && !_arrowdiraction2.activeSelf)
                    {
                        _arrowdiraction2.SetActive(true);
                    }
                }
                else if (_nv112_121.activeSelf)
                {
                    _arrowdiraction1.SetActive(true);
                    _arrow22.SetActive(true);
                    if (_nv12.activeSelf && !_arrowdiraction2.activeSelf)
                    {
                        _arrowdiraction2.SetActive(true);
                    }
                }
            }

            if (_nv12.activeSelf)
            {
                _numbRand = Random.Range(1, 3);
                if (_numbRand == 1 && !_nv112_121.activeSelf)
                {
                    _nv112_121.SetActive(true);
                    _arrowdiraction2.SetActive(true);
                    _arrow22.SetActive(true);
                    if (_nv11.activeSelf && !_arrowdiraction1.activeSelf)
                    {
                        _arrowdiraction1.SetActive(true);
                    }
                }
                else if (_nv112_121.activeSelf)
                {
                    _arrowdiraction2.SetActive(true);
                    _arrow22.SetActive(true);
                    if (_nv11.activeSelf && !_arrowdiraction1.activeSelf)
                    {
                        _arrowdiraction1.SetActive(true);
                    }
                }

                _numbRand = Random.Range(1, 3);
                if (_numbRand == 1)
                {
                    _nv122.SetActive(true);
                    _arrow23.SetActive(true);
                }

                _numbRand = Random.Range(1, 3);
                if (_numbRand == 1 && !_nv123_131.activeSelf)
                {
                    _nv123_131.SetActive(true);
                    _arrowdiraction3.SetActive(true);
                    _arrow24.SetActive(true);
                    if (_nv13.activeSelf && !_arrowdiraction3.activeSelf)
                    {
                        _arrowdiraction3.SetActive(true);
                    }
                }
                else if (_nv123_131.activeSelf)
                {
                    _arrowdiraction3.SetActive(true);
                    _arrow24.SetActive(true);
                    if (_nv13.activeSelf && !_arrowdiraction3.activeSelf)
                    {
                        _arrowdiraction3.SetActive(true);
                    }
                }
            }

            if (_nv13.activeSelf)
            {
                _numbRand = Random.Range(1, 3);
                if (_numbRand == 1 && !_nv123_131)
                {
                    _nv123_131.SetActive(true);
                    _arrowdiraction4.SetActive(true);
                    _arrow24.SetActive(true);
                    if (_nv12.activeSelf && !_arrowdiraction3.activeSelf)
                    {
                        _arrowdiraction3.SetActive(true);
                    }
                }
                else if (_nv123_131.activeSelf)
                {
                    _arrowdiraction4.SetActive(true);
                    _arrow24.SetActive(true);
                    if (_nv12.activeSelf && !_arrowdiraction3.activeSelf)
                    {
                        _arrowdiraction3.SetActive(true);
                    }
                }

                _numbRand = Random.Range(1, 3);
                if (_numbRand == 1)
                {
                    _nv132.SetActive(true);
                    _arrow25.SetActive(true);
                }
            }
        } while (!((_nv111.activeSelf && _nv11.activeSelf) ||
                   (_nv112_121.activeSelf && _nv11.activeSelf) ||
                   (_nv112_121.activeSelf && _nv12.activeSelf) ||
                   (_nv122.activeSelf && _nv12.activeSelf) ||
                   (_nv123_131.activeSelf && _nv12.activeSelf) ||
                   (_nv123_131.activeSelf && _nv13.activeSelf) ||
                   (_nv132.activeSelf && _nv13.activeSelf)));

        if (!(_nv111.activeSelf || _nv112_121.activeSelf) && _nv11.activeSelf)
        {
            _nv11.SetActive(false);
            _arrow11.SetActive(false);
            _numSelectNv1--;
        }

        if (!(_nv112_121.activeSelf || _nv122.activeSelf || _nv123_131.activeSelf) && _nv12.activeSelf)
        {
            _nv12.SetActive(false);
            _arrow12.SetActive(false);
            _numSelectNv1--;
        }

        if (!(_nv123_131.activeSelf || _nv132.activeSelf) && _nv13.activeSelf)
        {
            _nv13.SetActive(false);
            _arrow13.SetActive(false);
            _numSelectNv1--;
        }

        switch (_nv11.activeSelf)
        {
            case true:
                if (_nv111.activeSelf && _nv112_121.activeSelf)
                {
                    _numSelectNv21 += 2;
                    break;
                }
                else if (_nv111.activeSelf || _nv112_121.activeSelf)
                {
                    _numSelectNv21++;
                    break;
                }
                else
                {
                    Debug.LogWarning("Erreur");
                    break;
                }
            case false:
                Debug.Log("Pas de Route 1");
                break;
        }
        switch (_nv12.activeSelf)
        {
            case true:
                if (_nv112_121.activeSelf && _nv122.activeSelf && _nv123_131.activeSelf)
                {
                    _numSelectNv22 += 3;
                    break;
                }
                else if (_nv112_121.activeSelf && _nv122.activeSelf || _nv112_121.activeSelf && _nv123_131.activeSelf || _nv122.activeSelf && _nv123_131.activeSelf)
                {
                    _numSelectNv22 += 2;
                    break;
                }
                else if (_nv112_121.activeSelf || _nv122.activeSelf || _nv123_131.activeSelf)
                {
                    _numSelectNv22++;
                    break;
                }
                else
                {
                    Debug.LogWarning("Erreur");
                    break;
                }
            case false:
                Debug.Log("Pas de Route 2");
                break;
        }
        switch (_nv13.activeSelf)
        {
            case true:
                if (_nv123_131.activeSelf && _nv132.activeSelf)
                {
                    _numSelectNv23 += 2;
                    break;
                }
                else if (_nv123_131.activeSelf || _nv132.activeSelf)
                {
                    _numSelectNv23++;
                    break;
                }
                else
                {
                    Debug.LogWarning("Erreur");
                    break;
                }
            case false:
                Debug.Log("Pas de Route 3");
                break;
        }
    }

    public void ResetRun()
    {
        _selectRoom.Generate = false;
        _nv11.SetActive(false);
        _arrow11.SetActive(false);
        _nv12.SetActive(false);
        _arrow12.SetActive(false);
        _nv13.SetActive(false);
        _arrow13.SetActive(false);
        _nv111.SetActive(false);
        _arrow21.SetActive(false);
        _nv112_121.SetActive(false);
        _arrow22.SetActive(false);
        _nv122.SetActive(false);
        _arrow23.SetActive(false);
        _nv123_131.SetActive(false);
        _arrow24.SetActive(false);
        _nv132.SetActive(false);
        _arrow25.SetActive(false);
        _arrowdiraction1.SetActive(false);
        _arrowdiraction2.SetActive(false);
        _arrowdiraction3.SetActive(false);
        _arrowdiraction4.SetActive(false);
    }

    public void ResetRoom()
    {
        _11H.SetActive(false);
        _11C.SetActive(false);
        _11I.SetActive(false);
        _12H.SetActive(false);
        _12C.SetActive(false);
        _12I.SetActive(false);
        _13H.SetActive(false);
        _13C.SetActive(false);
        _13I.SetActive(false);
        _111H.SetActive(false);
        _111C.SetActive(false);
        _111I.SetActive(false);
        _112_121H.SetActive(false);
        _112_121C.SetActive(false);
        _112_121I.SetActive(false);
        _122H.SetActive(false);
        _122C.SetActive(false);
        _122I.SetActive(false);
        _123_131H.SetActive(false);
        _123_131C.SetActive(false);
        _123_131I.SetActive(false);
        _132H.SetActive(false);
        _132C.SetActive(false);
        _132I.SetActive(false);
    }

    public void GenerateRoom()
    {
        ResetRoom();

        if (_nv11.activeSelf)
        {
            Generate();
            if (_level == "C")
                _11C.SetActive(true);
            if (_level == "H")
                _11H.SetActive(true);
            if (_level == "I")
                _11I.SetActive(true);
        }

        if (_nv12.activeSelf)
        {
            Generate();
            if (_level == "C")
                _12C.SetActive(true);
            if (_level == "H")
                _12H.SetActive(true);
            if (_level == "I")
                _12I.SetActive(true);
        }

        if (_nv13.activeSelf)
        {
            Generate();
            if (_level == "C")
                _13C.SetActive(true);
            if (_level == "H")
                _13H.SetActive(true);
            if (_level == "I")
                _13I.SetActive(true);
        }

        if (_nv111.activeSelf)
        {
            Generate();
            if (_level == "C")
                _111C.SetActive(true);
            if (_level == "H")
                _111H.SetActive(true);
            if (_level == "I")
                _111I.SetActive(true);
        }

        if (_nv112_121.activeSelf)
        {
            Generate();
            if (_level == "C")
                _112_121C.SetActive(true);
            if (_level == "H")
                _112_121H.SetActive(true);
            if (_level == "I")
                _112_121I.SetActive(true);
        }

        if (_nv122.activeSelf)
        {
            Generate();
            if (_level == "C")
                _122C.SetActive(true);
            if (_level == "H")
                _122H.SetActive(true);
            if (_level == "I")
                _122I.SetActive(true);
        }

        if (_nv123_131.activeSelf)
        {
            Generate();
            if (_level == "C")
                _123_131C.SetActive(true);
            if (_level == "H")
                _123_131H.SetActive(true);
            if (_level == "I")
                _123_131I.SetActive(true);
        }

        if (_nv132.activeSelf)
        {
            Generate();
            if (_level == "C")
                _132C.SetActive(true);
            if (_level == "H")
                _132H.SetActive(true);
            if (_level == "I")
                _132I.SetActive(true);
        }
    }

    public void Generate()
    {
        string _currentName = _lastRoom;
        List<KeyValuePair<string, MarkovLink>> _AvailableNames = new List<KeyValuePair<string, MarkovLink>>();

        _level = _currentName;
        _numbRoom = 2;

        do
        {
            _AvailableNames = _markovLevel
                .Where(n => n.Key == _currentName)
                .OrderByDescending(n => n.Value.Weight)
                .ToList();

            int sumWeights = _AvailableNames.Sum(n => n.Value.Weight);

            if (_AvailableNames.Count > 0)
            {
                int idxElement = Random.Range(0, sumWeights);
                int partialsum = 0;

                foreach (var AvailableNames in _AvailableNames)
                {
                    partialsum += AvailableNames.Value.Weight;
                    if (idxElement < partialsum)
                    {
                        //AvailableNames;
                        _currentName = AvailableNames.Value.Level;
                        break;
                    }
                }

                _numbRoom--;
                _lastRoom = _currentName;
                //Debug.Log(_lastRoom + " lastRoom");
                _level = _currentName;
            }
        } while (_numbRoom > 0);

        //Debug.Log(_level + " _level");
    }

    #endregion
}