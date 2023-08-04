using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
