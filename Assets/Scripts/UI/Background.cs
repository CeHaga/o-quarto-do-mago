using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background
{
	public GameObject background;
	public bool isAccessible;
	
	public void Accessible(bool accessible)
	{
		isAccessible = accessible;
	}
}
