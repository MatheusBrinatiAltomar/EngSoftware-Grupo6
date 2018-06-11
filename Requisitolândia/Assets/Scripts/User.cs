using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class User {
    private int id;
    private string userName;
    private int timeSpent;
    private int points;
    private int area;
    public string NameUser
    {
        get
        {
            return userName;
        }

        set
        {
            userName = value;
        }
    }

    public int TimeSpent
    {
        get
        {
            return timeSpent;
        }

        set
        {
            timeSpent = value;
        }
    }

    public int Points
    {
        get
        {
            return points;
        }

        set
        {
            points = value;
        }
    }

    public int Area
    {
        get
        {
            return area;
        }

        set
        {
            area = value;
        }
    }

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    // Use this for initialization

   

   
}
