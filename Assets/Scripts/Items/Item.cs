using UnityEngine;

public abstract class Item
{
    public int code;
    public int price;
    public int honor;
    public int grade;
    public string image;

    public Item(int code, int price, int honor, int grade, string imager)
    {
        this.code = code;
        this.price = price;
        this.honor = honor;
        this.grade = grade;
        this.image = imager;
    }
    // �����, ����, ���� �� ���ʷ�
}
