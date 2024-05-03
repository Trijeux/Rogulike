using System;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif
    public class StartAssetInputPlayer : MonoBehaviour
    {
        public float walk;
        public float jump;
        public float attack;
        public float caste;
        public float pause;
        
#if ENABLE_INPUT_SYSTEM
        public void OnWalk(InputValue value)
        {
            WalkInput(value.Get<float>());
        }

        public void OnJump(InputValue value)
        {
            JumpInput(value.Get<float>());
        }
        
        public void OnAttack(InputValue value)
        {
            AttackInput(value.Get<float>());
        }
        
        public void OnCaste(InputValue value)
        {
            CasteInput(value.Get<float>());
        }

        public void OnPause(InputValue value)
        {
           PauseInput(value.Get<float>());
        }
#endif
        public void WalkInput(float newWalkDirection)
        {
            walk = newWalkDirection;
        }

        public void JumpInput(float newJump)
        {
            jump = newJump;
        }
        
        public void AttackInput(float newAttack)
        {
            attack = newAttack;
        }
        
        public void CasteInput(float newCaste)
        {
            caste = newCaste;
        }

        public void PauseInput(float newPause)
        {
            pause = newPause;
        }
    }