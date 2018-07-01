using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;



public class puzzleScript : MonoBehaviour {

    //Game Logic
    public List<Button> btns = new List<Button>();
    List<Button> sortedList = new List<Button>();
    int firstGuessValue, secondGuessValue;
    int firstGuessIndex, secondGuessIndex;
    bool firstGuess, secondGuess; //false por default


    //Puzzle Load
    public PuzzleData puzzleData;
    public List<Puzzle> puzzles;
    private string puzzlePath = "Assets/Resources/Puzzles.json";
    GameObject[] objects;

    public Sprite LogoImg;
    public Sprite blank;

    public GameController script;

    void Start () {
        script = GameObject.Find("EventSystem").GetComponent<GameController>();
        float time = script.timeRemaining;


       objects = GameObject.FindGameObjectsWithTag("PuzzleButton");
        //Set card background and white background
        LogoImg = Resources.Load<Sprite>("ES_LOGO");
        blank = Resources.Load<Sprite>("blank");

        //Read puzzle file
        if (File.Exists(puzzlePath)) {
             string dataAsJson = File.ReadAllText(puzzlePath);
             puzzleData = JsonUtility.FromJson<PuzzleData>(dataAsJson);
        } else {
            Debug.LogError("Não foi possivel abrir arquivo");
        }

        //add objects to array btns
        foreach (GameObject obj in objects)
        {
            btns.Add(obj.GetComponent<Button>());

        }
        //FindGameObjextsWithTag does not return objects in a specific order, so we order our list
        sortedList = btns.OrderBy(go => go.name).ToList();
         
        addListeners();
        

    }

    void rmvObject(string name)
    {
        foreach(GameObject obj in objects)
        {
            if(obj.name == name)
            {
                Destroy(obj);
                Destroy(btns[int.Parse(name)]);
                Destroy(sortedList[int.Parse(name)]);
            }
        }
    }
   
        // Update is called once per frame
        void Update () {
		
	}

    public void addListeners()
    {
        foreach (Button btn in btns)
        {
            btn.onClick.AddListener(() => clickPuzzleButton());
        }
    }

    IEnumerator Wait3Seconds()
    {
        yield return new WaitForSecondsRealtime(2);
        if (firstGuessValue == secondGuessValue && secondGuess && firstGuess)
        {
            firstGuess = false;
            secondGuess = false;
            /*rmvObject(firstGuessIndex.ToString());
            rmvObject(secondGuessIndex.ToString());*/
            sortedList[firstGuessIndex].GetComponentInChildren<Text>().text = firstGuessIndex.ToString();
            sortedList[secondGuessIndex].GetComponentInChildren<Text>().text = secondGuessIndex.ToString();
            print("Acertou!");
        }
        else if (firstGuessValue != secondGuessValue && secondGuess && firstGuess)
        {
            sortedList[firstGuessIndex].image.sprite = LogoImg;
            sortedList[secondGuessIndex].image.sprite = LogoImg;
            sortedList[firstGuessIndex].GetComponentInChildren<Text>().text = firstGuessIndex.ToString();
            sortedList[secondGuessIndex].GetComponentInChildren<Text>().text = secondGuessIndex.ToString();
            firstGuess = false;
            secondGuess = false;
            print("Errou!");
        }
    }

    public void clickPuzzleButton()
    {
        string objName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex =  int.Parse(objName);
            sortedList[firstGuessIndex].image.sprite = blank;
            sortedList[firstGuessIndex].GetComponentInChildren<Text>().text = puzzleData.puzzles[firstGuessIndex].info;
            firstGuessValue = puzzleData.puzzles[firstGuessIndex].value;

        } else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(objName);
            sortedList[secondGuessIndex].image.sprite = blank;
            sortedList[secondGuessIndex].GetComponentInChildren<Text>().text = puzzleData.puzzles[secondGuessIndex].info;
            secondGuessValue =  puzzleData.puzzles[secondGuessIndex].value;
        }
        StartCoroutine("Wait3Seconds");
    }
}
