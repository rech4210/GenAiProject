using UnityEngine;

public class ItemManager : Manager<ItemManager>
{
    public Item[] items = new Item[100];
    ItemGenerator generator;
    private int gearCounts = 50;
    //초기에 아이템 n개를 생성해서 콜렉터에게 넘겨줘야함.
    

    //랜덤 생성넣기
    public void GenerateItem(ItemData itemData)
    {
        for (int i = 0; i < items.Length; i++) 
        {
            if (itemData.items[i].code <= gearCounts)
            {
                generator =  new GearGenerator();
                items[i] =generator.CreatItem(itemData.items[i]);
                Debug.Log(items[i].price);
            }
            else if (itemData.items[i].code > gearCounts)
            {
                generator = new PotionGenerator();
                items[i] = generator.CreatItem(itemData.items[i]);
                Debug.Log(items[i].price);
            }
        }
    }


    void Geretate()
    {

    }

    public Item GetItemInfo(int _itemCode)
    {
        var item = GameObject.Find($"{_itemCode}");
        return item.GetComponent<Item>();
        //여기서 해당하는 아이템 코드를 입력해서 찾아줌.
    }
}
