using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemScene", menuName = "Items/Scene", order = 0)]
public class ItemScene : ScriptableObject {
	public new string name;
	public Item[] necessaryItems;
	public Item[] rewards;
	
	public Dialog[] availableDialogs;
	public Dialog[] unavailableDialogs;
	
	public bool inInventory;
	public bool interacted;
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
