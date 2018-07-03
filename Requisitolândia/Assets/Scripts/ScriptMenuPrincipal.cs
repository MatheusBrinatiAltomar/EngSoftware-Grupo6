using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScriptMenuPrincipal : MonoBehaviour 
{
	public void JogarJogo()
	{
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Scenes/nameInput");
    }
    public void Ranking()
	{
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Scenes/Ranking");
    }
	public void SairJogo()
	{
		Application.Quit();
	}

    public void irParaMudarNome()
    {
        SceneManager.LoadScene("Scenes/nameChange");
    }


}
