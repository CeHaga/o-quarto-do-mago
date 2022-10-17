using UnityEngine;
using UnityEditor;

public class DebugMenu : EditorWindow
{
	private SubtitleController subtitleController;
	
	[MenuItem("Tools/Debug Menu")]
	public static void ShowWindow()
	{
		EditorWindow wnd = GetWindow<DebugMenu>();
		wnd.titleContent = new GUIContent("Debug Menu");
	}
	
	private void OnGUI()
	{
		if (GUILayout.Button("Debug Dialog", GUILayout.Width(100), GUILayout.Height(35)) && Application.isPlaying)
		{
			DebugDialog();
		}
	}
	
	private void DebugDialog()
	{
		if(subtitleController == null)
		{
			subtitleController = FindObjectOfType<SubtitleController>();
			if(subtitleController == null)
			{
				Debug.LogError("SubtitleController not found");
				return;
			}
		}
		subtitleController.DebugDialog();
	}
}
