using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.IO;

public class GameController : MonoBehaviour
{
    public AudioSource buttonSound;
    public SimpleObjectPool answerButtonObjectPool;
    public Text questionText;
    public Text scoreDisplay;
    public Text timeRemainingDisplay;
    public Transform answerButtonParent;
    //private int[] roundId;
    public GameObject questionDisplay;
    public GameObject roundLostDisplay;
    public GameObject roundWinDisplay;
    public GameObject puzzleDisplay;
    public Text highScoreDisplay;

    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;

    private bool isRoundActive = false;
    public bool isGamePaused = false;
    public bool finalRound = false;
    public float timeRemaining;
    private int playerScore;
    private int questionIndex;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    //Mudanças Vinicius

    public Text namePlayer;
    public PlayerController script;
    public string nameUser;

    void Start()
    {
        //Control Last round
        string count = File.ReadAllText("Assets/Resources/fase.txt");
        int fase = int.Parse(count);
        if(fase >= 3)
        {
            isRoundActive = false;
            questionDisplay.SetActive(false);
            roundWinDisplay.SetActive(true);
        }

        //
        script = GameObject.Find("GameController").GetComponent<PlayerController>();
        script.loadPlayersData();
        nameUser = script.ReadFile("Assets/Resources/Atual.txt");
        namePlayer.text = nameUser;
        User u = script.getUser(nameUser);
        dataController = FindObjectOfType<DataController>();                              // Store a reference to the DataController so we can request the data we need for this round

        currentRoundData = dataController.GetCurrentRoundData();                            // Ask the DataController for the data for the current round. At the moment, we only have one round - but we could extend this
        questionPool = currentRoundData.questions;                                          // Take a copy of the questions so we could shuffle the pool or drop questions from it without affecting the original RoundData object

        timeRemaining = currentRoundData.timeLimitInSeconds;                                // Set the time limit for this round based on the RoundData object
        UpdateTimeRemainingDisplay();
        print("Points:" + u.points);
        playerScore = u.points;
        questionIndex = 0;

        ShowQuestion();
        isRoundActive = true;

        
    }

    public void saveButton()
    {
        print(nameUser + "salvo" + playerScore + " " + timeRemaining );
        script.saveUserPoints(nameUser, playerScore,timeRemaining);
    }

    public void gamePaused()
    {
        if (isGamePaused)
        {
            isGamePaused = false;
        }
        else
        {
            isGamePaused = true;
        }
    }

    void Update()
    {
        if (isRoundActive)
        {
            if (!isGamePaused)
            {
            timeRemaining -= Time.deltaTime;                                                // If the round is active, subtract the time since Update() was last called from timeRemaining
            UpdateTimeRemainingDisplay();
            }
            if (timeRemaining <= 0f)                                                     // If timeRemaining is 0 or less, the round ends
            {
                EndRound();
            }
        }
        //if (roundId == 0)
       // {
       //     finalRound = true;
        //}
    }

    void ShowQuestion()
    {
        RemoveAnswerButtons();

        QuestionData questionData = questionPool[questionIndex];                            // Get the QuestionData for the current question
        questionText.text = questionData.questionText;                                      // Update questionText with the correct text

        for (int i = 0; i < questionData.answers.Length; i ++)                               // For every AnswerData in the current QuestionData...
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();         // Spawn an AnswerButton from the object pool
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);
            answerButtonGameObject.transform.localScale = Vector3.one;

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.answers[i]);                                    // Pass the AnswerData to the AnswerButton so the AnswerButton knows what text to display and whether it is the correct answer
        }
    }

    void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)                                            // Return all spawned AnswerButtons to the object pool
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(bool isCorrect)
    {
        buttonSound.Play();
        if (isCorrect)
        {
            playerScore += currentRoundData.pointsAddedForCorrectAnswer;                    // If the AnswerButton that was clicked was the correct answer, add points
            scoreDisplay.text = playerScore.ToString();
        }

        if(questionPool.Length > questionIndex + 1)                                          // If there are more questions, show the next question
        {
            questionIndex++;
            ShowQuestion();
        }
        else                                                                                // If there are no more questions, the round ends
        {
            EndRound();
        }

    }

    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplay.text = Mathf.Round(timeRemaining).ToString();
    }

    public void EndRound()
    {
        isRoundActive = false;

        dataController.SubmitNewPlayerScore(playerScore);
        highScoreDisplay.text = dataController.GetHighestPlayerScore().ToString();

        questionDisplay.SetActive(false);
        if(timeRemaining<=0)
        {
            roundLostDisplay.SetActive(true);
        }
        else
        {
            Debug.Log("Erro");
            script.saveUserPoints(nameUser, playerScore, timeRemaining);
            puzzleDisplay.SetActive(true);
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }
}