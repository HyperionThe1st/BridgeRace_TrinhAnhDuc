using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject winPopUp;
    [SerializeField] GameObject joyStickPopUp;
    private void Awake()
    {
        ShowWinPopUp(false);
        ShowJoyStickPopUp(true);
    }
    public void ShowWinPopUp(bool isTrue)
    {
        winPopUp.SetActive(isTrue);
    }
    public void ShowJoyStickPopUp(bool isTrue)
    {
        joyStickPopUp.SetActive(isTrue);
    }

}
