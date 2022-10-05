using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
	public float backgroundX;
	public Background[] backgrounds;

	private int actualBackground; 
	private bool isMoving;

	private void Start()
	{
		actualBackground = 0;
		isMoving = false;
	}
	
	// Access element in array as a circular list
	private Transform GetBackground(int index)
	{
		return backgrounds[(index + backgrounds.Length) % backgrounds.Length].background.transform;
	}
	
	// Set background in edge position and return original position
	private Vector3 SetBackgroundEdge(int index, int offset, float x)
	{
		Transform background = GetBackground(index + offset);
		Vector3 position = background.position;
		background.position = new Vector3(x * offset, 0, 0);
		return position;
	}
	
	// Set background in new position
	private void SetBackgroundPosition(int index, Vector3 position)
	{
		Transform background = GetBackground(index);
		background.position = position;
	}
	
	// Coroutine to move background in a direction
	private IEnumerator MoveBackground(int index, int direction, float x)
	{
		Transform background = GetBackground(index);
		float targetX = background.position.x + x * direction;
		while (background.position.x != targetX)
		{
			background.position = Vector3.MoveTowards(background.position, new Vector3(targetX, 0, 0), 0.1f);
			yield return null;
		}
	}
	
	// Coroutine to move range of backgrounds in a direction and reset end location
	private IEnumerator MoveBackgrounds(int start, int end, int direction, float x, Vector3 returnPosition)
	{
		for (int i = start; i != end; i += direction)
		{
			StartCoroutine(MoveBackground(i, direction, x));
		}
		yield return StartCoroutine(MoveBackground(end, direction, x));
		SetBackgroundPosition(end, returnPosition);
		isMoving = false;
	}
	
 
	public void MoveLeft()
	{
		if (isMoving) return;
		isMoving = true;
		
		Vector3 oldPosition = SetBackgroundEdge(actualBackground, -2, backgroundX);
		
		StartCoroutine(MoveBackgrounds(actualBackground - 2, actualBackground + 1, 1, backgroundX, oldPosition));
		
		actualBackground = (actualBackground - 1 + backgrounds.Length) % backgrounds.Length;
	}

	public void MoveRight()
	{
		if (isMoving) return;
		isMoving = true;
		
		Vector3 oldPosition = SetBackgroundEdge(actualBackground, 2, backgroundX);
		
		StartCoroutine(MoveBackgrounds(actualBackground + 2, actualBackground - 1, -1, backgroundX, oldPosition));
		
		actualBackground = (actualBackground + 1) % backgrounds.Length;
	}
}
