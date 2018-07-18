using System;

[Serializable]
public class ClassProjectList
{
    public EachClass[] eachClass;
}

[Serializable]
public struct EachClass
{
    public string className;
    public string title;
    public string description;
    public string format;
    public string imageURL;
}