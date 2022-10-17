using System.Collections;
using UnityEngine;
using TMPro;

public class SubtitleController : MonoBehaviour
{
	[SerializeField] private GameObject dialogBox;
	//[SerializeField] private BoxCollider2D dialogCollider;
	[SerializeField] private TextMeshProUGUI textMesh;
	
	public Dialog[] testDialogs;

	private IEnumerator CO_SetTextForSeconds(Dialog dialog)
	{
		textMesh.enabled = true;
		string text = "";
		foreach (char c in dialog.text)
		{
			text += c;
			textMesh.text = text;
			yield return new WaitForSeconds(dialog.timeBetweenLetters);
		}
		yield return new WaitForSeconds(0.5f);
		textMesh.enabled = false;
	}
	
	private IEnumerator CO_PlayDialogs(Dialog[] dialogs)
	{
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
	
	public void OnMouseDown()
	{
		Debug.Log("Bloqueia Diálogo");
	}
}
