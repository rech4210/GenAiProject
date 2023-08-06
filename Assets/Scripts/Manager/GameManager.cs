
public class GameManager : Manager<GameManager>
{
    private void Awake()
    {
        //DataManager.Instance.SaveCollecterJson();
        //DataManager.Instance.SaveItemJson();
        //DataManager.Instance.SaveMaterialJson();
        DataManager.Instance.JsonItemParsing();
        DataManager.Instance.JsonMaterialParsing();
        DataManager.Instance.JsonCollecterParsing();


        UIManager.Instance.SetRootUI();
        DataManager.Instance.SetCreateTabe();
        ItemManager.Instance.ChangeCode(0);

    }


    void Day()
    {
        //day++;
    }
}
