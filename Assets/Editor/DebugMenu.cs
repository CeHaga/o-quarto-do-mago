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
		if (GUILayout.Button("Debug dialog", GUILayout.Width(80), GUILayout.Height(35)))
		{
			DebugDialog();
		}
	}
	
	private void DebugDialog()
	{
		if(subtitleController == null)
		{
			subtitleController = FindObjectOfType<SubtitleController>();
		}
		subtitleController.DebugDialog();
	}
}
