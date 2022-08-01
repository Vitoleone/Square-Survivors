using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSelected : MonoBehaviour
{
    // Start is called before the first frame update
    public EquippedItems selectorItem;
    public EquippedItems equippedItems;
    public GameObject player;
    public GameObject itemPanelInSelector { get; set; }
    
    



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
        

        foreach (Transform child in ItemSelectorPanel.transform)//Burada daha �nceden instantiate edilmi� objeleri siliyoruz
        {
            Destroy(child.gameObject);
        }
        itemPanelInSelector = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.Find("ItemName").gameObject;//Panelde seçilen item
        for (int i = 0; i < selectorItem.items.Count; i++)
        {
            
            if(selectorItem.items[i].item.itemName == itemPanelInSelector.GetComponent<TextMeshProUGUI>().text)
            {
                
                equippedItems.AddItem(selectorItem.items[i].item.EquipmentItemAttributes, 1);//itemSelectore ba�l� olan prefab�n item�n� ald�k ve ekledik. Buras� sayesinde se�ti�imiz item sol altta g�z�k�yor.
                
                selectorItem.items[i].item.EquipmentItemAttributes.itemLevel++;
                selectorItem.items[i].item.EquipmentItemAttributes.itemLevel= selectorItem.items[i].item.EquipmentItemAttributes.itemLevel;//buras� sol altta g�z�ken itemin levelini item leveline e�itliyor.
                selectorItem.items[i].item.EquipmentItemAttributes.isLevelUp = true;
                
                Time.timeScale = 1;
                ItemSelectorPanel.SetActive(false);
                ItemSelectorPanel.GetComponent<SelectItems>().ShownedObject.Clear();//Daha �nceden g�sterilmi� itemlar�n listesini temizleriz.
                
            }
        }
       

    }

    private void OnApplicationQuit()
    {
        for (int i = 0; i < selectorItem.items.Count; i++)
        {
           
            selectorItem.items[i].item.EquipmentItemAttributes.itemLevel = 0;
            selectorItem.items[i].item.EquipmentItemAttributes.isNew = true;
        }
    }
    public GameObject GetSelectedItem()
    {
        return itemPanelInSelector;
    }
   
}
