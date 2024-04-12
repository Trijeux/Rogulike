using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif
public class StartAssetInputUi : MonoBehaviour
{
    public float upDown;
    public float valide;
    public float cancel;
        
#if ENABLE_INPUT_SYSTEM
    public void OnUP_Down(InputValue value)
    {
        UpDawnInput(value.Get<float>());
    }

    public void OnValider(InputValue value)
    {
        ValideInput(value.Get<float>());
    }

    public void OnCancel(InputValue value)
    {
        CancelInput(value.Get<float>());
    }
#endif

    public void UpDawnInput(float newUpDown)
    {
        upDown = newUpDown;
    }

    public void ValideInput(float newValide)
    {
        valide = newValide;
    }

    public void CancelInput(float newCancel)
    {
        cancel = newCancel;
    }
}