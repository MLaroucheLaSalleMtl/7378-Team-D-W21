using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour {

	public GameObject duiHuaPanel;
	public Text duiTxt;


	//NPC
	public string[] npcYan;
	//Hero
	public string[] heroYan;

	bool heroSay = true;
	int heroyanIndex = 0;
	int npcYanIndex = 1;

	public static DialogBox instance;
	void Start () {
		instance = this;

		//Test
		//ShowDuiHuaPanel();
	}

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
			ShowDuiHuaPanel();
        }
    } 

    public void ShowDuiHuaPanel()
	{
		duiHuaPanel.SetActive(true);
		duiTxt.text = npcYan.GetValue(0).ToString();
	}

	public void HideDuiHuaPanel()
	{
		duiHuaPanel.SetActive(false);
	}

	public void ClickNextButton()
	{
		if (heroSay)
		{
			duiTxt.text = "";
			duiTxt.text = heroYan.GetValue(heroyanIndex).ToString();
			heroyanIndex++;
			
			if(heroyanIndex==heroYan.Length)
            {
				Invoke("HideDuiHuaPanel", 1f);
            }
			heroSay = false;
			
		}else
        {
			duiTxt.text = "";
			duiTxt.text = npcYan.GetValue(npcYanIndex).ToString();
			npcYanIndex++;
			
			heroSay = true;
        }
	}
}
