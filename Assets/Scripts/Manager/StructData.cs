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
    public int code;    // 재료의 index
    public int needCount;   // 필요한 개수

    public Ingredient(int code, int needCount)
    {
        this.code = code;
        this.needCount = needCount;
    }
    public void GetInformation()
    {
        Debug.Log($"정보 {code} 의 개수: "+ needCount);
    }
}
[Serializable]
public class Recipe
{
    public int recipeCode; // 레시피(그리고 item)의 code

    public Ingredient[] ingredientArray;
    public Dictionary<int, Ingredient> ingredientDictionary = new();  // 여기 int는 재료의 code

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
    //이미지, 대사, 배경, 배경없으면 예외처리
}
