using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class NameLoad : MonoBehaviour {
    public Text usrName;
    public string nome;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        string[] line = File.ReadAllLines(GetPathToList());
       // print(line[0]);
        usrName = GameObject.Find("Text").GetComponent<Text>();
        usrName.text = line[0];
        print(usrName.text);
      


        
    }

    public string GetPathToList()
    {
        string path = null;
        try
        {
            // Caminho para arquivo contendo o nome de todas as fichas adcionadas a "sessão"
            return "Assets/Resources/Atual.txt";
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        return path;

    }

    public void WriteCharacterName(string name)
    {
        //Escreve o nome de um personagem na lista contendo os personagens de uma seção
        string path = GetPathToList();
        //File.AppendAllText(path, name + Environment.NewLine);
        File.WriteAllText("Assets/Resources/Atual.txt", name);

    }
}
