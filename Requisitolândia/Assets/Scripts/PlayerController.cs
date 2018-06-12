using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class PlayerCOntroller : MonoBehaviour {
    private Data playerData;
    private string path = "Assets/Resources/Users.json";
    // Use this for initialization
    void Start() {
        loadPlayersData();
    }

    // Update is called once per frame
    void Update() {

    }

    bool isUserAlreadyInDataBase(string userName)
    {
        bool aux;
        if (File.Exists(path))
        {
            foreach (User player in playerData.users)
            {
                if (player.NameUser == userName)
                {
                    aux = true;
                    break;
                }
            }
            aux = false;
        }
        else
        {
            Debug.LogError("Não foi possivel abrir arquivo");
            aux = false;
        }
        return aux;
    }

    public void loadPlayersData()
    {
        string dataAsJson = File.ReadAllText(path);
        playerData = JsonUtility.FromJson<Data>(dataAsJson);
    }

    public void savePlayersData()
    {
        string dataAsJson = JsonUtility.ToJson(playerData);
        string filePath = Application.dataPath + path;
        File.WriteAllText(filePath, dataAsJson);
        /* Write AllText subescreve o arquivo (ou seja tudo que está lá será apagado e novas infos escritas)
           Para só adcionar algo no text usar: File.AppendAllText(path,dataAsJson)
           Se quiser adcionar uma linha em branco após o texto escrito: File.AppendAllText(path, dataAsJson + Environment.NewLine);
         */
    }

    public void savePlayerData(int indexPlayer)
    {
        string dataAsJson = JsonUtility.ToJson(playerData.users[indexPlayer]);
        string filePath = Application.dataPath + path;
        File.AppendAllText(path, dataAsJson);
    }
}
