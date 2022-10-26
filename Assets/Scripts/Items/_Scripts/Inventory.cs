using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	[HideInInspector]
	public static Inventory inventory;
	
	private ArrayList inventoryList;
	
	private void Awake()
	{
		if (inventory != null && inventory != this)
		{
			Destroy(this.gameObject);
			return;
		}
		inventory = this;
		inventoryList = new ArrayList();
	}
	
	public void AddItem(ItemInventory item)
	{
		inventoryList.Add(item);
	}
	
	public void AddItems(ItemInventory[] items)
	{
		foreach (var item in items)
		{
			AddItem(item);
		}
	}
	
	public void RemoveItem(ItemInventory item)
	{
		inventoryList.Remove(item);
	}
	
	public void RemoveItems(ItemInventory[] items)
	{
		foreach (var item in items)
		{
			RemoveItem(item);
		}
	}
	
	public bool HasItem(ItemInventory item)
	{
		return inventoryList.Contains(item);
	}
	
	public bool HasItems(ItemInventory[] item)
	{
		foreach (ItemInventory i in item)
		{
			if (!inventoryList.Contains(i))
			{
				return false;
			}
		}
		return true;
	}
	
	public override string ToString()
	{
		string list = "";
		foreach (ItemInventory i in inventoryList)
		{
			list += i.name + "\n";
		}
		return list;
	}
}
