using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class loadAndReadTxt : MonoBehaviour
{
    
    public InputField field;
    
    // Use this for initialization
    void Start()
    {

       

    }

    // Update is called once per frame
    void Update()
    {

    }
    public string GetPathToList()
    {
        string path = null;
        try
        {
            // Caminho para arquivo contendo o nome de todas as fichas adcionadas a "sessão"
            return "Assets/Resources/Fichas.txt";
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        return path;
        
    }

    public string GetPathToSheet(string name)
    {
        string path = null;
        try
        {
            // Caminho para arquivo contendo a ficha de um personagem com o nome especificado
            path =  "Assets/Resources/" + name + ".txt";
        } catch (Exception e)
        {
            Debug.Log(e);
        }
        return path;

    }
    

    public string[] ReadFile(string path)
    {
        // Lê o arquivo especificado
        return File.ReadAllLines(path);
    }
    public void NameDefine()
    {
        field = GameObject.Find("CampoBusca").GetComponent<InputField>();
        
        AddCharacterSheetToList(field.text);
    }
    public void AddCharacterSheetToList(string name)
    {
        try
        {
            List<String> text = new List<String>();
            string path = GetPathToSheet(name); // Define o caminho (relativo) para o arquivo da ficha do personagem
            ShowCharacterSheet(name);
            WriteCharacterSheet(name);
            GameObject.Find("LogText").GetComponent<Text>().text = "OK! Adcionado";
        } catch (Exception e)
        {
            GameObject.Find("LogText").GetComponent<Text>().text = "Não há ficha com esse nome na pasta";
            Debug.LogError(e);
        }
    }

    public void ShowCharacterSheet(string name)
    {
        string path = GetPathToSheet(name);
        string[] lines = ReadFile(path);
        Text boxText = GameObject.Find("CharInfo").GetComponent<Text>();
        string allText="";
        foreach (string info in lines)
        {
            allText += " " + info;
        }
        boxText.text = allText;

    }

    public void WriteCharacterSheet(string name)
    {
        //Escreve o nome de um personagem na lista contendo os personagens de uma seção
        string path = GetPathToList();
        File.AppendAllText(path, name + Environment.NewLine);
    }


    public void WriteCharacterName(string name)
    {
        //Escreve o nome de um personagem na lista contendo os personagens de uma seção
        string path = GetPathToList();
        File.AppendAllText(path, name + Environment.NewLine);
        File.WriteAllText("Assets/Resources/Atual.txt", name);

    }

    public void RemoveCharacter(string name)
    {
        try
        {
           
            string path = GetPathToList();
            string[] lines = ReadFile(path);
            List<string> list = new List<string>(lines);
            int i = list.FindIndex(x => x == name);
            list.RemoveAt(i);
            GameObject.Find("LogText").GetComponent<Text>().text = "OK! Removido";
            string[] newList = list.ToArray();
            File.WriteAllLines(path, newList);
        } catch (Exception e)
        {
            GameObject.Find("LogText").GetComponent<Text>().text = "Não há elemento na lista com esse nome";
            Debug.LogError(e);
        }
    }

    public List<string> GetCharData(string name)
    {
        //Retorna todas os atributos de uma ficha (personagem)
        string path = GetPathToSheet(name); 
        List<string> list = new List<string>();
        string[] lines = File.ReadAllLines(path);
        string[] substrings;
        Char delimiter = ':';
        foreach (string line in lines)
        {
            // para cada linha do arquivo, ou seja, para cada atributo, é criado um substring que é adcionada no array text
            substrings = line.Split(delimiter);
            list.Add(substrings[1]);
        }
       
        return list;
    }

    public List<string> GetAllCharNames()
    {
        //Retorna todos os nomes contidos na lista de personagens na sessão
        string path = GetPathToList();
        string[] lines = ReadFile(path);
        List<string> list = new List<string>(lines);
        return list;
    }

   
}

