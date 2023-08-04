using System;

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

