using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class showPlayers : MonoBehaviour {
    private PlayerController script;
    private Text textUm;
    public TextMeshProUGUI text;
    public TextMeshProUGUI[] texts;
    public GameObject[] userTexts;
    public GameObject menu;
    // Use this for initialization


    void Start () {
         menu = GameObject.Find("MenuPrincipal");
        Debug.Log(menu);
        


    }
	
	// Update is called once per frame
	void Update () {
       
    }

    public void loadNames()
    {
        script = GameObject.Find("EventSystem").GetComponent<PlayerController>();
        script.loadPlayersData();
        text = GameObject.Find("Usuario1").GetComponent<TextMeshProUGUI>();
        texts = FindObjectOfType<TextMeshProUGUI>().GetComponents<TextMeshProUGUI>();
        userTexts = GameObject.FindGameObjectsWithTag("Usuario");
        GameObject[] userTimes;
        userTimes = GameObject.FindGameObjectsWithTag("Tempo");
        int i = 0;
        foreach(User player in script.playerData.users)
        {
            userTexts[i].GetComponent<TextMeshProUGUI>().text = script.playerData.users[i].userName;
            userTimes[i].GetComponent<TextMeshProUGUI>().text = script.playerData.users[i].timeSpent.ToString();
            i++;
        }
        
    }

        
}
