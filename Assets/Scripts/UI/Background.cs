using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Background
{
	public GameObject background;
	public GameState gameState;
	public ItemInventory[] necessaryItems;
	public Dialog[] cutsceneDialogs;
	[HideInInspector] public bool cutscenePlayed;
	public Dialog[] unavailableDialogs;
	
	public bool IsAvailable()
	{
		return Inventory.inventory.HasItems(necessaryItems);
	}	
}
