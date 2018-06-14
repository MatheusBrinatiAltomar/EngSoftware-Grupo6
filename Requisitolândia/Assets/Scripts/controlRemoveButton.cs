using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class controlRemoveButton : MonoBehaviour {
    public TextMeshProUGUI user;
    public PlayerController script;
    public showPlayers aux;
	// Use this for initialization
	void Start () {
		script  = GameObject.Find("EventSystem").GetComponent<PlayerController>();
        aux = GameObject.Find("EventSystem").GetComponent<showPlayers>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Onclick()
    {
        string usrName = user.text;
        script.removePlayer(usrName);
        
    }
}
