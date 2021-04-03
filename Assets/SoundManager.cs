using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip pickcoin;
    public static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        pickcoin = Resources.Load<AudioClip>("getcoin");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaypickcoinClip() 
    { 
     audioSrc.PlayOneShot(pickcoin);
    
    }
   
}
