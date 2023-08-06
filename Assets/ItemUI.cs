using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour, ISetInfo
{
    List<Material> materials;
    MaterialStruct materialStruct;
    
    // Start is called before the first frame update
    void Start()
    {
        materials = ResourceManager.Instance.userInventoryMaterial;
        Material material1 = materials[Random.Range(0, ResourceManager.Instance.userInventoryMaterial.Count)];
        materialStruct.code = material1.code;
        materialStruct = ItemManager.Instance.materials[materialStruct.code];


        SetTargetInfo();
    }

    public void SetTargetInfo()
    {
        if (this.transform.GetChild(0).GetChild(0)
            .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI name))
        {
            name.text = materialStruct.name;
        }
        else Debug.Log("Not Setted Object You're null!!");


        if (this.transform.GetChild(0).TryGetComponent<Image>(out Image collecterImage))
        {

            collecterImage.sprite = Resources.Load<Sprite>(Path.Combine("Image/", materialStruct.Image));
            if (collecterImage.sprite == null)
            {
                Debug.Log($"There is no resource__{materialStruct.Image} at: " + Path.Combine("Image/", materialStruct.Image));
            }
        }
        else
        {
            Debug.Log("wrong Path in child frontImage");
        }
    }

}
