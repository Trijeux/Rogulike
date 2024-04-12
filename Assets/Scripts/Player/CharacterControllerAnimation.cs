using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterControllerAnimation : MonoBehaviour
{
    [SerializeField] private StartAssetInputPlayer _input;
    [SerializeField] private CharacterController2D _isGrounded;
    [SerializeField] private Animator _animatorPlayer;
    [SerializeField] private Animator _animatorSpelle;
    [SerializeField] private Animator _animatorHand;
    [SerializeField] private Animator _animatorSword;
    private bool _deadOn = true;

    #region Temp
    [Header("Temp")]
    [SerializeField] private bool IsDead;
    [SerializeField] private bool IsHit;
    [SerializeField] private bool PlayerQuit;
    [SerializeField] private int NumbCasteMax;
    [SerializeField] private bool CasteOn;

    #endregion

    void Update()
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

        if (IsDead)
        {
            if (_deadOn)
            {
                _animatorPlayer.SetBool("IsDead", true);
                _deadOn = false;
                IsDead = false;
            }
        }
        else
        {
            _animatorPlayer.SetBool("IsDead", false);
            _deadOn = true;
            if (PlayerQuit)
            {
                _animatorPlayer.SetBool("PlayerNoVisibility", true);
            }
            else
            {
                _animatorPlayer.SetBool("PlayerNoVisibility", false);
            }
        }

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
        }
        else
        {
            _animatorPlayer.SetBool("IsHit", false);
            _animatorHand.SetBool("IsHit", false);
            _animatorSword.SetBool("IsHit", false);
        }

        if (_input.attack >= 0.1)
        {
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
        
        if (_input.caste >= 0.1 && !CasteOn)
        {
            if (NumbCasteMax > 0)
            {
                _animatorPlayer.SetBool("Caste", true);
                _animatorHand.SetBool("Caste", true);
                _animatorSword.SetBool("Caste", true);
                _animatorSpelle.SetBool("Caste", true);
                NumbCasteMax--;
            }
            CasteOn = true;
        }
        else if (_input.caste <= 0)
        {
            CasteOn = false;
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