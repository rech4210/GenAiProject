using UnityEngine;

public class ItemManager : Manager<ItemManager>
{
    public Item[] items;
    public MaterialStruct[] materials;
    public int createCode = 999;
    ItemGenerator generator;
    private int gearCounts = 50;
    //�ʱ⿡ ������ n���� �����ؼ� �ݷ��Ϳ��� �Ѱ������.
    
    public int GetCodeForCreate()
    {
        return createCode;
    }
    public void ChangeCode(int createCode)
    {
        this.createCode = createCode;
    }

    //���� �����ֱ�
    public void GetItem(ItemData itemData)
    {
        if (items == null)
        {
            items = DataManager.Instance.items;
        }

        //���Ⱑ ��������??
        for (int i = 0; i < DataManager.Instance.itemCount; i++) 
        {
            if (itemData.items[i].code <= gearCounts)
            {
                generator =  new GearGenerator();
                items[i] =generator.CreatItem(itemData.items[i]);
                Debug.Log(items[i].recipe.ingredientDictionary[0].needCount);
            }
            else if (itemData.items[i].code > gearCounts)
            {
                generator = new PotionGenerator();
                items[i] = generator.CreatItem(itemData.items[i]);
                Debug.Log(items[i].price);
            }
            else 
            {
                Debug.LogError("not Finded Item");
            }
        }
    }

    //public Item GenerateItemWitmMaterial(MaterialStruct[] materials)
    //{
    //    //�ʱ� ���׸��� ������ �������ֱ�
    //}


    public Item GetItemInfo(int _itemCode)
    {
        return items[_itemCode];
        //���⼭ �ش��ϴ� ������ �ڵ带 �Է��ؼ� ã����.
    }
    //���׸��� ã�ƿ���
    public MaterialStruct GetMaterialInfo(int materialCode)
    {
        if (materials == null)
        {
            materials = DataManager.Instance.materialStructs;
        }
        return materials[materialCode];
    }
}
