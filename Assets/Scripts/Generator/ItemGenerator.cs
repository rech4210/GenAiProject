using UnityEngine;

public abstract class ItemGenerator
{
    public static ItemGenerator instance;

    public abstract Item CreatItem(ItemStruct itemStruct);
}
