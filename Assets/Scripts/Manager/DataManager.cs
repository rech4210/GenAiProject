using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class DataManager : Manager<DataManager>
{
    string path;
    public Collecterinfo[] collecterInfos;
    public MaterialStruct[] materialStructs;
    public Item[] items;

    public int collecterCount = 2;
    public int materialCount = 12;
    public int itemCount = 35;

    Recipe recipe;
    public void SaveItemJson()
    {
        path = Path.Combine(Application.dataPath + "/Resources/Json/", "ItemData.json") ?? null;
        Debug.Log(path);
        //string jsonData = null;
        if (path == null) return;

        File.WriteAllText(path, "");

        ItemData data = new ItemData();
        recipe = new()
        {
            recipeCode = 0
        };
        recipe.AddIngredient(new Ingredient(0, 1));
        recipe.AddIngredient(new Ingredient(1, 1));
        recipe.AddIngredient(new Ingredient(2, 1));
        recipe.AddIngredient(new Ingredient(3, 1));
        recipe.MakeArray();
        // Test data라서 루프의 code가 item의 code
        for (int i = 0; i < itemCount; i++)
        {
            recipe.recipeCode = i;
            ItemStruct itemStruct = new ItemStruct(i, 0, 0, 0, "image", "name", "description", recipe);
            data.items[i] = itemStruct;
        }
        
        string jsonData = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, jsonData);
    }

    public void SaveMaterialJson()
    {
        path = Path.Combine(Application.dataPath + "/Resources/Json/", "MaterialData.json") ?? null;
        Debug.Log(path);
        //string jsonData = null;
        if (path == null) return;

        File.WriteAllText(path, "");

        MaterialData data = new MaterialData();

        for (int i = 0; i < materialCount; i++)
        {
            MaterialStruct materialStruct = new MaterialStruct(5,5, "name", "image");
            data.materials[i] = materialStruct;
        }
        string jsonData = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, jsonData);
    }

    public void SaveCollecterJson()
    {
        path = Path.Combine(Application.dataPath + "/Resources/Json/", "CollecterData.json") ?? null;
        Debug.Log(path);
        File.WriteAllText(path, "");
        if (path == null) return;

        CollecterData data = new CollecterData();

        for (int i = 0; i < 20; i++)
        {
            Collecterinfo collecter = new Collecterinfo("name","image","text","backgroundName");
            data.collecters[i] = collecter;
        }
        string jsonData = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, jsonData);
    }

    public void JsonItemParsing()
    {
        collecterInfos = new Collecterinfo[collecterCount];
        materialStructs = new MaterialStruct[materialCount];
        items = new Item[itemCount];
        TextAsset txt = Resources.Load<TextAsset>("Json/ItemData");
        Debug.Log(txt);


        ItemData itemData = JsonUtility.FromJson<ItemData>(txt.text);

        for (int i = 0; i < itemCount; i++)
        {
            int j = 0;
            foreach (var ingredient in itemData.items[i].recipe.ingredientArray)
            {
                itemData.items[i].recipe.ingredientDictionary[j] = ingredient;
                j++;
            }
        }

        ItemManager.Instance.GetItem(itemData);
    }

    public void JsonMaterialParsing()
    {

        TextAsset txt = Resources.Load<TextAsset>("Json/MaterialData");
        Debug.Log(txt);


        MaterialData materialData = JsonUtility.FromJson<MaterialData>(txt.text);

        if (materialStructs == null)
        {
            materialStructs = new MaterialStruct[materialCount];
        }

        for (int i = 0; i < materialCount; i++)
        {
            materialStructs[i] = materialData.materials[i];
        }
        ItemManager.Instance.materials = materialStructs;
    }

    public void JsonCollecterParsing()
    {

        TextAsset txt = Resources.Load<TextAsset>("Json/CollecterData");
        Debug.Log(txt);

        CollecterData collecterData = JsonUtility.FromJson<CollecterData>(txt.text);
        // 이거 시발 먼데
        for (int i = 0; i < collecterCount; i++)
        {
            collecterInfos[i] = collecterData.collecters[i];// 이 부분에서 에러인듯.
            Debug.Log(collecterInfos[i].collecterText);
        }
    }

    public Dictionary<int, Recipe> createTable;

    public void SetCreateTabe()
    {
        createTable = new();
        items = ItemManager.Instance.items;
        Recipe recipe = new();
        for (int i = 0; i < itemCount; i++) //20
        {
            foreach (var ingredientValue in items[i].recipe.ingredientDictionary?.Values)
            {
                if (ingredientValue.needCount != 0)
                {
                    recipe.AddIngredient(ingredientValue);
                }
            }
            createTable.Add(i, recipe);
            // 이 부분 체크해야한다.
        }
    }

    public HashSet<Recipe> SetTableValue(int code, int count)
    {
        HashSet<Recipe> hash = new();
        for (int i = 0; i < count; i++)
        {
            Recipe r = new();
            r.AddIngredient(new Ingredient(code, count));
            hash.Add(r);
        }
        return hash;
    }

}
