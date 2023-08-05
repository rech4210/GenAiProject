
public class GameManager : Manager<GameManager>
{
    private void Awake()
    {
        //DataManager.Instance.SaveCollecterJson();
        //DataManager.Instance.SaveItemJson();
        DataManager.Instance.JsonItemParsing();
        DataManager.Instance.JsonCollecterParsing();
    }
}
