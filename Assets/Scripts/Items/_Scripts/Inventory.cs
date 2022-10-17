using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory", order = 0)]
public class Inventory : ScriptableObject
{
	private ArrayList inventory = new ArrayList();
	
	public void AddItem(ItemInventory item)
	{
		inventory.Add(item);
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
		inventory.Remove(item);
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
		return inventory.Contains(item);
	}
	
	public bool HasItems(ItemInventory[] item)
	{
		foreach (ItemInventory i in item)
		{
			if (!inventory.Contains(i))
			{
				return false;
			}
		}
		return true;
	}
	
}
