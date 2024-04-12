using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class SelectRoom : MonoBehaviour
{
    [SerializeField] private GameObject _room1;
    [SerializeField] private GameObject _room2;
    [SerializeField] private GameObject _room3;
    [SerializeField] private GameObject _room4;
    [SerializeField] private GameObject _room5;
    [SerializeField] private GameObject _room6;
    [SerializeField] private GameObject _room7;
    [SerializeField] private GameObject _room8;
    [SerializeField] private GameObject _room9;
    [SerializeField] private GameObject _room10;
    [SerializeField] private GameObject _room11;
    [SerializeField] private GameObject _room12;
    [SerializeField] private GameObject _room13;
    [SerializeField] private GameObject _room14;
    [SerializeField] private GameObject _room15;
    [SerializeField] private GameObject _room16;
    [SerializeField] private GameObject _roomBoss;
    [SerializeField] private GameObject _roomItem;
    private int _roomNum;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Test()
    {
        reset();
        RoomSelect();
    }

    private void RoomSelect()
    {
        switch (TirageRand())
        {
            case 1:
                _room1.SetActive(true);
                break;
            case 2:
                _room2.SetActive(true);
                break;
            case 3:
                _room3.SetActive(true);
                break;
            case 4:
                _room4.SetActive(true);
                break;
            case 5:
                _room5.SetActive(true);
                break;
            case 6:
                _room6.SetActive(true);
                break;
            case 7:
                _room7.SetActive(true);
                break;
            case 8:
                _room8.SetActive(true);
                break;
            case 9:
                _room9.SetActive(true);
                break;
            case 10:
                _room10.SetActive(true);
                break;
            case 11:
                _room11.SetActive(true);
                break;
            case 12:
                _room12.SetActive(true);
                break;
            case 13:
                _room13.SetActive(true);
                break;
            case 14:
                _room14.SetActive(true);
                break;
            case 15:
                _room15.SetActive(true);
                break;
            case 16:
                _room16.SetActive(true);
                break;
            
        }
    }

    private int TirageRand()
    {
        _roomNum = Random.Range(1,17);
        return _roomNum;
    }

    private void reset()
    {
        _room1.SetActive(false);
        _room2.SetActive(false);
        _room3.SetActive(false);
        _room4.SetActive(false);
        _room5.SetActive(false);
        _room6.SetActive(false);
        _room7.SetActive(false);
        _room8.SetActive(false);
        _room9.SetActive(false);
        _room10.SetActive(false);
        _room11.SetActive(false);
        _room12.SetActive(false);
        _room13.SetActive(false);
        _room14.SetActive(false);
        _room15.SetActive(false);
        _room16.SetActive(false);
        _roomBoss.SetActive(false);
        _roomItem.SetActive(false);
    }
}
