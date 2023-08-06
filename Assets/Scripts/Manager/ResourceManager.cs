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

    //�̰� ��ü �����ͷ� �ѷ������.
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
                //���⼭ ��ü�� ��ã�´�.
                foreach (var invenMaterial in userInventoryMaterial)
                {
                    // �κ��� �ִ�.
                    if (invenMaterial.code == _material.code)
                    {
                        // �̺κ� �б� ����� ó�����Ұ�.,
                        _materialList.Add(invenMaterial);
                    }
                }
                if (_materialList == null)
                {
                    Debug.Log("�ش��ϴ� ��ᰡ ����.");
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
            // �̺κ� üũ �ݺ������� ���� ���µ�
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
            Debug.Log("�κ��丮�� ������ ��ᰡ �����մϴ�.");
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
