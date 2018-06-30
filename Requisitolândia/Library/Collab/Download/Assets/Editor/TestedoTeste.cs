using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using System;


public class TestedoTeste   {

	// Use this for initialization
    [Test]
	public void calculted () {
        PlayerController script;
        script = GameObject.Find("EventSystem").GetComponent<PlayerController>();
        string usrName = script.getAtualName();
        Assert.IsNotEmpty(usrName);
    }	

    [Test]
    public void readWorking()
    {
        PlayerController script;

        script = GameObject.Find("EventSystem").GetComponent<PlayerController>();
        Assert.IsEmpty(script.ReadFile("Assets/Resources/Actual.txt"));
       
           }	// Update is called once per frame
	[Test]
    public void saveWorking()
    {
        PlayerController script;
        script = GameObject.Find("EventSystem").GetComponent<PlayerController>();
        script.newPlayer(33, "Alessandreia", 2, 2000, 3);
        Assert.True(script.isUserAlreadyInDataBase("Alessandreia"));
    }
}
