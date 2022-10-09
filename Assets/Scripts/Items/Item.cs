using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
public class Item : ScriptableObject {
	public new string name;
	public string description;
	public Item[] necessaryItems;
	
	public bool inInventory;
	public void SetInInventory(bool inInventory)
	{
		this.inInventory = inInventory;
	}
	
	public bool IsAvailable()
	{
		foreach (Item item in necessaryItems)
		{
			if (!item.inInventory)
			{
				return false;
			}
		}
		return true;
	}
}
