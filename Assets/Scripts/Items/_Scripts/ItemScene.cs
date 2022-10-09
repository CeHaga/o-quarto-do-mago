using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemScene", menuName = "Items/Scene", order = 0)]
public class ItemScene : ScriptableObject {
	public new string name;
	public Inventory inventory;
	
	public ItemInventory[] necessaryItems;
	public ItemInventory[] rewards;
	public ItemScene newItemScene;
	
	public Dialog[] availableDialogs;
	public Dialog[] unavailableDialogs;
	
	public bool interacted;
	
	public bool IsAvailable(Inventory inventory)
	{
		return inventory.HasItems(necessaryItems);
	}
}
