using TMPro;
using UnityEngine;
using UnityEngine.UI;

public struct Resource
{
    public int money;
    public int honor;
    public Resource(int money, int _honor)
    {
        this.money = money;
        this.honor = _honor;
    }
}

public class ResourceManager : Manager<ResourceManager>
{

    public TMP_Text moneyText;
    public TMP_Text honorText;
    private Resource resource;


    public Resource Resource { get { return resource; }}

    private void Start()
    {
        resource = new Resource(50, 100);
        SetText();
    }
    public void AddMoney(int _money)
    {
        resource.money += _money;
        SetText();
    }

    public void AddHonor(int _honor)
    {
        resource.honor += _honor ;
        SetText();
    }

    void SetText()
    {
        moneyText.text = "µ·" + resource.money;
        honorText.text = "¸í¿¹" + resource.honor;
    }
}
