using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSelected : MonoBehaviour
{
    // Start is called before the first frame update
    public EquippedItems selectorItem;
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
        var gap = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.Find("ItemName").gameObject;
        for (int i = 0; i < selectorItem.items.Count; i++)
        {
            if(selectorItem.items[i].item.itemName == gap.GetComponent<TextMeshProUGUI>().text)
            {
               
                selectorItem.items[i].item.itemLevel++;
                Time.timeScale = 1;
                ItemSelectorPanel.SetActive(false);
                ItemSelectorPanel.GetComponent<SelectItems>().ShownedObject.Clear();//sonradan
                
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
