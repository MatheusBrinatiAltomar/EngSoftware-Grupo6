using System.Collections;
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
    private PlayerController script;

    

    // Use this for initialization
    void Start()
    {
        script = GameObject.Find("Controller").GetComponent<PlayerController>();
        input = GameObject.Find("InputField").GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
     


    }

   public void Continuar()
    {
        usrName = input.text;
        script.loadPlayersData();
        script.WriteCurrentCharacterName(usrName);
        if (script.isUserAlreadyInDataBase(usrName))
        {
            SceneManager.LoadScene("Scenes/Persistent");
        } else
        {
            script.newPlayer(0, usrName, 0, 0, 0);
            script.savePlayersData();
            SceneManager.LoadScene("Scenes/Persistent");

        }
        

    }

    public void MudarNome()
    {
        usrName = input.text;
        input = GameObject.Find("InputField2").GetComponent<InputField>();
        string newName = input.text;
        script.changeUserName(newName,usrName);
    }

    public void Voltar()
    {
        SceneManager.LoadScene("Menu");
    }
}
