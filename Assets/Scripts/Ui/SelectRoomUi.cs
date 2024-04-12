using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class SelectRoomUi : MonoBehaviour
{
    [SerializeField] private Animator _selectArrow11;
    [SerializeField] private Animator _selectArrow12;
    [SerializeField] private Animator _selectArrow13;
    [SerializeField] private Animator _selectArrow21;
    [SerializeField] private Animator _selectArrow22;
    [SerializeField] private Animator _selectArrow23;
    [SerializeField] private Animator _selectArrow24;
    [SerializeField] private Animator _selectArrow25;
    [SerializeField] private Animator _selectArrowBoss;
    [SerializeField] private GeneratorNv _generatorNv;
    [SerializeField] private StartAssetInputUi _input;
    [SerializeField] private bool InputDown;
    [SerializeField] private bool InputValide;
    private int _selector1;
    private int _selector21;
    private int _selector22;
    private int _selector23;
    private int _niveauSelectorPart = 1;
    private int _selectorNv;
    private bool _generate;

    public bool Generate
    {
        set => _generate = value;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!_generate)
        {
            _selector1 = _generatorNv.NumSelectNv1;
            _selector21 = _generatorNv.NumSelectNv21;
            _selector22 = _generatorNv.NumSelectNv22;
            _selector23 = _generatorNv.NumSelectNv23;
            _selectorNv = 1;
            _generate = true;
            Debug.Log("NV1 : " + _selector1 + " / " + "NV2-1 : " + _selector21 + " / " + "NV2-2 : " + _selector22 +
                      " / " + "NV2-3 : " + _selector23);
        }

        Selection1();
        AnimArrow();
    }

    private void Selection1()
    {
        switch (_niveauSelectorPart)
        {
            case 1:
                if (_input.upDown < 0 && !InputDown)
                {
                    _selectorNv--;
                    if (_selectorNv <= 0)
                    {
                        _selectorNv = _selector1;
                    }

                    InputDown = true;
                }

                if (_input.upDown > 0 && !InputDown)
                {
                    _selectorNv++;
                    if (_selectorNv > _selector1)
                    {
                        _selectorNv = 1;
                    }

                    InputDown = true;
                }

                if (_input.upDown == 0)
                {
                    InputDown = false;
                }

                if (_input.valide > 0 && !InputValide)
                {
                    if (_generatorNv._arrow11.activeSelf && _generatorNv._arrow12.activeSelf &&
                        _generatorNv._arrow13.activeSelf)
                    {
                        switch (_selectorNv)
                        {
                            case 1:
                                _niveauSelectorPart = 2;
                                break;
                            case 2:
                                _niveauSelectorPart = 3;
                                break;
                            case 3:
                                _niveauSelectorPart = 4;
                                break;
                            default:
                                Debug.Log("Erreur");
                                break;
                        }
                    }
                    else if (_generatorNv._arrow11.activeSelf && _generatorNv._arrow12.activeSelf)
                    {
                        switch (_selectorNv)
                        {
                            case 1:
                                _niveauSelectorPart = 2;
                                break;
                            case 2:
                                _niveauSelectorPart = 3;
                                break;
                            default:
                                Debug.Log("Erreur");
                                break;
                        }
                    }
                    else if (_generatorNv._arrow11.activeSelf && _generatorNv._arrow13.activeSelf)
                    {
                        switch (_selectorNv)
                        {
                            case 1:
                                _niveauSelectorPart = 2;
                                break;
                            case 2:
                                _niveauSelectorPart = 4;
                                break;
                            default:
                                Debug.Log("Erreur");
                                break;
                        }
                    }
                    else if (_generatorNv._arrow12.activeSelf && _generatorNv._arrow13.activeSelf)
                    {
                        switch (_selectorNv)
                        {
                            case 1:
                                _niveauSelectorPart = 3;
                                break;
                            case 2:
                                _niveauSelectorPart = 4;
                                break;
                            default:
                                Debug.Log("Erreur");
                                break;
                        }
                    }
                    else if (_generatorNv._arrow11.activeSelf)
                    {
                        _niveauSelectorPart = 2;
                    }
                    else if (_generatorNv._arrow12.activeSelf)
                    {
                        _niveauSelectorPart = 3;
                    }
                    else if (_generatorNv._arrow13.activeSelf)
                    {
                        _niveauSelectorPart = 4;
                    }

                    InputValide = true;
                    ResetAnim();
                    _selectorNv = 1;
                }

                if (_input.valide == 0)
                {
                    InputValide = false;
                }

                break;
            case 2:
                if (_input.upDown < 0 && !InputDown)
                {
                    _selectorNv--;
                    if (_selectorNv <= 0)
                    {
                        _selectorNv = _selector21;
                    }

                    InputDown = true;
                }

                if (_input.upDown > 0 && !InputDown)
                {
                    _selectorNv++;
                    if (_selectorNv > _selector21)
                    {
                        _selectorNv = 1;
                    }

                    InputDown = true;
                }

                if (_input.upDown == 0)
                {
                    InputDown = false;
                }

                if (_input.valide > 0)
                {
                    ResetAnim();
                    _niveauSelectorPart = 5;
                }
                
                if (_input.valide == 0 && !InputValide)
                {
                    InputValide = false;
                    InputValide = true;
                }

                break;
            case 3:
                if (_input.upDown < 0 && !InputDown)
                {
                    _selectorNv--;
                    if (_selectorNv <= 0)
                    {
                        _selectorNv = _selector22;
                    }

                    InputDown = true;
                }

                if (_input.upDown > 0 && !InputDown)
                {
                    _selectorNv++;
                    if (_selectorNv > _selector22)
                    {
                        _selectorNv = 1;
                    }

                    InputDown = true;
                }

                if (_input.upDown == 0)
                {
                    InputDown = false;
                }
                
                if (_input.valide > 0 && !InputValide)
                {
                    ResetAnim();
                    InputValide = true;
                    _niveauSelectorPart = 5;
                }
                
                if (_input.valide == 0)
                {
                    InputValide = false;
                }

                break;
            case 4:
                if (_input.upDown < 0 && !InputDown)
                {
                    _selectorNv--;
                    if (_selectorNv <= 0)
                    {
                        _selectorNv = _selector23;
                    }

                    InputDown = true;
                }

                if (_input.upDown > 0 && !InputDown)
                {
                    _selectorNv++;
                    if (_selectorNv > _selector23)
                    {
                        _selectorNv = 1;
                    }

                    InputDown = true;
                }

                if (_input.upDown == 0)
                {
                    InputDown = false;
                }
                
                if (_input.valide > 0 && !InputValide)
                {
                    ResetAnim();
                    _niveauSelectorPart = 5;
                    InputValide = true;
                }
                
                if (_input.valide == 0)
                {
                    InputValide = false;
                }
                
                break;
            case 5:
                if (_input.valide > 0 && !InputValide)
                {
                    Debug.Log("Salle Boss");
                    InputValide = true;
                }
                
                if (_input.valide == 0)
                {
                    InputValide = false;
                }
                break;
            default:
                Debug.Log("Erreur");
                break;
        }
    }

    private void AnimArrow()
    {
        switch (_niveauSelectorPart)
        {
            case 1:
                switch (_selectorNv)
                {
                    case 1:
                        if (_generatorNv._arrow11.activeSelf)
                        {
                            _selectArrow11.SetFloat("Select", 1);
                            _selectArrow12.SetFloat("Select", 0);
                            _selectArrow13.SetFloat("Select", 0);
                        }
                        else if (_generatorNv._arrow12.activeSelf)
                        {
                            _selectArrow11.SetFloat("Select", 0);
                            _selectArrow12.SetFloat("Select", 1);
                            _selectArrow13.SetFloat("Select", 0);
                        }
                        else if (_generatorNv._arrow13.activeSelf)
                        {
                            _selectArrow11.SetFloat("Select", 0);
                            _selectArrow12.SetFloat("Select", 0);
                            _selectArrow13.SetFloat("Select", 1);
                        }

                        break;
                    case 2:
                        if (_generatorNv._arrow12.activeSelf && _generatorNv._arrow11.activeSelf)
                        {
                            _selectArrow11.SetFloat("Select", 0);
                            _selectArrow12.SetFloat("Select", 1);
                            _selectArrow13.SetFloat("Select", 0);
                        }
                        else if (_generatorNv._arrow13.activeSelf)
                        {
                            _selectArrow11.SetFloat("Select", 0);
                            _selectArrow12.SetFloat("Select", 0);
                            _selectArrow13.SetFloat("Select", 1);
                        }

                        break;
                    case 3:
                        if (_generatorNv._arrow13.activeSelf && _generatorNv._arrow12.activeSelf &&
                            _generatorNv._arrow11.activeSelf)
                        {
                            _selectArrow11.SetFloat("Select", 0);
                            _selectArrow12.SetFloat("Select", 0);
                            _selectArrow13.SetFloat("Select", 1);
                        }

                        break;
                    default:
                        Debug.LogWarning("Erreur d'UI");
                        break;
                }
                break;
            case 2:
                switch (_selectorNv)
                {
                    case 1:
                        if (_generatorNv._arrow21.activeSelf)
                        {
                            _selectArrow21.SetFloat("Select", 1);
                            _selectArrow22.SetFloat("Select", 0);
                        }
                        else if (_generatorNv._arrow12.activeSelf)
                        {
                            _selectArrow21.SetFloat("Select", 0);
                            _selectArrow22.SetFloat("Select", 1);
                        }

                        break;
                    case 2:
                        if (_generatorNv._arrow22.activeSelf && _generatorNv._arrow21.activeSelf)
                        {
                            _selectArrow21.SetFloat("Select", 0);
                            _selectArrow22.SetFloat("Select", 1);
                        }

                        break;
                    default:
                        Debug.LogWarning("Erreur d'UI");
                        break;
                }
                break;
            case 3:
                switch (_selectorNv)
                {
                    case 1:
                        if (_generatorNv._arrow22.activeSelf)
                        {
                            _selectArrow22.SetFloat("Select", 1);
                            _selectArrow23.SetFloat("Select", 0);
                            _selectArrow24.SetFloat("Select", 0);
                        }
                        else if (_generatorNv._arrow23.activeSelf)
                        {
                            _selectArrow22.SetFloat("Select", 0);
                            _selectArrow23.SetFloat("Select", 1);
                            _selectArrow24.SetFloat("Select", 0);
                        }
                        else if (_generatorNv._arrow24.activeSelf)
                        {
                            _selectArrow22.SetFloat("Select", 0);
                            _selectArrow23.SetFloat("Select", 0);
                            _selectArrow24.SetFloat("Select", 1);
                        }

                        break;
                    case 2:
                        if (_generatorNv._arrow23.activeSelf && _generatorNv._arrow22.activeSelf)
                        {
                            _selectArrow22.SetFloat("Select", 0);
                            _selectArrow23.SetFloat("Select", 1);
                            _selectArrow24.SetFloat("Select", 0);
                        }
                        else if (_generatorNv._arrow24.activeSelf)
                        {
                            _selectArrow22.SetFloat("Select", 0);
                            _selectArrow23.SetFloat("Select", 0);
                            _selectArrow24.SetFloat("Select", 1);
                        }

                        break;
                    case 3:
                        if (_generatorNv._arrow24.activeSelf && _generatorNv._arrow23.activeSelf &&
                            _generatorNv._arrow22.activeSelf)
                        {
                            _selectArrow22.SetFloat("Select", 0);
                            _selectArrow23.SetFloat("Select", 0);
                            _selectArrow24.SetFloat("Select", 1);
                        }

                        break;
                    default:
                        Debug.LogWarning("Erreur d'UI");
                        break;
                }
                break;
            case 4:
                switch (_selectorNv)
                {
                    case 1:
                        if (_generatorNv._arrow24.activeSelf)
                        {
                            _selectArrow24.SetFloat("Select", 1);
                            _selectArrow25.SetFloat("Select", 0);
                        }
                        else if (_generatorNv._arrow25.activeSelf)
                        {
                            _selectArrow24.SetFloat("Select", 0);
                            _selectArrow25.SetFloat("Select", 1);
                        }

                        break;
                    case 2:
                        if (_generatorNv._arrow25.activeSelf && _generatorNv._arrow24.activeSelf)
                        {
                            _selectArrow24.SetFloat("Select", 0);
                            _selectArrow25.SetFloat("Select", 1);
                        }

                        break;
                    default:
                        Debug.LogWarning("Erreur d'UI");
                        break;
                }
                break;
            case 5:
                _selectArrowBoss.SetFloat("Select", 1);
                break;
        }
    }

    private void ResetAnim()
    {
        _selectArrow11.SetFloat("Select", 0);
        _selectArrow12.SetFloat("Select", 0);
        _selectArrow13.SetFloat("Select", 0);
        _selectArrow21.SetFloat("Select", 0);
        _selectArrow22.SetFloat("Select", 0);
        _selectArrow23.SetFloat("Select", 0);
        _selectArrow24.SetFloat("Select", 0);
        _selectArrow25.SetFloat("Select", 0);
        _selectArrowBoss.SetFloat("Select", 0);
    }
}