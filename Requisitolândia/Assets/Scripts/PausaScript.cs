using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PausaScript : MonoBehaviour {

	public void SairJogo()
	{
		Application.Quit();
	}

    public void irParaMenu()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }

}
