using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Unit/Create new move")]

public class MoveBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] ClassType type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;



    public string Name {
        get {return name;}
    }
    public string Description{
        get {return description;}
    }
    public ClassType Type{
        get {return type;}
    }
    public int Power{
        get {return power;}
    }
    public int Accuracy{
        get {return accuracy;}
    }
    public int PP{
        get {return pp;}
    }


    

}