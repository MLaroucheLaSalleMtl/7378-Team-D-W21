using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryAnimation : MonoBehaviour
{
    public GameObject aGO;

    private void AfterDeath()
    {
        Destroy(aGO.gameObject);
    }
}
