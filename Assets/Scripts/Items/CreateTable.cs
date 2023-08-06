using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CreateTable : MonoBehaviour
{
    //RequireMaterial[] require;
    List<Material> materials = new List<Material>();

    public Button combineButton;
    public Button upButton;

    // �� ��ųʸ� ä���־����.
    private Dictionary<int, Recipe> createTable;

    private void Start()
    {
        combineButton.onClick.AddListener(() =>
        {
            if (this.gameObject.activeSelf) 
            {
                CheckContribute(ItemManager.Instance.GetCodeForCreate());
            }
            //CheckContribute(ItemManager.Instance.GetCodeForCreate());
        });
        upButton.onClick.AddListener(() =>
        {
            if (this.gameObject.activeSelf)
            {
                ItemManager.Instance.createCode++;
                Debug.Log(ItemManager.Instance.GetCodeForCreate());
            }
        });
    }

    public Item mix(int targetCode)
    {
        ResourceManager.Instance.RemoveMaterial(materials);
        Debug.Log("�ռ� ����");
        return  ItemManager.Instance.GetItemInfo(targetCode);
    }
    /*
     * 1. ������ ����
     * 2. �÷��̾ ������ ����
     * 3. ���ý� ���̺��� �ʿ� ��� ȣ��
     * 4. ������ Ŭ���� ����ĭ�� ��ġ (CheckContribute)
     * 5. ��� ��ġ�ϰ� ���� ���۹�ư Ȱ��  (mix)
     * 
     */

    //public void AddIngredientFromUser(Material ingredient)
    //{
    //    materials[0] = ingredient;
    //    //��ư�� ������...
    //    // ������ ��� ������?

    //    userRecipe.AddRecipe(new Ingredient());
    //}


    public void CheckContribute(int targetCode)
    {
        if (createTable == null)
        {
            createTable = DataManager.Instance.createTable;
        }
        if (targetCode > 100 )
        {
            Debug.Log("Ÿ�� �ڵ尡 �߸� �����Ǿ����ϴ� �������ּ���");
        }
        else
        {
            //������ ���� Ž��
            Item item = ItemManager.Instance.GetItemInfo(targetCode);
            //�� ��� Ž������ ����
            // value ���� array ingredient null���.
            if (createTable.TryGetValue(item.code, out Recipe value))
            {
                if(value.recipeCode == item.code)
                {
                    if (value.CheckRecipe(item.recipe.ingredientDictionary))
                    {
                        //�κ��丮�� ��ü�� �ȵ���־ �߻��ϴ� ����.
                        var mats = ResourceManager.Instance.GetMaterialFromInventory(item.recipe);
                        foreach (var mat in mats)
                        {
                            if (mat !=  null)
                            {

                                materials.Add(mat);
                            }
                        }

                        Item _item = mix(targetCode);
                        Debug.Log(_item.name + $"������ ���ۿ� ����: {_item.recipe.ingredientArray[0].code}");
                        ResourceManager.Instance.GetInventory();

                        //if (ResourceManager.Instance.CheckInventoryMaterial(materials))
                        //{

                        //}
                    }
                    //
                }
                    //���� ����� ������ ������ �����ǿ� �����ϴٸ� �ռ�
                else
                {
                    Debug.Log("recipe is not defined");

                    //itemRecipe.ingredientList[1].GetInformation();
                    materials.Clear();
                }
            }
            else
            {
                Debug.Log("code is not defined");
            }
        }
        
    }
}
