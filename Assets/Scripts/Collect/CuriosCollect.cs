using UnityEngine;

public class CuriosCollect : MonoBehaviour
{
    //private int itemCode = 0;
    private int honor;
    public int itemCount;

    Item[] items;
    Collecterinfo[] collecterinfos = new Collecterinfo[20];
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
        collecter.Start();
        //DataManager.Instance.JsonItemParsing();
        //���⼭ ��ü �����ϰ� �������� �� ����
    }

    public Collecterinfo GetCollectInfo()
    {
        return collecterinfos[Random.Range(0, 10)];
        //exclusive
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
                DialgueManager.Instance.StartDialogue(collecter.textMeshProUGUI.text);
            }
            else
            {
                ResourceManager.Instance.AddHonor(-50);
            }
        }
    }
}
