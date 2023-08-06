using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Collecter : MonoBehaviour, ISetInfo
{
    CuriosCollect curiosCollect = null;
    Collecterinfo info = null;
    public TextMeshProUGUI textMeshProUGUI = null;

    public void Init()
    {
        if (this.gameObject.transform.parent.TryGetComponent(out CuriosCollect curiosCollect))
        {
            this.curiosCollect = curiosCollect;
            info = curiosCollect.GetCollectInfo();
            Debug.Log(info);
        }
        else
        {
            Debug.Log("collecter null!");
        }
        SetTargetInfo();
    }

    public void SetTargetInfo()
    {
        if (this.transform.GetChild(1).GetChild(0)
            .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI name))
        {
            name.text = info.collecterName;
        }
        else Debug.Log ("Not Setted Object You're null!!");

        if (this.transform.GetChild(2).GetChild(0)
            .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI dialouge))
        {
            textMeshProUGUI = dialouge;
            DialgueManager.Instance.SetTMP(textMeshProUGUI);
            DialgueManager.Instance.StartDialogue(info.collecterText);
        }
        else Debug.Log("Not Setted Object You're null!!");


        if (this.transform.GetChild(1).TryGetComponent<Image>(out Image collecterImage))
        {

            collecterImage.sprite = Resources.Load<Sprite>(Path.Combine("Image/", info.collecterImage));
            if (collecterImage.sprite == null)
            {
                Debug.Log($"There is no resource__{info.collecterImage} at: " + Path.Combine("Image/", info.collecterImage));
            }
        }
        else
        {
            Debug.Log("wrong Path in child frontImage");
        }

        if (this.transform.GetChild(0).TryGetComponent<Image>(out Image backImage))
        {

            backImage.sprite = Resources.Load<Sprite>(Path.Combine("Image/", info.collecterBackground));
            if (backImage.sprite == null)
            {
                Debug.Log($"There is no resource__{info.collecterBackground} at: " + Path.Combine("Image/", info.collecterBackground));
            }
        }
        else
        {
            Debug.Log("wrong Path in child backImage");
            //수정하기 해상도 관련해서요
        }
    }
}
