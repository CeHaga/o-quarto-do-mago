using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemInventory", menuName = "Items/Inventory", order = 0)]
public class ItemInventory : ScriptableObject {
	public new string name;
	public Sprite sprite;
}
