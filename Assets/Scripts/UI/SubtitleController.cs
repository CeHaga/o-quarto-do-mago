using System.Collections;
using UnityEngine;
using TMPro;

public class SubtitleController : MonoBehaviour
{
	[SerializeField] private GameObject dialogBox;
	//[SerializeField] private BoxCollider2D dialogCollider;
	[SerializeField] private TextMeshProUGUI dialogTextMesh;
	[SerializeField] private TextMeshProUGUI nameTextMesh;
	
	public Dialog[] testDialogs;
	
	public Dialog[] startingDialogs;

	private IEnumerator CO_SetTextForSeconds(Dialog dialog)
	{
		string text = "";
		nameTextMesh.text = dialog.character.name;
		foreach (char c in dialog.text)
		{
			text += c;
			dialogTextMesh.text = text;
			yield return new WaitForSeconds(dialog.timeBetweenLetters);
		}
		yield return new WaitForSeconds(0.5f);
	}
	
	private IEnumerator CO_PlayDialogs(Dialog[] dialogs)
	{
		dialogTextMesh.text = "";
		nameTextMesh.text = "";
		dialogBox.SetActive(true);
		//dialogCollider.enabled = true;
		foreach (var dialog in dialogs)
		{
			yield return StartCoroutine(CO_SetTextForSeconds(dialog));
		}
		dialogBox.SetActive(false);
		//dialogCollider.enabled = false;
	}
	
	public void StartText(Dialog[] dialogs)
	{
		StartCoroutine(CO_PlayDialogs(dialogs));
	}
	
	public void DebugDialog()
	{
		Debug.Log("DebugDialog");
		StartCoroutine(CO_PlayDialogs(testDialogs));
	}
	
	public void StartingDialog()
	{
		StartCoroutine(CO_PlayDialogs(startingDialogs));
	}
	
	public void OnMouseDown()
	{
		Debug.Log("Bloqueia Diálogo");
	}
}
