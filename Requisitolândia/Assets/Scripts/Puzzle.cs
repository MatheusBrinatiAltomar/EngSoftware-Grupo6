using System.Collections;

using UnityEngine;

[System.Serializable]
public class Puzzle  {
        public int id;
        public string info;
        public int value;

    public Puzzle(int id, string info, int value)
    {
        this.id = id;
        this.info = info;
        this.value = value;
    }

    public Puzzle()
    {

    }

}
