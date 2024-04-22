using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
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
    [SerializeField] private GameObject _generator;
    [SerializeField] private GeneratorNv _generatorNv;
    [SerializeField] private SelectRoomUi _selectRoomUi;
    private int _roomPassed;
    private bool _item;
    private bool _heal;
    private bool _boss;


    // Start is called before the first frame update

    public void Test()
    {
        resetRoom();
        RoomSelect();
    }

    public void NextRoom()
    {
        resetRoom();
        if (_roomPassed < 5 && !_item && !_heal && !_boss)
        {
            RoomSelect();
        }
        else if (_roomPassed < 5 && !_boss && !_heal)
        {
            RoomSelect();
        }
        else if (_roomPassed < 5 && !_boss && !_item)
        {
            RoomSelect();
        }
        else if (_roomPassed < 5 && !_item && !_heal)
        {
            RoomSelect();
        }
        else
        {
            _roomPassed = 0;
            _item = false;
            _heal = false;
            _boss = false;
            _selectRoomUi.RoomEnd();
            _generator.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void RoomSelect()
    {
        if (((_generatorNv._nv11Room == "C" && _selectRoomUi.Selector11.activeSelf
              || _generatorNv._nv12Room == "C" && _selectRoomUi.Selector12.activeSelf ||
              _generatorNv._nv13Room == "C" && _selectRoomUi.Selector13.activeSelf) && _selectRoomUi._LevelSelect == 1)
            ||
            (_generatorNv._nv111Room == "C" && _selectRoomUi.Selector21.activeSelf && _selectRoomUi._LevelSelect == 2)
            ||
            (_generatorNv._nv122Room == "C" && _selectRoomUi.Selector23.activeSelf && _selectRoomUi._LevelSelect == 3)
            ||
            (_generatorNv._nv132Room == "C" && _selectRoomUi.Selector25.activeSelf && _selectRoomUi._LevelSelect == 4)
            ||
            (_generatorNv._nv112_121Room == "C" && _selectRoomUi.Selector22.activeSelf &&
             (_selectRoomUi._LevelSelect == 2 || _selectRoomUi._LevelSelect == 3))
            ||
            (_generatorNv._nv123_131Room == "C" && _selectRoomUi.Selector24.activeSelf &&
             (_selectRoomUi._LevelSelect == 3 || _selectRoomUi._LevelSelect == 4)))
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

            _roomPassed++;
        }

        if (((_generatorNv._nv11Room == "I" && _selectRoomUi.Selector11.activeSelf
              || _generatorNv._nv12Room == "I" && _selectRoomUi.Selector12.activeSelf ||
              _generatorNv._nv13Room == "I" && _selectRoomUi.Selector13.activeSelf) && _selectRoomUi._LevelSelect == 1)
            ||
            (_generatorNv._nv111Room == "I" && _selectRoomUi.Selector21.activeSelf && _selectRoomUi._LevelSelect == 2)
            ||
            (_generatorNv._nv122Room == "I" && _selectRoomUi.Selector23.activeSelf && _selectRoomUi._LevelSelect == 3)
            ||
            (_generatorNv._nv132Room == "I" && _selectRoomUi.Selector25.activeSelf && _selectRoomUi._LevelSelect == 4)
            ||
            (_generatorNv._nv112_121Room == "I" && _selectRoomUi.Selector22.activeSelf &&
             (_selectRoomUi._LevelSelect == 2 || _selectRoomUi._LevelSelect == 3))
            ||
            (_generatorNv._nv123_131Room == "I" && _selectRoomUi.Selector24.activeSelf &&
             (_selectRoomUi._LevelSelect == 3 || _selectRoomUi._LevelSelect == 4)))
        {
            _roomItem.SetActive(true);
            _roomPassed += 5;
            _item = true;
        }

        if (((_generatorNv._nv11Room == "H" && _selectRoomUi.Selector11.activeSelf
              || _generatorNv._nv12Room == "H" && _selectRoomUi.Selector12.activeSelf ||
              _generatorNv._nv13Room == "H" && _selectRoomUi.Selector13.activeSelf) && _selectRoomUi._LevelSelect == 1)
            ||
            (_generatorNv._nv111Room == "H" && _selectRoomUi.Selector21.activeSelf && _selectRoomUi._LevelSelect == 2)
            ||
            (_generatorNv._nv122Room == "H" && _selectRoomUi.Selector23.activeSelf && _selectRoomUi._LevelSelect == 3)
            ||
            (_generatorNv._nv132Room == "H" && _selectRoomUi.Selector25.activeSelf && _selectRoomUi._LevelSelect == 4)
            ||
            (_generatorNv._nv112_121Room == "H" && _selectRoomUi.Selector22.activeSelf &&
             (_selectRoomUi._LevelSelect == 2 || _selectRoomUi._LevelSelect == 3))
            ||
            (_generatorNv._nv123_131Room == "H" && _selectRoomUi.Selector24.activeSelf &&
             (_selectRoomUi._LevelSelect == 3 || _selectRoomUi._LevelSelect == 4)))
        {
            _roomItem.SetActive(true);
            _roomPassed += 5;
            _heal = true;
        }

        if (_selectRoomUi.SelectorBoss.activeSelf && _selectRoomUi._LevelSelect == 5)
        {
            _roomBoss.SetActive(true);
            _roomPassed += 5;
            _boss = true;
        }
    }

    private int TirageRand()
    {
        _roomNum = Random.Range(1, 17);
        return _roomNum;
    }

    private void resetRoom()
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