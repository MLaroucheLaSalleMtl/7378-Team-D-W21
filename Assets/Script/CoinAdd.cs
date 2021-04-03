using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAdd : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            SoundManager.PlaypickcoinClip();
            CoinManger.instance.AddCoin();
            Destroy(this.gameObject);
        }
    }
}
