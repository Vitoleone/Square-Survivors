using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectItems : MonoBehaviour
{
    public int numberOfColumn;
    public int xStart;
    public int yStart;
    public int xSpaceBetweenItems;
    public int ySpaceBetweenItems;
    int randomItemIndex;
    public EquippedItems selectorItem;
    Transform nameText, descriptionText, levelText,newText;
    public List<GameObject> ShownedObject;
    Dictionary<ItemSlot, GameObject> itemsDisplayed = new Dictionary<ItemSlot, GameObject>();
    
    void Start()
    {
        
        ShownedObject = new List<GameObject>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    public void DisplayItems()
    {
        gameObject.SetActive(true);
        for (int i = 0; i < 3; i++)
        {
            randomItemIndex = Random.Range(0, selectorItem.items.Count);//random item getirmek i�in int de�er.
            
            
            if(!ShownedObject.Contains(selectorItem.items[randomItemIndex].item.prefab))//E�er bir obje daha �nce listelenmi�se ve listede varsa buraya girmez ki bir kere g�sterilir.
            {
                var obj = Instantiate(selectorItem.items[randomItemIndex].item.prefab, Vector3.zero, Quaternion.identity, transform);

                ShownedObject.Add(selectorItem.items[randomItemIndex].item.prefab);//Ayn� silah 2 kez g�z�kmesin diye ekledik

                nameText = obj.transform.Find("ItemName");
                descriptionText = obj.transform.Find("ItemDescription");
                levelText = obj.transform.Find("ItemLevel");
                newText = obj.transform.Find("NewText");

                nameText.GetComponent<TextMeshProUGUI>().text = selectorItem.items[randomItemIndex].item.itemName;
                descriptionText.GetComponent<TextMeshProUGUI>().text = selectorItem.items[randomItemIndex].item.description;
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

                if (selectorItem.items[randomItemIndex].item.itemLevel == 0)//item ilk defa g�z�k�yorsa New yazacak ve leveli g�z�kmeyecek.
                {
                    newText.gameObject.SetActive(true);
                    levelText.gameObject.SetActive(false);
                    Debug.Log("girdi");
                }
                else
                {
                    
                    levelText.GetComponent<TextMeshProUGUI>().text = "Level: " + selectorItem.items[randomItemIndex].item.itemLevel.ToString();
                    newText.gameObject.SetActive(false);
                    levelText.gameObject.SetActive(true);
                   
                }
                
            }
            else
            {
                i--;
            }
            
          

        }
    }
    public Vector3 GetPosition(int i)
    {
        return new Vector3(xStart + (xSpaceBetweenItems * (i % numberOfColumn)), yStart + (-ySpaceBetweenItems * (i / numberOfColumn)), 0f);
    }
}
