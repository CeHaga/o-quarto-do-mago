using UnityEngine;
using TMPro;

public class InventoryPanel : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI inventoryText;	
	
	void Update()
	{
		if(GameStateManager.gameState == GameState.Playing)
		{
			inventoryText.text = Inventory.inventory.ToString();
		}	
	}
}
