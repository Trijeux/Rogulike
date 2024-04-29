using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpForWizzard : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> _tpList; 
    public List<GameObject> TpList => _tpList;
    

    // Start is called before the first frame update
    void Start()
    {
        _tpList.Clear();
        if (gameObject != null)
        {
            Transform parentTransform = gameObject.transform;

            for (int i = 0; i < parentTransform.childCount; i++)
            {
                Transform childTransform = parentTransform.GetChild(i);
                GameObject childObject = childTransform.gameObject;

                _tpList.Add(childObject);
            }

            foreach (GameObject child in _tpList)
            {
                Debug.Log("Enfant trouvé : " + child.name);
            }
        }
        else
        {
            Debug.LogWarning("La référence au parentObject n'est pas définie.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
