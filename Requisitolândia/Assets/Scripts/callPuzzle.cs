using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class callPuzzle : MonoBehaviour 
{
	public void chamaPuzzle()
	{
		SceneManager.LoadScene("Puzzle");
	}
}
