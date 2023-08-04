using System.Diagnostics;
using System.Drawing;
using UnityEngine;

public class GearGenerator : ItemGenerator
{
    public GearGenerator()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    public override Item CreatItem(ItemStruct itemStruct)
    {
        return new Gears(itemStruct.code, itemStruct.price, itemStruct.honor, itemStruct.grade, itemStruct.Image);
    }
}
