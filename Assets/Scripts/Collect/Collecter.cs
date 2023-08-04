using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collecter : MonoBehaviour
{
    CuriosCollect curiosCollect = null;
    Collecterinfo info = null;


    public void Start()
    {
        if(this.gameObject.transform.parent.TryGetComponent(out CuriosCollect curiosCollect))
        {
            this.curiosCollect = curiosCollect;
            info = curiosCollect.GetCollectInfo();
        }
        else
        {
            Debug.Log("collecter null!");
        }
        SetCollecter();


    }

    //배경, 
    void SetCollecter()
    {
        if (this.transform.GetChild(1).GetChild(0)
            .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI name))
        {
            name.text = info.collecterName;
        }
        else Debug.LogError("Not Setted Object You're null!!");

        if (this.transform.GetChild(2).GetChild(0)
            .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI dialouge))
        {
            dialouge.text = info.collecterText;
        }
        else Debug.LogError("Not Setted Object You're null!!");


        if (this.transform.GetChild(1).TryGetComponent<Image>(out Image collecterImage))
        {

            collecterImage.sprite = Resources.Load<Sprite>(Path.Combine("BuffCardResource/", info.collecterImage));
            if (collecterImage.sprite == null)
            {
                Debug.Log($"There is no resource__{info.collecterImage} at: " + Path.Combine(Application.dataPath + "/BuffCardResource/", ""));
            }
        }
        else
        {
            Debug.Log("wrong Path in child frontImage");
        }

        if (this.transform.GetChild(0).TryGetComponent<Image>(out Image backImage))
        {

            backImage.sprite = Resources.Load<Sprite>(Path.Combine("BuffCardResource/", info.collecterBackground));
            if (backImage.sprite == null)
            {
                Debug.Log($"There is no resource__{info.collecterBackground} at: " + Path.Combine(Application.dataPath + "/BuffCardResource/", ""));
            }
        }
        else
        {
            Debug.Log("wrong Path in child backImage");
            //수정하기 해상도 관련해서요
        }
        //this.transform.GetChild(0).GetChild(1).GetComponent<TextMeshPro>().text = cardInfo.BuffEnumName;
        //this.transform.GetChild(2).GetComponent<TextMeshPro>().text = cardInfo.information;
        //this.transform.GetChild(3).GetComponent<TextMeshPro>().text = cardInfo.description;

        //this.GetComponent<Image>().sprite = cardInfo.FRImage;
        //data = buffManager.SetBuffData(buffCode, stat);
        //Debug.Log(stat);
    }

}
