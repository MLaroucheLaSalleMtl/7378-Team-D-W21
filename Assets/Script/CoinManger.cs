using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManger : MonoBehaviour
{
    public static CoinManger instance;
    public Text coinTxt;
    private int coinCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void AddCoin()
    {
        coinCount++;
        coinTxt.text = coinCount.ToString();
    }
}
