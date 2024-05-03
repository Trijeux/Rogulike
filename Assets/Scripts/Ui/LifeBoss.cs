using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class LifeBoss : MonoBehaviour
{
    private Boss _boss;
    [SerializeField] private GameObject _life4;
    [SerializeField] private GameObject _life3;
    [SerializeField] private GameObject _life2;
    [SerializeField] private GameObject _life1;
    [SerializeField] private GameObject _life0;
    
    // Start is called before the first frame update
    void Start()
    {
        _boss = FindFirstObjectByType<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_boss.Life)
        {
            case 0 :
                _life0.SetActive(true);
                _life1.SetActive(false);
                break;
            case 1 :
                _life0.SetActive(false);
                _life1.SetActive(true);
                _life2.SetActive(false);
                break;
            case 2 :
                _life1.SetActive(false);
                _life2.SetActive(true);
                _life3.SetActive(false);
                break;
            case 3 :
                _life2.SetActive(false);
                _life3.SetActive(true);
                _life4.SetActive(false);
                break;
            case 4 :
                _life3.SetActive(false);
                _life4.SetActive(true);
                break;
        }
    }
}
