using System;
using UnityEngine;

[Serializable]
public class ItemData
{

    public ItemStruct[] items;
    public ItemData() 
    {
        items = new ItemStruct[100];  
    }
}
[Serializable]
public struct ItemStruct
{
    public int code;
    public int price;
    public int honor;
    public int grade;
    public string Image;
    public string description;

    public ItemStruct(int code, int price, int honor, int grade, string image, string description)
    {
        this.code = code;
        this.price = price;
        this.honor = honor;
        this.grade = grade;
        this.Image = image;
        this.description = description;
    }
}

[Serializable]
public class CollecterData
{
    public Collecterinfo[] collecters;
    public CollecterData()
    {
        collecters = new Collecterinfo[20];
    }
}

[Serializable]
public class Collecterinfo
{
    public string collecterName;
    public string collecterImage;
    public string collecterText;
    public string collecterBackground;
    public Collecterinfo(string name, string image, string text, string background)
    {
        collecterName = name;
        collecterImage = image;
        collecterText = text;
        collecterBackground = background;
    }
    //이미지, 대사, 배경, 배경없으면 예외처리
}
