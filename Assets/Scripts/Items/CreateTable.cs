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

    // 이 딕셔너리 채워넣어야함.
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
        Debug.Log("합성 성공");
        return  ItemManager.Instance.GetItemInfo(targetCode);
    }
    /*
     * 1. 제작판 생성
     * 2. 플레이어가 아이템 선택
     * 3. 선택시 테이블에서 필요 재료 호출
     * 4. 아이템 클릭시 제작칸에 배치 (CheckContribute)
     * 5. 모두 배치하고 나면 제작버튼 활성  (mix)
     * 
     */

    //public void AddIngredientFromUser(Material ingredient)
    //{
    //    materials[0] = ingredient;
    //    //버튼을 누르면...
    //    // 개수는 어떻게 넣을거?

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
            Debug.Log("타겟 코드가 잘못 설정되었습니다 설정해주세요");
        }
        else
        {
            //아이템 정보 탐색
            Item item = ItemManager.Instance.GetItemInfo(targetCode);
            //내 재료 탐색으로 변경
            // value 에서 array ingredient null뜬다.
            if (createTable.TryGetValue(item.code, out Recipe value))
            {
                if(value.recipeCode == item.code)
                {
                    if (value.CheckRecipe(item.recipe.ingredientDictionary))
                    {
                        //인벤토리에 개체가 안들어있어서 발생하는 오류.
                        var mats = ResourceManager.Instance.GetMaterialFromInventory(item.recipe);
                        foreach (var mat in mats)
                        {
                            if (mat !=  null)
                            {

                                materials.Add(mat);
                            }
                        }

                        Item _item = mix(targetCode);
                        Debug.Log(_item.name + $"아이템 제작에 사용됨: {_item.recipe.ingredientArray[0].code}");
                        ResourceManager.Instance.GetInventory();

                        //if (ResourceManager.Instance.CheckInventoryMaterial(materials))
                        //{

                        //}
                    }
                    //
                }
                    //최종 결과로 유저가 제시한 레시피와 동일하다면 합성
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
