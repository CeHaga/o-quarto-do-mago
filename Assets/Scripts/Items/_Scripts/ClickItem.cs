using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickItem : MonoBehaviour
{
	public Inventory inventory;
	public ItemScene item;
	public DialogEvent playDialog;
	
	public void OnMouseDown()
	{
		if(item.available)
		{
			ItemAvailable();
		}else
		{
			ItemUnavailable();
		}
	}
	
	private void ItemAvailable()
	{
		inventory.RemoveItems(item.necessaryItems);
		inventory.AddItems(item.rewards);
		playDialog.Invoke(item.availableDialogs);
	}
	
	private void ItemUnavailable()
	{
		playDialog.Invoke(item.unavailableDialogs);
	}
}
