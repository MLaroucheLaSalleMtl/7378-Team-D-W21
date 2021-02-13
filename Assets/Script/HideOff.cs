using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOff : MonoBehaviour
{
    public GameObject showObj;

    public void Hide()
    {
        showObj.gameObject.SetActive(false);
    }
}
