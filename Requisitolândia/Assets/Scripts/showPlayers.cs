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

    public TextMeshProUGUI [] names;
    public TextMeshProUGUI[] scores;
    public TextMeshProUGUI[] times;
    // Use this for initialization


    void Start () {
         
        


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

    public void showRanking()
    {


        
        script = GameObject.Find("EventSystem").GetComponent<PlayerController>();
        script.loadPlayersData();
        int i = 0;
        foreach (User player in script.playerData.users)
        {
            names[i].text = player.userName;
            scores[i].text = player.points.ToString();
            times[i].text = player.timeSpent.ToString();
            i++;
            if (i > 3)
                break;
        }
    }

        
}
