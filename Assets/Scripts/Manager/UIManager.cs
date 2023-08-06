using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.Diagnostics;

public class UIManager : Manager<UIManager>
{
    public GameObject RootUI;
    public GameObject target;

    public delegate void mydele();
    public mydele mydele1;

    Stack<UI_PopUp> stackUI = new Stack<UI_PopUp>();

    private void Start()
    {
        SetRootUI();
    }


    public void GetActive(Button button,GameObject target)
    {
        button.onClick.AddListener(() => 
        {
            target.SetActive(true);
        });
    }

    // 이 부분을 인스턴스로
    public void SetRootUI()
    {
        if(FindObjectOfType<CuriosCollect>() == false)
        {
            var collect = Instantiate(RootUI,target.transform);
            collect.transform.SetAsFirstSibling();
        }
        RootUI.SetActive(true);
    }


    public void SetCanvas()
    {
        //Canvas canvas = Util.Getor
    }


    public void MatchUIWithMethod(Selectable selectable)
    {
        //selectable.GetComponent<Button>().onClick = mydele1.Method;
    }
}
