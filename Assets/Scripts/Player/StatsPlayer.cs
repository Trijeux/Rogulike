
using UnityEngine;

public class StatsPlayer : MonoBehaviour
{
    [SerializeField] private int _maxLife;
    [SerializeField] private int _maxMana;
    private int _life;
    private int _mana;

    public int Mana
    {
        get => _mana;
        set => _mana = value;
    }

    public int Life
    {
        get => _life;
        set => _life = value;
    }

    public int MaxLife => _maxLife;

    // Start is called before the first frame update
    void Start()
    {
        
        _life = _maxLife;
        _mana = _maxMana;
    }
}