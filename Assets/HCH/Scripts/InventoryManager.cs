using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;

    public Transform contentParent;
    public RectTransform buyBoxButton;

    public int startingSlots = 6;
    public int maxSlots = 100;

    private List<GameObject> slotList = new List<GameObject>();

    private void Start()
    {
        InitInventory();
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
}
