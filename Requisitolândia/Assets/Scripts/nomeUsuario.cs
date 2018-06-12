﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nomeUsuario : MonoBehaviour
{
    private Text textUm;
    private GameObject usuario;
    private InputField input;
    private string usrName;
    private loadAndReadTxt script;

    

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
        usrName = input.text;
        script.WriteCharacterName(usrName);
        SceneManager.LoadScene("Scenes/Persistent");
    }

    public void Voltar()
    {
        SceneManager.LoadScene("Menu");
    }
}
