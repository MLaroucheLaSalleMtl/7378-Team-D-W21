using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class ShowUp : MonoBehaviour
{
    public GameObject showObj;

    public void Show()
    {
         showObj.gameObject.SetActive(true);
    }
}
