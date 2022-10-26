using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickItem : MonoBehaviour
{
	public ItemScene item;
	public DialogEvent playDialog;
	
	public void OnMouseDown()
	{
		if(GameStateManager.gameState == GameState.Playing && !item.interacted)
		{
			if(item.available)
			{
				ItemAvailable();
			}else
			{
				ItemUnavailable();
			}
		}
	}
	
	private void ItemAvailable()
	{
		item.interacted = true;
		playDialog.Invoke(item.availableDialogs);
		Inventory.inventory.RemoveItems(item.necessaryItems);
		Inventory.inventory.AddItems(item.rewards);
	}
	
	private void ItemUnavailable()
	{
		playDialog.Invoke(item.unavailableDialogs);
	}
}
