﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nomeUsuario : MonoBehaviour
{
    public Text textUm;
    public GameObject usuario;
    public InputField input;
    public string usrName;
    public loadAndReadTxt script;

    

    // Use this for initialization
    void Start()
    {
        script = GameObject.Find("Controller").GetComponent<loadAndReadTxt>();
        input = GameObject.Find("InputField").GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
     


    }

   public void Continuar()
    {
        print("alo");
        usrName = input.text;
        script.WriteCharacterName(usrName);
        print(usrName);
        SceneManager.LoadScene("Scenes/Fase1");
    }

    public void Voltar()
    {
        SceneManager.LoadScene("Menu");
    }
}
