using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateMaterialObject : MonoBehaviour
{
    public GameObject materialPrefab;
    public GameObject GenPos;
    int count;

    public void Start()
    {
        count = 0;
        GenPos = this.gameObject.transform.parent.gameObject;
        StartCoroutine(MakeObjects());
        //gameObject.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() =>
        //{
        //});
    }

    IEnumerator MakeObjects()// ������ �����Ϳ� ����ǵ��� ����.
    {
        while (count <25 )
        {
            Instantiate(materialPrefab, this.gameObject.transform);
            count++;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
