
using System.Collections.Generic;


public class MarkovNode
{
    private string _level;

    private List<MarkovNode> _nextNodes;

    public MarkovNode(string _nodeLevel)
    {
        _level = _nodeLevel;
        _nextNodes = new List<MarkovNode>();
    }
    
    public void AddNode(string _nodeLevel)
    {
        if (_nextNodes != null)
        {
            _nextNodes.Add(new MarkovNode(_nodeLevel));
        }
    }

}