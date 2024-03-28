 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class UIInventoryItem : MonoBehaviour
{
    [SerializeField] Image itemImage;
    
    [SerializeField] TMP_Text quantityText;

    [SerializeField] Image borderImage;

    public event Action<UIInventoryItem> OnItemClicked, OnItemDroped, 
        OnItemBeginDrag, OnItemEndDrag, OnRightMouseBtnClick;

    bool empty = true;

    public void Awake()
    {
        ResetData();
        Deselect();
    }
    public void ResetData()
    {
        itemImage.gameObject.SetActive(false);
        empty = true;
    }
    public void Deselect()
    {
        borderImage.enabled = false;
    }
    public void SetData(Sprite sprite, int quantity)
    {
        itemImage.gameObject.SetActive(true);
        itemImage.sprite = sprite;
        quantityText.text = quantity + "";
        empty = false;
    }

    public void Select()
    {
        borderImage.enabled = true;
    }

    public void OnPointerClick(BaseEventData baseData)
    {
        if (empty)
            return;

        PointerEventData pointerData = (PointerEventData)baseData;
        if (pointerData.button == PointerEventData.InputButton.Right)
        { 
            OnRightMouseBtnClick?.Invoke(this);
        }
        else
        {
            OnItemClicked?.Invoke(this);
        }
    }

    public void OnEndDrag()
    {
        OnItemEndDrag?.Invoke(this);
    }

    public void OnBeginDrag()
    {
        if (empty)
            return;
        OnItemBeginDrag?.Invoke(this);
    }

    public void OnDrop()
    {
        OnItemDroped?.Invoke(this);
    }

    public void OnDrag()
    {

    }

}
