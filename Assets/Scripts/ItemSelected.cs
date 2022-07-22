using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSelected : MonoBehaviour
{
    // Start is called before the first frame update
    public EquippedItems selectorItem;
    public EquippedItems equippedItems;
    



    GameObject ItemSelectorPanel;
    

    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectItem()
    {
        ItemSelectorPanel = GameObject.Find("ItemSelector");
        

        foreach (Transform child in ItemSelectorPanel.transform)//Burada daha önceden instantiate edilmiþ objeleri siliyoruz
        {
            Destroy(child.gameObject);
        }
        var itemPanelInSelector = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.Find("ItemName").gameObject;
        for (int i = 0; i < selectorItem.items.Count; i++)
        {
            
            if(selectorItem.items[i].item.itemName == itemPanelInSelector.GetComponent<TextMeshProUGUI>().text)
            {

                equippedItems.AddItem(selectorItem.items[i].item.prefab.GetComponent<ItemHolder>().item, 1);//itemSelectore baðlý olan prefabýn itemýný aldýk ve ekledik. Burasý sayesinde seçtiðimiz item sol altta gözüküyor.

                selectorItem.items[i].item.itemLevel++;
                selectorItem.items[i].item.prefab.GetComponent<ItemHolder>().item.itemLevel = selectorItem.items[i].item.itemLevel;//burasý sol altta gözüken itemin levelini item leveline eþitliyor.

                Time.timeScale = 1;
                ItemSelectorPanel.SetActive(false);
                ItemSelectorPanel.GetComponent<SelectItems>().ShownedObject.Clear();//Daha önceden gösterilmiþ itemlarýn listesini temizleriz.
                
            }
        }
        

    }

    private void OnApplicationQuit()
    {
        for (int i = 0; i < selectorItem.items.Count; i++)
        {
            selectorItem.items[i].item.itemLevel = 1;
        }
    }

}
