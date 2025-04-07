using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventory;

    public GameObject slotPrefab;

    public GameObject errorPanel;
    public float PopupErrorDuration = 1f;

    public Transform contentParent;
    public RectTransform buyBoxButton;

    public int startingSlots = 6;
    public int maxSlots = 100;

    private List<GameObject> slotList = new List<GameObject>();

    private void Start()
    {
        InitInventory();
        errorPanel.SetActive(false);
    }

    void InitInventory()
    {
        for (int i = 0; i < startingSlots; i++)
        {
            AddSlot();
        }
    }

    public void AddSlot()
    {
        if(slotList.Count >= maxSlots) return;

        GameObject newSlot = Instantiate(slotPrefab);
        int insertIndex = contentParent.childCount - 1;
        newSlot.transform.SetParent(contentParent);
        newSlot.transform.SetSiblingIndex(insertIndex);

        slotList.Add(newSlot);
    }

    public void PopupError()
    {
        StartCoroutine(ShowErrorPopupForSeconds(1f));
    }

    IEnumerator ShowErrorPopupForSeconds(float seconds)
    {
        errorPanel.SetActive(true);
        yield return new WaitForSeconds(seconds);
        errorPanel.SetActive(false);
    }

    public void CloseInventory()
    {
        inventory.SetActive(false);
    }
}
