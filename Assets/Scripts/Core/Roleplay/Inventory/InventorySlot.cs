using Core.Events;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Core.Roleplay.Inventory
{

    [System.Serializable]
    [RequireComponent(typeof(CanvasGroup))]
    public class InventorySlot : EventComponent, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public Image icon;
        public Image Background;
        public Image NullItem;
        public TextMeshProUGUI amountText;
        public List<ItemTags> allowedTags;
        public bool isEquipSlot;

        public SlotData data;

        private Transform originalParent;
        private Canvas canvas;
        private CanvasGroup canvasGroup;

        public GameObject ghostIcon;
        public static GameObject currentGhost;

        private void Awake()
        {
            canvas = GetComponentInParent<Canvas>();
            canvasGroup = GetComponent<CanvasGroup>();
        }
        public bool CanAccept(Item item)
        {
            if (item == null) return true; // для очистки слота
            if (allowedTags == null || allowedTags.Count == 0) return true; // если ограничений нет

            foreach (var tag in item.Tags)
                if (allowedTags.Contains(tag)) return true;

            return false;
        }
        public void Set(SlotData slot)
        {
            data = slot;
            RefreshData();
        }
        #region Display
        public void OnPointerEnter(PointerEventData eventData)
        {
            Background.color = UnityEngine.Color.green;
            if (data.item != null)
                ItemTooltip.Instance.Show(data.item.description, eventData.position);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Background.color = UnityEngine.Color.white;
            ItemTooltip.Instance.Hide();
        }

        #endregion
        #region Drag`n`drop
        public void OnBeginDrag(PointerEventData eventData)
        {
            originalParent = transform.parent;
            transform.SetParent(canvas.transform);
            canvasGroup.blocksRaycasts = false;

            if (ghostIcon != null && data.item != null)
            {
                currentGhost = Instantiate(ghostIcon, canvas.transform);
                var img = currentGhost.GetComponent<Image>();
                img.sprite = icon.sprite;
                img.raycastTarget = false;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
            if (currentGhost != null)
                currentGhost.transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
            canvasGroup.blocksRaycasts = true;

            if (currentGhost != null)
            {
                Destroy(currentGhost);
                currentGhost = null;
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            var dropped = eventData.pointerDrag?.GetComponent<InventorySlot>();
            if (dropped == null || dropped == this) return;
            if (!CanAccept(dropped.data.item)) return;
            if (data.item != null && dropped.data.item != null && data.item == dropped.data.item && data.item.stackable)
            {
                int transferAmount = Mathf.Min(dropped.data.amount, data.item.maxStack - data.amount);
                data.amount += transferAmount;
                dropped.data.amount -= transferAmount;

                if (dropped.data.amount <= 0)
                {
                    dropped.data.item = null;
                    dropped.data.amount = 0;
                }
            }
            else
            {
                (data.item, dropped.data.item) = (dropped.data.item, data.item);
                (data.amount, dropped.data.amount) = (dropped.data.amount, data.amount);
            }
            if(isEquipSlot || dropped.isEquipSlot) { 
                if (data.item != null && data.item is Equipment e)
                {
                    ComponentSystem.TriggerEvent(this, new EquipEvent(e, isEquipSlot));
                }
                if (dropped.data.item != null && dropped.data.item is Equipment s)
                {
                    ComponentSystem.TriggerEvent(this, new EquipEvent(s, !isEquipSlot));
                }
            }
            RefreshData();
            dropped.RefreshData();
        }

        #endregion
        #region Base
        public InventorySlot(Item item, int amount)
        {
            this.data.item = item;
            this.data.amount = amount;
        }

        public void Add(int value) => data.amount += value;
        public void Remove(int value) => data.amount -= value;
        private void OnValidate()
        {
            RefreshData();
        }
        public void RefreshData()
        {
            if (data.item != null)
            {
                if(NullItem != null) NullItem.gameObject.SetActive(false); 
                icon.sprite = data.item.icon;
                var temp = icon.color;
                temp.a = 1;
                icon.color = temp;
                amountText.text = data.amount > 1 ? data.amount.ToString() : "";
            }
            else
            {
                if (NullItem != null) NullItem.gameObject.SetActive(true);
                var temp = icon.color;
                temp.a = 0;
                icon.color = temp;
                data.amount = 0;
                amountText.text = "";
            }
        }
        #endregion
    }
}