using System;

public class MyShowData : IShowData
{
    public string showData(string data)
    {
        return $"this is mydata:{data}";
    }
}
