using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CuriosCollect : MonoBehaviour
{
    //private int itemCode = 0;
    private int honor;
    public int itemCount;

    Item[] items;
    Collecterinfo[] collecterinfos;
    Collecter collecter = null;
    void BuyItem(int itemPrice)
    {
         ResourceManager.Instance.AddMoney(itemPrice);
         ResourceManager.Instance.AddHonor(honor);
    }

    private void Start()
    {
        items = ItemManager.Instance.items;
        collecterinfos = DataManager.Instance.collecterInfos;
        collecter = transform.GetChild(0).gameObject.AddComponent<Collecter>();
        collecter.Init();

        //여기서 개체 생성하고 가져오기 후 저지
    }

    public Collecterinfo GetCollectInfo()
    {
        if (collecterinfos == null)
        {
            collecterinfos = DataManager.Instance.collecterInfos;
        }
        Debug.Log(collecterinfos.Length);
        return collecterinfos[Random.Range(0,collecterinfos.Length)];
        //exclusive
    }

    // 버튼을 눌러 사용
    void GedgePrice(int suggestPrice)
    {
        // 아이템 개체 가져옴
        items = new Item[itemCount];
        for (int i = 0; i < itemCount; i++)
        {
            //절대값이 
            if (Mathf.Abs(suggestPrice - items[i].price) < suggestPrice * 0.1f)
            {
                //명예에 따라 가격이 달라지도록.
                BuyItem(suggestPrice);
                DialgueManager.Instance.StartDialogue(collecter.textMeshProUGUI.text);
            }
            else
            {
                ResourceManager.Instance.AddHonor(-50);
            }
        }
    }
}
