﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getName : MonoBehaviour {
    public GameObject usuario;
    public InputField inputUm;
    public string name;
	// Use this for initialization
	void Start () {
        usuario = GameObject.Find("InputFieldMalu");

	}
	
	// Update is called once per frame
	void Update () {
        name = inputUm.text;
        Debug.Log(name);
        inputUm = usuario.GetComponent<InputField>();
        string name2 = inputUm.text;
        print(name2 + "bkfdd,hgjdfh");

	}
}
