using System.IO;
using UnityEngine;

public class DataManager : Manager<DataManager>
{
    string path;
    public Collecterinfo[] collecterInfos;
    int collecterCount = 10;
    public void SaveItemJson()
    {
        path = Path.Combine(Application.dataPath + "/Json/", "ItemData.json") ?? null;
        //string jsonData = null;
        if (path == null) return;

        File.WriteAllText(path, "");

        ItemData data = new ItemData();

        for (int i = 0; i < 10; i++)
        {
            ItemStruct itemStruct = new ItemStruct(5,5,5,5,"image","description");
            data.items[i] = itemStruct;
        }
        string jsonData = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, jsonData);
    }


    public void SaveCollecterJson()
    {
        path = Path.Combine(Application.dataPath + "/Json/", "CollecterData.json") ?? null;
        if (path == null) return;

        File.WriteAllText(path, "");

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

        //path = Path.Combine("/Json/", "ItemData.json");
        TextAsset txt = Resources.Load<TextAsset>("Json/ItemData");
        Debug.Log(txt);

        //string jsonData = File.ReadAllText(path);
        //Debug.Log(jsonData);

        ItemData itemData = JsonUtility.FromJson<ItemData>(txt.text);

        ItemManager.Instance.GenerateItem(itemData);
    }

    public void JsonCollecterParsing()
    {

        //path = Path.Combine("/Json/", "CollecterData.json");
        TextAsset txt = Resources.Load<TextAsset>("Json/CollecterData");
        Debug.Log(txt);
        //string jsonData = File.ReadAllText(path);
        //Debug.Log(jsonData);

        CollecterData collecterData = JsonUtility.FromJson<CollecterData>(txt.text);
        collecterInfos = new Collecterinfo[20];
        // 이거 시발 먼데
        for (int i = 0; i < collecterCount; i++)
        {

            collecterInfos[i] = collecterData.collecters[i];
            Debug.Log(collecterInfos[i].collecterText);
        }
        

    }

}
