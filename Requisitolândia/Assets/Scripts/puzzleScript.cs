using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;



public class puzzleScript : MonoBehaviour {

    public List<Button> btns = new List<Button>();
    List<Button> sortedList;
    int firstGuessIndex, secondGuessIndex;
    bool firstGuess, secondGuess;
	// Use this for initialization
	void Start () {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        foreach (GameObject obj in objects)
        {
            btns.Add(obj.GetComponent<Button>());
            print(obj.name);
        }
        addListeners();
        sortedList = btns.OrderBy(go => go.name).ToList();

        
        // List<Button> SortedList = btns.OrderBy(o => o.name).ToList();
        /*  btns.Sort(delegate (Button x, Button y)
          {
              string t1 = x.GetComponent<Text>().name;
              string t2 = y.GetComponent<Text>().name;
              int i1 = int.Parse(t1);
              int i2 = int.Parse(t2);
              return t1.CompareTo(t2);
          });*/
        print("--------------");
        foreach (Button btn in sortedList)
        {
            print(btn.name);
        }

    }

   
        // Update is called once per frame
        void Update () {
		
	}

    public void addListeners()
    {
        foreach (Button btn in sortedList)
        {
            btn.onClick.AddListener(() => clickPuzzleButton());
        }
    }

    public void clickPuzzleButton()
    {
        string objName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        print(sortedList[int.Parse(objName)].GetComponentInChildren<Text>().text);

        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex =  int.Parse(objName);
            sortedList[firstGuessIndex].GetComponentInChildren<Text>().text = "Engenharia de SW";
            

        } else if (!secondGuess)
        {

        }
    }
}
