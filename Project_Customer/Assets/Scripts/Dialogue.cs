using UnityEngine;


[System.Serializable]
public class Dialogue
{
    public string name;
    public string swapName;

    [TextArea(2,5)]
    public string[] sentences;
}
