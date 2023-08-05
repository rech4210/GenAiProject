using UnityEngine;

public class ItemManager : Manager<ItemManager>
{
    public Item[] items = new Item[100];
    ItemGenerator generator;
    private int gearCounts = 50;
    //�ʱ⿡ ������ n���� �����ؼ� �ݷ��Ϳ��� �Ѱ������.
    

    //���� �����ֱ�
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
        //���⼭ �ش��ϴ� ������ �ڵ带 �Է��ؼ� ã����.
    }
}
