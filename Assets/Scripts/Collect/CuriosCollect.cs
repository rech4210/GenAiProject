using UnityEngine;

public class CuriosCollect : MonoBehaviour
{
    //private int itemCode = 0;
    private int honor;
    public int itemCount;

    Item[] items;
    void BuyItem(int itemPrice)
    {
         ResourceManager.Instance.AddMoney(itemPrice);
         ResourceManager.Instance.AddHonor(honor);
    }

    private void Start()
    {
        items = ItemManager.Instance.items;
        //DataManager.Instance.JsonItemParsing();
        //���⼭ ��ü �����ϰ� �������� �� ����
    }

    // ��ư�� ���� ���
    void GedgePrice(int suggestPrice)
    {
        // ������ ��ü ������
        items = new Item[itemCount];
        for (int i = 0; i < itemCount; i++)
        {
            //���밪�� 
            if (Mathf.Abs(suggestPrice - items[i].price) < suggestPrice * 0.1f)
            {
                //���� ���� ������ �޶�������.
                BuyItem(suggestPrice);
            }
            else
            {
                ResourceManager.Instance.AddHonor(-50);
            }
        }
    }
}
