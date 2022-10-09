using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Background
{
	public GameObject background;
	public Inventory inventory;
	public ItemInventory[] necessaryItems;
	
	public bool IsAvailable()
	{
		return inventory.HasItems(necessaryItems);
	}	
}
