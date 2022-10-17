using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickArrow : MonoBehaviour
{
	public UnityEvent onArrowClick;
	
	public void OnMouseDown()
	{
		onArrowClick.Invoke();
	}
}
