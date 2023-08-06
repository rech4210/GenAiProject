using UnityEngine;

public class ItemManager : Manager<ItemManager>
{
    public Item[] items;
    public MaterialStruct[] materials;
    public int createCode = 999;
    ItemGenerator generator;
    private int gearCounts = 50;
    //초기에 아이템 n개를 생성해서 콜렉터에게 넘겨줘야함.
    
    public int GetCodeForCreate()
    {
        return createCode;
    }
    public void ChangeCode(int createCode)
    {
        this.createCode = createCode;
    }

    //랜덤 생성넣기
    public void GetItem(ItemData itemData)
    {
        if (items == null)
        {
            items = DataManager.Instance.items;
        }

        //여기가 문제였나??
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
    //    //초기 마테리얼 데이터 생성해주기
    //}


    public Item GetItemInfo(int _itemCode)
    {
        return items[_itemCode];
        //여기서 해당하는 아이템 코드를 입력해서 찾아줌.
    }
    //마테리얼 찾아오기
    public MaterialStruct GetMaterialInfo(int materialCode)
    {
        if (materials == null)
        {
            materials = DataManager.Instance.materialStructs;
        }
        return materials[materialCode];
    }
}
