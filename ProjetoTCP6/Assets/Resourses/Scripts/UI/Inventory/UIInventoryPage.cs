using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField] UIInventoryItem itemPrefab;

    [SerializeField] RectTransform contentPanel;

    List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

    public void InicializeInventoryUI(int inventorySize)
    {
        for(int i =0; i < inventorySize; i++)
        {
            UIInventoryItem uiItem = Instantiate(itemPrefab, contentPanel);
            uiItem.transform.localScale = new Vector3(1, 1, 1);



            listOfUIItems.Add(uiItem);

            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroped += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemActions;
        }
    }

    private void HandleShowItemActions(UIInventoryItem item)
    {

    }

    private void HandleEndDrag(UIInventoryItem item)
    {

    }

    private void HandleSwap(UIInventoryItem item)
    {

    }

    private void HandleBeginDrag(UIInventoryItem item)
    {

    }

    private void HandleItemSelection(UIInventoryItem item)
    {
        Debug.Log(item.name);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
