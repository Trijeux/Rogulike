using System.Collections;

using UnityEngine;
using UnityEngine.Serialization;

public class CharacterControllerAnimation : MonoBehaviour
{
    [SerializeField] private StartAssetInputPlayer _input;
    [SerializeField] private CharacterController2D _isGrounded;
    [SerializeField] private Animator _animatorPlayer;
    [SerializeField] private Animator _animatorSpelle;
    [SerializeField] private Animator _animatorHand;
    [SerializeField] private GameObject _hand;
    [SerializeField] private GameObject _sword;
    [SerializeField] private Animator _animatorSword;

    [FormerlySerializedAs("_state")] [SerializeField]
    private StatsPlayer stats;

    [SerializeField] private GameObject _attack;

    #region Temp

    [Header("Temp")] [SerializeField] private bool IsHit;
    [SerializeField] private bool PlayerQuit;
    [SerializeField] private bool CasteOn;
    [SerializeField] [Range(0.1f, 5f)] private float _tempAttack;
    [SerializeField] private bool attackOn = true;
    [SerializeField] [Range(0.1f, 5f)] private float _tempCaste;
    [SerializeField] private bool _caste;
    [SerializeField] private GameObject _gameOver;
    private bool isDead = false;

    public bool Caste => _caste;

    public bool IsHit1
    {
        get => IsHit;
        set => IsHit = value;
    }

    #endregion

    void Update()
    {
        if (stats.Life <= 0)
        {
            stats.Life = 0;
            _animatorPlayer.SetBool("Walk", false);
            _animatorPlayer.SetBool("Jump", false);
            _animatorPlayer.SetBool("Fall", false);
            _animatorPlayer.SetBool("IsHit", false);
            _animatorPlayer.SetBool("Attack", false);
            _animatorPlayer.SetBool("Caste", false);
            if (!isDead)
            {
                _animatorPlayer.SetBool("IsDead", true);
                isDead = true;
            }
            _gameOver.SetActive(true);
            _hand.SetActive(false);
            _sword.SetActive(false);
            StartCoroutine(CoolDownDead());
            
        }
        else
        {
            _animatorPlayer.SetBool("IsDead", false);
        }

        if (PlayerQuit)
        {
            _animatorPlayer.SetBool("PlayerNoVisibility", true);
        }
        else
        {
            _animatorPlayer.SetBool("PlayerNoVisibility", false);
        }


        if (stats.Life > 0)
        {
            if (Mathf.Abs(_input.walk) > 0f)
            {
                _animatorPlayer.SetBool("Walk", true);
                _animatorHand.SetBool("Walk", true);
                _animatorSword.SetBool("Walk", true);
            }
            else
            {
                _animatorPlayer.SetBool("Walk", false);
                _animatorHand.SetBool("Walk", false);
                _animatorSword.SetBool("Walk", false);
            }

            if (_input.jump >= 0.1 && _isGrounded.IsGrounded)
            {
                _animatorPlayer.SetBool("Jump", true);
                _animatorHand.SetBool("Jump", true);
                _animatorSword.SetBool("Jump", true);
            }
            else if (_isGrounded.IsGrounded)
            {
                _animatorPlayer.SetBool("Jump", false);
                _animatorHand.SetBool("Jump", false);
                _animatorSword.SetBool("Jump", false);
            }
        }

        if (!_caste)
        {
            if (stats.Life > 0)
            {
                if (!_isGrounded.IsGrounded)
                {
                    _animatorPlayer.SetBool("Fall", true);
                    _animatorHand.SetBool("Fall", true);
                    _animatorSword.SetBool("Fall", true);
                }
                else
                {
                    _animatorPlayer.SetBool("Fall", false);
                    _animatorHand.SetBool("Fall", false);
                    _animatorSword.SetBool("Fall", false);
                }

                if (IsHit)
                {
                    _animatorPlayer.SetBool("IsHit", true);
                    _animatorHand.SetBool("IsHit", true);
                    _animatorSword.SetBool("IsHit", true);
                    IsHit = false;
                }
                else
                {
                    _animatorPlayer.SetBool("IsHit", false);
                    _animatorHand.SetBool("IsHit", false);
                    _animatorSword.SetBool("IsHit", false);
                }

                if (_input.attack >= 0.1 && attackOn)
                {
                    attackOn = false;
                    StartCoroutine(AttackCoolDown());
                    _animatorPlayer.SetBool("Attack", true);
                    _animatorHand.SetBool("Attack", true);
                    _animatorSword.SetBool("Attack", true);
                }
                else
                {
                    _animatorPlayer.SetBool("Attack", false);
                    _animatorHand.SetBool("Attack", false);
                    _animatorSword.SetBool("Attack", false);
                }

                if (_input.caste >= 0.1 && !CasteOn && stats.Mana > 0)
                {
                    _animatorPlayer.SetBool("Caste", true);
                    _animatorHand.SetBool("Caste", true);
                    _animatorSword.SetBool("Caste", true);
                    _animatorSpelle.SetBool("Caste", true);
                    stats.Mana--;
                    _caste = true;
                    CasteOn = true;
                    StartCoroutine(CastCoolDown());
                }
                else
                {
                    _animatorPlayer.SetBool("Caste", false);
                    _animatorHand.SetBool("Caste", false);
                    _animatorSword.SetBool("Caste", false);
                    _animatorSpelle.SetBool("Caste", false);
                }
            }
        }
    }

    IEnumerator CastCoolDown()
    {
        yield return new WaitForSeconds(_tempCaste);
        _caste = false;
        yield return new WaitForSeconds(3f);
        CasteOn = false;
    }

    IEnumerator AttackCoolDown()
    {
        _attack.SetActive(true);
        yield return new WaitForSeconds(_tempAttack);
        attackOn = true;
        _attack.SetActive(false);
    }
    
    IEnumerator CoolDownDead()
    {
        yield return new WaitForSeconds(0.5f);
        _animatorPlayer.SetBool("IsDead", false);
        yield return new WaitForSeconds(4f);
        Application.Quit();
    }
}