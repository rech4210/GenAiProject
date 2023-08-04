using System;
using System.ComponentModel;

[Serializable]
public class CollecterData
{
    public Collecter[] collecters = new Collecter[50];
}

[Serializable]
public class Collecter
{
    public string collecterName;
    public string collecterImage;
    public string collecterText;
    public string collecterBackground;
    public Collecter(string name, string image, string text, string background)
    {
        collecterName = name;
        collecterImage = image;
        collecterText = text;
        collecterBackground = background;
    }
    //이미지, 대사, 배경, 배경없으면 예외처리
}
