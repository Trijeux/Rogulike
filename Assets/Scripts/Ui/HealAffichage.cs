
using UnityEngine;

public class HealAffichage : MonoBehaviour
{
    [SerializeField] private GameObject Heart0;
    [SerializeField] private GameObject Heart1;
    [SerializeField] private GameObject Heart2;
    [SerializeField] private GameObject Heart3;
    [SerializeField] private GameObject Heart4;
    [SerializeField] private GameObject Heart5;
    [SerializeField] private GameObject Heart6;
    private StatsPlayer _player;

    private void Start()
    {
        AllDesactive();
        _player = FindFirstObjectByType<StatsPlayer>();
    }

    void Update()
    {
        switch (_player.Life)
        {
            case 6:
                Heart6.SetActive(true);
                Heart5.SetActive(false);
                break;
            case 5:
                Heart5.SetActive(true);
                Heart6.SetActive(false);
                Heart4.SetActive(false);
                break;
            case 4:
                Heart4.SetActive(true);
                Heart5.SetActive(false);
                Heart3.SetActive(false);
                break;
            case 3:
                Heart3.SetActive(true);
                Heart4.SetActive(false);
                Heart2.SetActive(false);
                break;
            case 2:
                Heart2.SetActive(true);
                Heart3.SetActive(false);
                Heart1.SetActive(false);
                break;
            case 1:
                Heart1.SetActive(true);
                Heart2.SetActive(false);
                Heart0.SetActive(false);
                break;
            case 0: 
                Heart0.SetActive(true);
                Heart1.SetActive(false);
                break;
        }
    }

    private void AllDesactive()
    {
        Heart0.SetActive(false);
        Heart1.SetActive(false);
        Heart2.SetActive(false);
        Heart3.SetActive(false);
        Heart4.SetActive(false);
        Heart5.SetActive(false);
        Heart6.SetActive(false);
    }
}
