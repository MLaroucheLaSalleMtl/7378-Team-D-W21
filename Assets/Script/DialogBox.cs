using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour {

	public GameObject duiHuaPanel;
	public Text duiTxt;

	public Transform heroPos;

	

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
		
		if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(heroPos.position, this.transform.position) <= 1.5f)
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
		heroyanIndex = 0;
		npcYanIndex = 1;
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

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag =="Player")
        {
			this.gameObject.transform.Find("F").GetComponent<SpriteRenderer>().enabled = true;
        }
	}
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			this.gameObject.transform.Find("F").GetComponent<SpriteRenderer>().enabled = false;
		}
	}
	
}