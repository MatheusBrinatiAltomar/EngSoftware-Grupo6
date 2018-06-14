using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class PlayerController : MonoBehaviour {
    public Data playerData;
    public List<User> players;
    private string path = "Assets/Resources/Users.json";
    
    // Use this for initialization
    void Start() {
        

}

    // Update is called once per frame
    void Update() {

    }

    public bool isUserAlreadyInDataBase(string userName)
    {
        bool aux=false;
        loadPlayersData();
        foreach (User player in playerData.users)
        {
            if (player.userName == userName)
            {
                aux = true;
                break;
            }
        }
           
            return aux;
    }

    public void changeUserName(string newName,string oldName)
    {
        loadPlayersData();
        foreach (User player in playerData.users)
        {
            if (player.userName == oldName)
            {
                player.userName = newName;
                savePlayersData();
                break;
            }
        }

    }


    public void newPlayer(int id, string name,int timeSpent, int points, int area)
    {
        User newUsr = new User(id,name, timeSpent, points, area);
        playerData.users.Add(newUsr);
        savePlayersData();

    }

    public void removePlayer(string name)
    {
        int i = 0;
        foreach (User player in playerData.users)
        {
            if (player.userName == name)
            {
                User playerToRmv = player;
                playerData.users.Remove(playerToRmv);
                savePlayersData();
                break;
            }
            i++;
        }
    }

    public void loadPlayersData()
    {
        if (File.Exists(path))
        {
            string dataAsJson = File.ReadAllText(path);
            playerData = JsonUtility.FromJson<Data>(dataAsJson);
            }
            else
            {
                Debug.LogError("Não foi possivel abrir arquivo");
               
            }
    }

    public void savePlayersData()
    {
        string dataAsJson = JsonUtility.ToJson(playerData);
        File.WriteAllText(path, dataAsJson);
        /* Write AllText subescreve o arquivo (ou seja tudo que está lá será apagado e novas infos escritas)
           Para só adcionar algo no text usar: File.AppendAllText(path,dataAsJson)
           Se quiser adcionar uma linha em branco após o texto escrito: File.AppendAllText(path, dataAsJson + Environment.NewLine);
         */
    }

    public void WriteCurrentCharacterName(string name)
    {
        //Escreve o nome de um personagem na lista contendo os personagens de uma seção
        File.WriteAllText("Assets/Resources/Atual.txt", name);
    }

    public string ReadFile(string path)
    {
        // Lê o arquivo especificado
        string name = "";
        if (File.Exists(path))
            return name = File.ReadAllText(path);
        else
            return name;

    }

    public string getAtualName()
    {
        string name = ReadFile("Assets/Resources/Atual.txt");
        return name;
    }
}
