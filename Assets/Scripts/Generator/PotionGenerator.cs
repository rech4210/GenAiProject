using UnityEngine;

public class PotionGenerator : ItemGenerator
{
    public PotionGenerator()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    public override Item CreatItem(ItemStruct itemStruct)
    {
        return new Potion(itemStruct.code, itemStruct.price, itemStruct.honor, itemStruct.grade, itemStruct.Image);
    }
}
