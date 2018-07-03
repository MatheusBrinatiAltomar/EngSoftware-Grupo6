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

    //Display management 
    public Text questionText;
    public Text scoreDisplay;
    public Text timeRemainingDisplay;
    public GameObject Panel;
    public GameObject roundLostDisplay;
    public GameObject roundWinDisplay;
    public GameObject feedbackDisplay;

    //Score count
    public bool isRoundActive;
    public float timeRemaining;
    public int playerScore;
    public Text namePlayer;
    public PlayerController script;
    public string nameUser;


    void Start () {
        //Time is set in Unit

        //User Load
        script = GameObject.Find("GameController").GetComponent<PlayerController>();
        script.loadPlayersData();
        nameUser = script.ReadFile("Assets/Resources/Atual.txt");
        namePlayer.text = nameUser;
        //Time and points count and display
        UpdateTimeRemainingDisplay();
        playerScore = 0;
        isRoundActive = true;



        //-------- Puzzle Logic

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

    public void EndRound()
    {
        isRoundActive = false;

        


        if (timeRemaining <= 0)
        {
            roundLostDisplay.SetActive(true);
            Panel.SetActive(false);
        }
        else
        {
            roundWinDisplay.SetActive(true);
            Panel.SetActive(false);
        }
    }

    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplay.text = Mathf.Round(timeRemaining).ToString();
    }

    void Update()
    {
        if (isRoundActive)
        {
            scoreDisplay.text = playerScore.ToString();
            timeRemaining -= Time.deltaTime;                                                // If the round is active, subtract the time since Update() was last called from timeRemaining
            UpdateTimeRemainingDisplay();

            if (timeRemaining <= 0f)                                                     // If timeRemaining is 0 or less, the round ends
            {
                EndRound();
            }
        }
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


    public void addListeners()
    {
        foreach (Button btn in btns)
        {
            btn.onClick.AddListener(() => clickPuzzleButton());
        }
    }

    IEnumerator Wait3Seconds()
    {
        
        if (firstGuessValue == secondGuessValue && secondGuess && firstGuess)
        {
            feedbackDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "Acertou a combinação!";
            feedbackDisplay.GetComponent<TMPro.TextMeshProUGUI>().color = Color.green;
            feedbackDisplay.SetActive(true);
            firstGuess = false;
            secondGuess = false;
            playerScore += 10;
        }
        else if (firstGuessValue != secondGuessValue && secondGuess && firstGuess)
        {
            yield return new WaitForSecondsRealtime(1);
            feedbackDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "Errou a combinação!";
            feedbackDisplay.GetComponent<TMPro.TextMeshProUGUI>().color = Color.red;
            feedbackDisplay.SetActive(true);
            sortedList[firstGuessIndex].image.sprite = LogoImg;
            sortedList[secondGuessIndex].image.sprite = LogoImg;
            sortedList[firstGuessIndex].GetComponentInChildren<Text>().text = "";
            sortedList[secondGuessIndex].GetComponentInChildren<Text>().text = "";
            firstGuess = false;
            secondGuess = false;
        }
        yield return new WaitForSecondsRealtime(1);
        feedbackDisplay.SetActive(false);
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
            StartCoroutine("Wait3Seconds");
        }
        
    }


    
 

    public void saveButton()
    {
        script.saveUserPoints(nameUser, playerScore, timeRemaining);
    }

    

    
}
