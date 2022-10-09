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
	
	public void RemoveItem(ItemInventory item)
	{
		inventory.Remove(item);
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
