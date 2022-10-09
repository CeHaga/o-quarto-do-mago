using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackgroundController : MonoBehaviour
{
	public float movingTime = 1f;
	public float backgroundX;
	public float backgroundXPeek;
	public Background[] backgrounds;

	private int actualBackground; 
	private bool isMoving;

	private void Start()
	{
		actualBackground = 0;
		isMoving = false;
	}
	
	// Access element in array as a circular list
	private Background GetBackground(int index)
	{
		return backgrounds[(index + backgrounds.Length) % backgrounds.Length];
	}
	
	// Set background in edge position and return original position
	private Vector3 SetBackgroundEdge(int index, int offset, float x)
	{
		Transform background = GetBackground(index + offset).background.transform;
		Vector3 position = background.position;
		background.position = new Vector3(x * offset, 0, 0);
		return position;
	}
	
	// Set background in new position
	private void SetBackgroundPosition(int index, Vector3 position)
	{
		Transform background = GetBackground(index).background.transform;
		background.position = position;
	}
	
	// Move backgrounds using DOTween
	private IEnumerator MoveBackgrounds(int start, int end, float distance, float time, int direction)
	{
		int edge = direction > 0 ? start - 1 : end + 1;
		int newEdge = direction > 0 ? end : start;
		
		Vector3 oldPosition = SetBackgroundEdge(actualBackground, edge, backgroundX);
		
		for (int i = start; i <= end; i = (i + 1) % backgrounds.Length)
		{
			Transform background = GetBackground(i).background.transform;
			float x = background.position.x;
			background.DOMoveX(x + distance * direction, time);
		}
		yield return new WaitForSeconds(time);
		SetBackgroundPosition(actualBackground + newEdge, oldPosition);
		isMoving = false;
	}
 
	public void MoveLeft()
	{
		if (isMoving) return;
		isMoving = true;
		
		int nextBackground = (actualBackground - 1 + backgrounds.Length) % backgrounds.Length;
		
		if (backgrounds[nextBackground].IsAvailable())
		{
			Vector3 oldPosition = SetBackgroundEdge(actualBackground, -2, backgroundX);
			// StartCoroutine(MoveBackgrounds(actualBackground - 2, actualBackground + 1, 1, backgroundX, oldPosition));
			actualBackground = nextBackground;
		}
		else
		{
			// StartCoroutine(MoveBackgroundsNotAvailable(actualBackground - 1, actualBackground + 1, 1, backgroundXPeek));
		}
	}

	public void MoveRight()
	{
		if (isMoving) return;
		isMoving = true;	
		
		int nextBackground = actualBackground + 1;
		
		if (GetBackground(nextBackground).IsAvailable())
		{
			StartCoroutine(MoveBackgrounds(actualBackground - 1, actualBackground + 2, backgroundX, movingTime, -1));
			actualBackground = nextBackground % backgrounds.Length;
		}
		else
		{
			// StartCoroutine(MoveBackgroundsNotAvailable(actualBackground - 1, actualBackground + 1, -1, backgroundXPeek));
		}
	}
}
