using UnityEngine;
using UnityEngine.UI;

public class OpenTarget : MonoBehaviour
{
    public GameObject targetObj;
    bool state = false;
    private void Start()
    {
        targetObj.transform.GetChild(0).gameObject.SetActive(false);
        this.gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (state == false)
            {
                state = true;
                targetObj.transform.GetChild(0).gameObject.SetActive(state);
            }
            else
            {
                state = false;
                targetObj.transform.GetChild(0).gameObject.SetActive(state);

            }
        });
        
    }
}
