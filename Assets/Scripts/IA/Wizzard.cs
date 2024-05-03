using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Wizzard : MonoBehaviour
{
    private SpriteRenderer _sr;
    private StartAssetInputPlayer _player;
    private WizzardFire _wizzardFire;
    private TpForWizzard _tpForWizzard;
    private int _numbtp;
    private int _numAction;
    [SerializeField] private Animator _tpWizzard;
    [SerializeField] private Animator _tpDestination;
    [SerializeField] private Animator _casteWizzard;
    [SerializeField] private GameObject _tpDestinationTransform;
    [SerializeField] [Range(0.1f, 5f)] private float _WahtForChose;
    [SerializeField] [Range(0.1f, 5f)] private float _tpTemp;
    [SerializeField] [Range(0.1f, 5f)] private float _casteTemp;
    [FormerlySerializedAs("_kill")] [SerializeField] private HitEnnemie hit;
    [SerializeField] private GameObject IsDead;
    [SerializeField] [Range(0.1f, 5f)] private float _isDeadTime;
    [SerializeField] private GameObject _sprite;
    [SerializeField] private float _life;
    [SerializeField] private bool _cooldown;
    [SerializeField] private AudioSource _hit;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindFirstObjectByType<StartAssetInputPlayer>();
        _sr = GetComponent<SpriteRenderer>();
        _wizzardFire = GetComponent<WizzardFire>();
        //Debug.Log(_player.transform.position);
        _tpForWizzard = FindFirstObjectByType<TpForWizzard>();
        StartCoroutine(WizarrdSequence());
    }

    private void Teleport()
    {
        _numbtp = Random.Range(0, _tpForWizzard.TpList.Count);
        _tpDestinationTransform.transform.position = _tpForWizzard.TpList[_numbtp].transform.position;
        _tpWizzard.SetFloat("TpWizzard", 1);
        _tpDestination.SetFloat("TpDestination", 1);
        //Debug.Log(_numbtp);
    }

    private void Update()
    {
        if (_player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        
        if (hit.IsHit && !_cooldown)
        {
            _hit.Play();
            StopCoroutine(WizarrdSequence());
            _casteWizzard.SetBool("Hit", true);
            _cooldown = true;
            _life--;
            StartCoroutine(CoolDownHit());
            if (_life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator WizarrdSequence()
    {
        Debug.Log("Coroutine started");

        // Attend une seconde
        do
        {
            yield return new WaitForSeconds(_WahtForChose);
            _numAction = Random.Range(1, 3);
            switch (_numAction)
            {
                case 1:
                    Teleport();
                    yield return new WaitForSeconds(_tpTemp);
                    _tpWizzard.SetFloat("TpWizzard", 0);
                    _tpDestination.SetFloat("TpDestination", 0);
                    gameObject.transform.position = _tpForWizzard.TpList[_numbtp].transform.position;
                    break;
                case 2:
                    _casteWizzard.SetFloat("Caste", 1);
                    yield return new WaitForSeconds(_casteTemp);
                    _casteWizzard.SetFloat("Caste", 0);
                    _wizzardFire.Shoot();
                    break;
                default:
                    Debug.Log("Erreur");
                    break;
            }
        } while (!hit.IsHit);
    }
    IEnumerator CoolDownHit()
    {
        yield return new WaitForSeconds(1f);
        _hit.Stop();
        StartCoroutine(WizarrdSequence());
        Teleport();
        _casteWizzard.SetBool("Hit", false);
        yield return new WaitForSeconds(1f);
        _cooldown = false;
    }
}