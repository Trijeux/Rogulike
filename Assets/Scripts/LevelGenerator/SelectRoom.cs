
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
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _UiPlayer;
    private int _roomPassed;
    private bool _item;
    private bool _heal;
    private bool _boss;

    private bool temp = true;

    private GameObject _roomEnd;


    // Start is called before the first frame update

    public void Test()
    {
        RoomSelect();
    }

    public void NextRoom()
    {
        if (_roomPassed < 5 && !_item && !_heal && !_boss)
        {
            Destroy(_roomEnd);
            RoomSelect();
        }
        else if (_roomPassed < 5 && !_boss && !_heal)
        {
            Destroy(_roomEnd);
            RoomSelect();
        }
        else if (_roomPassed < 5 && !_boss && !_item)
        {
            Destroy(_roomEnd);
            RoomSelect();
        }
        else if (_roomPassed < 5 && !_item && !_heal)
        {
            Destroy(_roomEnd);
            RoomSelect();
        }
        else
        {
            Destroy(_roomEnd);
            _roomPassed = 0;
            _item = false;
            _heal = false;
            _boss = false;
            _selectRoomUi.RoomEnd();
            _generator.SetActive(true);
            _player.SetActive(false);
            _UiPlayer.SetActive(false);
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
                    _roomEnd = Instantiate(_room1 , gameObject.transform);
                    break;
                case 2:
                     _roomEnd = Instantiate(_room2, gameObject.transform);
                    break;
                case 3:
                     _roomEnd = Instantiate(_room3, gameObject.transform);
                    break;
                case 4:
                     _roomEnd = Instantiate(_room4, gameObject.transform);
                    break;
                case 5:
                     _roomEnd = Instantiate(_room5, gameObject.transform);
                    break;
                case 6:
                     _roomEnd = Instantiate(_room6, gameObject.transform);
                    break;
                case 7:
                     _roomEnd = Instantiate(_room7, gameObject.transform);
                    break;
                case 8:
                    Debug.Log("Room Select");
                    _roomPassed--;
                    RoomSelect();
                    //_room8.SetActive(true);
                    break;
                case 9:
                     _roomEnd = Instantiate(_room9, gameObject.transform);
                    break;
                case 10:
                     _roomEnd = Instantiate(_room10, gameObject.transform);
                    break;
                case 11:
                    Debug.Log("Room Select");
                    _roomPassed--;
                    RoomSelect();
                    break;
                case 12:
                     _roomEnd = Instantiate(_room12, gameObject.transform);
                    break;
                case 13:
                     _roomEnd = Instantiate(_room13, gameObject.transform);
                    break;
                case 14:
                     _roomEnd = Instantiate(_room14, gameObject.transform);
                    break;
                case 15:
                    Debug.Log("Room Select");
                    _roomPassed--;
                    RoomSelect();
                    break;
                case 16:
                     _roomEnd = Instantiate(_room16, gameObject.transform);
                    break;
            }

            _roomPassed++;
            Debug.Log("Room passed " + _roomPassed);
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
             _roomEnd = Instantiate(_roomItem, gameObject.transform);
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
             _roomEnd = Instantiate(_roomItem, gameObject.transform);
            _roomPassed += 5;
            _heal = true;
        }

        if (_selectRoomUi.SelectorBoss.activeSelf && _selectRoomUi._LevelSelect == 5)
        {
             _roomEnd = Instantiate(_roomBoss, gameObject.transform);
            _roomPassed += 5;
            _boss = true;
        }
    }

    private int TirageRand()
    {
        _roomNum = Random.Range(1, 17);
        if (temp)
        {
            _roomNum = 8;
            temp = false;
        }
        return _roomNum;
    }
}