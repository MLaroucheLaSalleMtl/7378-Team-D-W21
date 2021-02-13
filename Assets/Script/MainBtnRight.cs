using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBtnRight : MonoBehaviour
{
    public Button btnStart;
    public Button btnSetting;
    public Button btnEnd;

    public void ButtonChange()
    {

        if (btnStart.isActiveAndEnabled)
        {
            btnStart.gameObject.SetActive(false);
            btnSetting.gameObject.SetActive(true);
            btnEnd.gameObject.SetActive(false);
        }
        else if (btnSetting.isActiveAndEnabled)
        {
            btnStart.gameObject.SetActive(false);
            btnSetting.gameObject.SetActive(false);
            btnEnd.gameObject.SetActive(true);
        }
        else if (btnEnd.isActiveAndEnabled)
        {
            btnStart.gameObject.SetActive(true);
            btnSetting.gameObject.SetActive(false);
            btnEnd.gameObject.SetActive(false);
        }
    }
}

