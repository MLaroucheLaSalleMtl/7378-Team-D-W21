using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterList : MonoBehaviour
{
    public GameObject characterlist;
    public GameObject[] characters;
    private GameObject[] temp;
    Vector2 spawnSpace;

    int characterCount;

    public static GameObject[] charactersStatic;

    // Start is called before the first frame update
    void Start()
    {
        SetCharacter();
        characterCount = characters.Length;
        temp = new GameObject[characters.Length - 1];
        charactersStatic = new GameObject[characters.Length];
        for (int i = 0; i < characters.Length; i++)
        {
            charactersStatic[i] = characters[i];
        }
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
        Debug.Log("GG");
    }
}
