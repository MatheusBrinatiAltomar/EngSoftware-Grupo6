using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nomeUsuario : MonoBehaviour {
    public Text textUm;
    public GameObject usuario;
    public string comando;
	// Use this for initialization
	void Start () {
        usuario = GameObject.Find("nomeusr");
	}
	
	// Update is called once per frame
	void Update () {

        textUm = usuario.GetComponent<Text>();
        string comando2 = textUm.text;

        comando = textUm.text;

        textUm.text = "Malu linda";
        print(comando + "malu princesa");
        

	}
}
