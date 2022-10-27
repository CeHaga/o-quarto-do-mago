using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickArrow : MonoBehaviour
{
	public UnityEvent onArrowClick;
	public DialogEvent playDialog;
	public ItemScene item;
	private bool interacted;
	
	private void Start()
	{
		interacted = false;
	}
	
	public void OnMouseDown()
	{
		if(GameStateManager.gameState == GameState.Playing)
		{
			if(item != null && item.available && !interacted)
			{
				interacted = true;
				Inventory.inventory.RemoveItems(item.necessaryItems);
				playDialog.Invoke(item.availableDialogs, null);
				Inventory.inventory.AddItems(item.rewards);
				gameObject.SetActive(false);
			}
			else
			{
				onArrowClick.Invoke();
			}
		}
	}
}
