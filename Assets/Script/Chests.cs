using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : MonoBehaviour
{
    public GameObject[] randomCharacters;
    private GameObject[] temp;
    private int rdm;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Add();
        }
    }

    void Add()
    {
        rdm = Random.Range(0, randomCharacters.Length);
        temp = new GameObject[CharacterList.charactersStatic.Length + 1];
        for (int i = 0; i < CharacterList.charactersStatic.Length; i++)
        {
            temp[i] = CharacterList.charactersStatic[i];
        }
        temp[temp.Length - 1] = randomCharacters[rdm];

        CharacterList.charactersStatic = new GameObject[temp.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            CharacterList.charactersStatic[i] = temp[i];
        }
    }

}
