using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectionBoss
{
    Right,
    Left
}
public class Boss : MonoBehaviour
{
    private StartAssetInputPlayer _player;
    [SerializeField] private List<GameObject> _spawnerRoch;
    [SerializeField] private GameObject _bossPotition1;
    [SerializeField] private GameObject _bossPotition2;
    [SerializeField] private Animator _bossAnim;
    [SerializeField] private GameObject _rochPrefab;
    [SerializeField] [Range(0.1f, 5f)] private float _timeAttack;
    [SerializeField] [Range(0.1f, 5f)] private float _spawnTime;
    [SerializeField] [Range(0.1f, 5f)] private float _timeRush;
    private DirectionBoss _direction = DirectionBoss.Left;
    [SerializeField][Range(0.1f , 10f)] public float _deplacementDuration = 5f;
    [SerializeField] private bool _isDead;
    [SerializeField] private HitEnnemie _hit;
    [SerializeField] private bool _cooldown;
    [SerializeField] private int life;
    [SerializeField] private GameObject Victoire;
    [SerializeField] private GameObject LifeBoss;
    private bool _start = true;


    public int Life => life;


    // Start is called before the first frame update
    void Start()
    {
        _player = FindFirstObjectByType<StartAssetInputPlayer>();
        StartCoroutine(BossSequence());
    }

    // Update is called once per frame
    void Update()
    {
        if (_hit.IsHit && !_cooldown)
        {
            _cooldown = true;
            life--;
            _bossAnim.SetBool("IsHit", true);
            StartCoroutine(CoolDownHit());
        }

        if (life <= 0)
        {
            Victoire.SetActive(true);
            LifeBoss.SetActive(false);
            Destroy(gameObject);
        }
    }

    IEnumerator BossSequence()
    {
        do
        {
            if (_start)
            {
                yield return new WaitForSeconds(2f);
                _start = false;
            }
            yield return new WaitForSeconds(_timeAttack);
            _bossAnim.SetFloat("Attack", 1);
            yield return new WaitForSeconds(0.2f);
            _bossAnim.SetFloat("Attack", 0);
            switch (_direction)
            {
                case DirectionBoss.Left:
                    for (int i = 0; i < _spawnerRoch.Count; i++)
                    {
                        yield return new WaitForSeconds(_spawnTime);
                        Instantiate(_rochPrefab, _spawnerRoch[i].transform.position, Quaternion.identity);
                    }
                    break;
                case DirectionBoss.Right:
                    for (int i = _spawnerRoch.Count; i > 0 ; i--)
                    {
                        yield return new WaitForSeconds(_spawnTime);
                        Instantiate(_rochPrefab, _spawnerRoch[i - 1].transform.position, Quaternion.identity);
                    }
                    break;
            }
            yield return new WaitForSeconds(_timeRush);
            _bossAnim.SetBool("Rush", true);
            yield return new WaitForSeconds(0.5f);
            Vector3 destination;
            if (_direction == DirectionBoss.Left)
            {
                destination = _bossPotition2.transform.position;
            }
            else
            {
                destination = _bossPotition1.transform.position;
            }

            // Interpolation linéaire pour déplacer le boss de sa position actuelle à la destination
            float elapsedTime = 0f;
            Vector3 startPosition = transform.position;
            while (elapsedTime < _deplacementDuration)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / _deplacementDuration);
                transform.position = Vector3.Lerp(startPosition, destination, t);
                yield return null;
            }
            _direction = (_direction == DirectionBoss.Left) ? DirectionBoss.Right : DirectionBoss.Left;
            if (_direction == DirectionBoss.Left)
            {
                
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            _bossAnim.SetBool("Rush", false);
        } while (!_isDead);
    }
    IEnumerator CoolDownHit()
    {
        yield return new WaitForSeconds(1f);
        _bossAnim.SetBool("IsHit", false);
        yield return new WaitForSeconds(1f);
        _cooldown = false;
    }
}
