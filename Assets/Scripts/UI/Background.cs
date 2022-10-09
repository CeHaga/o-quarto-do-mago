using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Background
{
	public GameObject background;
	public Item[] necessaryItems;
	
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
