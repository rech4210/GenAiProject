using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public struct Resource
{
    public int money;
    public int honor;
    public Resource(int money, int _honor)
    {
        this.money = money;
        this.honor = _honor;
    }
}
public class ResourceManager : Manager<ResourceManager>
{

    public TMP_Text moneyText;
    public TMP_Text honorText;
    private Resource resource;

    //이걸 전체 데이터로 뿌려줘야함.
    public List<Material> userInventoryMaterial = new();

    public Resource Resource { get { return resource; }}

    private void SetInventory()
    {
        for (int j = 0; j < 5; j++)
        {
            for (int i = 0; i < DataManager.Instance.materialCount; i++)
            {
                userInventoryMaterial.Add(GetMaterial(i));
                Debug.Log(userInventoryMaterial[i].name);
                //for (int j = 0; j < 5; j++)
                //{
                //    userInventoryMaterial.Add(GetMaterial(i));
                //    Debug.Log(userInventoryMaterial[i].name);
                //}s

            }
        }
    }
    public void GetInventory()
    {
        for (int j = 0; j < 5; j++)
        {
            for (int i = 0; i < DataManager.Instance.materialCount; i++)
            {
                Debug.Log(userInventoryMaterial[i].name);
                //for (int j = 0; j < 5; j++)
                //{
                //    userInventoryMaterial.Add(GetMaterial(i));
                //    Debug.Log(userInventoryMaterial[i].name);
                //}

            }
        }
    }
    private void Start()
    {
        resource = new Resource(50, 100);
        SetText();
        SetInventory();
    }
    public void AddMoney(int _money)
    {
        resource.money += _money;
        SetText();
    }

    public void AddHonor(int _honor)
    {
        resource.honor += _honor ;
        SetText();
    }
    private Material GetMaterial(int materialCode) 
    {
        var materialinfo = ItemManager.Instance.GetMaterialInfo(materialCode);
        Material _material = new Material(materialinfo.code, materialinfo.price, materialinfo.name, materialinfo.name);
        return _material;
    }

    public void MaterialToInventory(int materialCode)
    {
        Material _material = GetMaterial(materialCode);
        userInventoryMaterial.Add(_material);
    }

    public Material[] GetMaterialFromInventory(Recipe recipe)
    {
        List<Material> _materialList = new List<Material>();
        foreach (var needMaterial in recipe.ingredientDictionary.Values)
        {
            for (int i = 0; i < needMaterial.needCount; i++)
            {
                Material _material = GetMaterial(needMaterial.code);
                //여기서 개체를 못찾는다.
                foreach (var invenMaterial in userInventoryMaterial)
                {
                    // 인벤에 있다.
                    if (invenMaterial.code == _material.code)
                    {
                        // 이부분 분기 제대로 처ㄴ리할것.,
                        _materialList.Add(invenMaterial);
                    }
                }
                if (_materialList == null)
                {
                    Debug.Log("해당하는 재료가 없음.");
                    return null;
                }
            }
        }
        return _materialList.ToArray<Material>();


    }
    public bool CheckInventoryMaterial(List<Material> materials)
    {
        bool isMaterialInventory = false;
        List<Material> tempInventory= userInventoryMaterial;
        foreach (var mat in materials)
        {
            // 이부분 체크 반복문에서 오류 나는듯
            foreach (var invenMat in userInventoryMaterial)
            {
                if(mat.code == invenMat.code)
                {
                     isMaterialInventory = tempInventory.Remove(mat);
                }
            }
        }
        if(isMaterialInventory == false)
        {
            Debug.Log("인벤토리에 적절한 재료가 부족합니다.");
        }
        return isMaterialInventory;
    }

    public void RemoveMaterial(List<Material> materials)
    {
        for (int i = 0; i < materials.Count; i++)
        {
            userInventoryMaterial.Remove(materials[i]);
        }
        
    }
    void SetText()
    {
        moneyText.text = "money :" + resource.money;
        honorText.text = "honor: " + resource.honor;
    }
}
