using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameLoad : MonoBehaviour {
    private Text usrName;
    private Text usrTime;
    private string nome;
    DateTime startTime;
    private string[] line;
    // Use this for initialization
    void Start () {
        startTime = DateTime.Now;
        usrName = GameObject.Find("Text").GetComponent<Text>();
        usrTime = GameObject.Find("tempoDecorrido").GetComponent<Text>();
        line = File.ReadAllLines(GetPathToList());
        usrName.text = line[0];
    }
	
	// Update is called once per frame
	void Update () {
        string time = GetElapsedTime().TotalSeconds.ToString();
        usrTime.text = time;
        print(usrName.text);
        print(int.Parse(GetElapsedTime().Minutes.ToString()));
    }

    public TimeSpan GetElapsedTime()
    {
        TimeSpan elapsedTime = DateTime.Now - startTime;
        
        return elapsedTime;
    }

    public string GetPathToList()
    {
        string path = null;
        try
        {
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
        string path = GetPathToList();
        File.WriteAllText("Assets/Resources/Atual.txt", name + Environment.NewLine);

    }

    public void Voltar()
    {
        File.AppendAllText(GetPathToList(), GetElapsedTime().TotalSeconds.ToString());
        SceneManager.LoadScene("nameInput");
    }

    public void Continuar()
    {

        SceneManager.LoadScene("Fase2");
    }
}
