using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum Direction
{
    Right,
    Left
}

public class Samurai : MonoBehaviour
{
    private SpriteRenderer _sr;
    private StartAssetInputPlayer _player;
    private TpForSamurai _tpForSamurai;
    [SerializeField] private Detector _detectorPlayer;
    [SerializeField] private float stoppingDistance = 2f;
    private int _samuraiCountTempTp = 0;
    private Direction _direction;
    private CenterMap _centerMap;
    private Vector2 _transformPlayer;
    [SerializeField] private float _tempSlash;
    [SerializeField] private GameObject _slash;
    private int _numAction;
    [SerializeField] private bool _tempIsDead = true;
    private int _numbtp;
    private bool _attackOn;
    [SerializeField] private GameObject _Sprit;
    [SerializeField] private Animator _animatorSamurai;
    [SerializeField] private Animator _animatorTp;
    [SerializeField] [Range(0.1f, 5f)] private float _afterAttack;
    [SerializeField] [Range(0.1f, 5f)] private float _attackCoolDown;
    [SerializeField] [Range(0.1f, 5f)] private float _disparitionCoolDown;
    [SerializeField] [Range(0.1f, 5f)] private float _InvisibilityCoolDown;
    [SerializeField] [Range(0.1f, 5f)] private float _aparitionCoolDown;
    public float TempSlash => _tempSlash;
    public StartAssetInputPlayer Player => _player;

    public bool AttackOn
    {
        get => _attackOn;
        set => _attackOn = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        _player = FindFirstObjectByType<StartAssetInputPlayer>();
        _tpForSamurai = FindFirstObjectByType<TpForSamurai>();
        _sr = GetComponent<SpriteRenderer>();
        _centerMap = FindFirstObjectByType<CenterMap>();
        _detectorPlayer = FindFirstObjectByType<Detector>();
        StartCoroutine(SamuraiSequence());
    }

    void Update()
    {
        if (!_attackOn)
        {
            if (transform.position.x > _centerMap.transform.position.x)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y,
                    transform.localScale.z);
                _direction = Direction.Right;
            }
            else
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y,
                    transform.localScale.z);
                _direction = Direction.Left;
            }
        }
    }

    private void Teleport()
    {
        _numbtp = Random.Range(0, _tpForSamurai.TpList.Count);
        gameObject.transform.position = _tpForSamurai.TpList[_numbtp].transform.position;
    }

    private void Attack()
    {
        float playerX = _player.transform.position.x;
        Vector3 newPosition = gameObject.transform.position;
        Vector3 spawnPosition = new Vector3(playerX, gameObject.transform.position.y - 0.4f, -1f);
        switch (_direction)
        {
            case Direction.Left:
                newPosition.x = playerX + stoppingDistance;
                break;
            case Direction.Right:
                newPosition.x = playerX - stoppingDistance;
                break;
        }
        gameObject.transform.position = newPosition;
        Instantiate(_slash, spawnPosition, _player.transform.rotation);
    }

    IEnumerator SamuraiSequence()
    {
        do
        {
            if (_attackOn)
            {
                _samuraiCountTempTp = 0;
                _detectorPlayer.gameObject.SetActive(false);
                _animatorSamurai.SetBool("Attaque",true);
                yield return new WaitForSeconds(_attackCoolDown);
                _animatorSamurai.SetBool("Attaque",false);
                Attack();
                _attackOn = false;
                yield return new WaitForSeconds(_afterAttack);
                _animatorTp.SetBool("Diparition", true);
                yield return new WaitForSeconds(_disparitionCoolDown);
                _Sprit.gameObject.SetActive(false);
                _animatorTp.SetBool("Diparition", false);
                yield return new WaitForSeconds(_InvisibilityCoolDown);
                Teleport();
                _animatorTp.SetBool("Apparition", true);
                yield return new WaitForSeconds(_aparitionCoolDown);
                _Sprit.gameObject.SetActive(true);
                _animatorTp.SetBool("Apparition", false);
                _detectorPlayer.gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(1f);
            _samuraiCountTempTp++;
            if (_samuraiCountTempTp >= 10)
            {
                Teleport();
                _samuraiCountTempTp = 0;
            }
        } while (_tempIsDead);
    }
}