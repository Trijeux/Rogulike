
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private StartAssetInputPlayer _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindFirstObjectByType<StartAssetInputPlayer>();
        _player.transform.position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
