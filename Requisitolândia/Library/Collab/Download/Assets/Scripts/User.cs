using System.Collections;
using UnityEngine;


[System.Serializable]
public class User {
    public int id;
    public string userName;
    public float timeSpent;
    public int points;
    public int area;
    

    // Use this for initialization

    public User(int id,string userName, float timeSpent, int points, int area)
    {
        this.id = id;
        this.userName = userName;
        this.timeSpent = timeSpent;
        this.points = points;
        this.area = area;
    }

    public User()
    {

    }
   

   
}
