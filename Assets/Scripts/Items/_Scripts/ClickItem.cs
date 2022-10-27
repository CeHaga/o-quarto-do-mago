using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickItem : MonoBehaviour
{
	public ItemScene item;
	public DialogEvent playDialog;
	
	private bool interacted;
	
	private void Start()
	{
		interacted = false;
	}
	
	public void OnMouseDown()
	{
		if(GameStateManager.gameState == GameState.Playing && !interacted)
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
		interacted = true;
		Inventory.inventory.RemoveItems(item.necessaryItems);
		playDialog.Invoke(item.availableDialogs, null);
		Inventory.inventory.AddItems(item.rewards);
	}
	
	private void ItemUnavailable()
	{
		playDialog.Invoke(item.unavailableDialogs, null);
	}
}
