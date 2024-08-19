using System;

public class YouShowData : IShowData
{
    public string showData(string data)
    {
        return $"this is youdata:{data}";
    }
}
