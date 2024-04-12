using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkovLink : MonoBehaviour
{
    public MarkovLink(string level, int weight = 1)
    {
        _level = level;
        _weight = weight;
    }

    private string _level;
    private int _weight;

    public string Level => _level;

    public int Weight => _weight;
}