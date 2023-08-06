using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

[Serializable]
public class ItemData
{
    public ItemStruct[] items;
    public ItemData() 
    {
        items = new ItemStruct[35];  
    }
}
[Serializable]
public class ItemStruct
{
    public int code;
    public int price;
    public int honor;
    public int grade;
    public string name;
    public string Image;
    public string description;
    public Recipe recipe;

    public ItemStruct(int code, int price, int honor, int grade, string image,string name, string description, Recipe recipe)
    {
        this.code = code;
        this.price = price;
        this.honor = honor;
        this.grade = grade;
        this.name = name;
        this.Image = image;
        this.description = description;
        this.recipe = recipe;
    }
}

[Serializable]
public class MaterialData
{
    public MaterialStruct[] materials;
    public MaterialData()
    {
        materials = new MaterialStruct[30];
    }

}
[Serializable]
public struct Ingredient
{
    public int code;    // ����� index
    public int needCount;   // �ʿ��� ����

    public Ingredient(int code, int needCount)
    {
        this.code = code;
        this.needCount = needCount;
    }
    public void GetInformation()
    {
        Debug.Log($"���� {code} �� ����: "+ needCount);
    }
}
[Serializable]
public class Recipe
{
    public int recipeCode; // ������(�׸��� item)�� code

    public Ingredient[] ingredientArray;
    public Dictionary<int, Ingredient> ingredientDictionary = new();  // ���� int�� ����� code

    public void AddIngredient(Ingredient ingredient)
    {
        ingredientDictionary[ingredient.code] = ingredient;
    }

    public void MakeArray()
    {

        ingredientArray = ingredientDictionary.Values.ToArray();
    }
    
    public bool CheckRecipe(Dictionary<int, Ingredient> otherIngredientDictionary)
    {
        foreach(var otherListIndex in otherIngredientDictionary.Keys)
        {
            if (!ingredientDictionary.ContainsKey(otherListIndex))
                return false;
        }

        return true;
    }
}


[Serializable]
public struct MaterialStruct
{
    public int code;
    public int price;
    public string name;
    public string Image;

    public MaterialStruct(int code, int price,string name, string image )
    {
        this.code = code;
        this.price = price;
        this.name = name;
        this.Image = image;
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
    //�̹���, ���, ���, �������� ����ó��
}
