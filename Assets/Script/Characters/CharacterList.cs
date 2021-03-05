using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterList : MonoBehaviour
{
    private GameManager gm;//0305
    public GameObject characterlist;
    public GameObject[] characters;
    private GameObject[] temp;
    Vector2 spawnSpace;

    public Text numberOfSoilders;

    int characterCount;

    public static GameObject[] charactersStatic;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;//0305
        SetCharacter();
        characterCount = characters.Length;
        temp = new GameObject[characters.Length - 1];
        charactersStatic = new GameObject[characters.Length];
        for (int i = 0; i < characters.Length; i++)
        {
            charactersStatic[i] = characters[i];
        }
        numberOfSoilders.text = characterCount + " soilder left";
    }

    // Update is called once per frame
    void Update()
    {
        if (characters.Length !=0)
        {
            Kill();
            if (characterCount > characters.Length && characterCount > 1)
            {
                //Debug.Log(characterCount);
                SetCharacter();
                characterCount = characters.Length;
            }
            else if (characters.Length < charactersStatic.Length)
            {
                Add();
            }
        }
        else if (characters.Length == 0)
        {
            EndGame();
        }
        numberOfSoilders.text = characterCount + " soilder left";

        //if (characterCount > characters.Length) 
        //{
        //    SetCharacter();
        //    characterCount = characters.Length;
        //}
        //else if (characters.Length < charactersStatic.Length)
        //{
        //    Add();
        //}


    }

    void SetCharacter()
    {
        spawnSpace = new Vector2(transform.position.x, transform.position.y);
        GameObject character = Instantiate(characters[0], spawnSpace, Quaternion.identity);
        if (gm.spawnPoint != null)//0305
        {
            character.transform.position = gm.spawnPoint.transform.position;
        }//0305
        //GameObject character = Instantiate(characters[0], gm.spawnPoint.transform.position, Quaternion.identity);//0305
        character.transform.parent = characterlist.transform;
    }

    void Kill()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length < 1)
        {
            temp = new GameObject[characters.Length - 1];

            for (int i = 0; i < characters.Length - 1; i++)
            {
                temp[i] = characters[i + 1];
            }

            characters = new GameObject[temp.Length];

            for (int i = 0; i < temp.Length; i++)
            {
                characters[i] = temp[i];
            }

            charactersStatic = new GameObject[characters.Length];

            for (int i = 0; i < temp.Length; i++)
            {
                charactersStatic[i] = characters[i];
            }
        }

        //if (Input.GetKeyDown(KeyCode.Z) && temp.Length>1)
        //{
        //    temp = new GameObject[characters.Length - 1];

        //    for (int i = 0; i < characters.Length-1; i++)
        //    {
        //        temp[i] = characters[i + 1];
        //    }

        //    characters = new GameObject[temp.Length];  

        //    for (int i = 0; i < temp.Length; i++)
        //    {
        //        characters[i] = temp[i];
        //    }

        //    charactersStatic = new GameObject[characters.Length];

        //    for (int i = 0; i < temp.Length; i++)
        //    {
        //        charactersStatic[i] = characters[i];
        //    }
        //}
    }

    void Add()
    {
        characters = new GameObject[charactersStatic.Length];

        for (int i = 0; i < charactersStatic.Length; i++)
        {
            characters[i] = charactersStatic[i];
        }

        characterCount = characters.Length;

    }

    void Load()
    {

    }

    void EndGame()
    {
        SceneManager.LoadScene("GameBase");
    }
}
