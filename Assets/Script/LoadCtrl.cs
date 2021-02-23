using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadCtrl : MonoBehaviour {

	public string scenceName = "";
	public Slider ccSlider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ccSlider.value += Time.deltaTime;
		if(ccSlider.value>=ccSlider.maxValue)
        {
			//Application.LoadLevel(scenceName);
        }
	}
}
