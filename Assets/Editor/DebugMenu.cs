using UnityEngine;
using UnityEditor;

public class DebugMenu : EditorWindow
{
	public SubtitleController subtitleControllerObject;
	private SubtitleController subtitleController {
		get {
			if (subtitleControllerObject == null) {
				subtitleControllerObject = FindObjectOfType<SubtitleController>();
			}
			return subtitleControllerObject;
		}
	}
	
	[MenuItem("Tools/Debug Menu")]
	public static void ShowWindow()
	{
		EditorWindow wnd = GetWindow<DebugMenu>();
		wnd.titleContent = new GUIContent("Debug Menu");
	}
	
	private void OnGUI()
	{
		EditorGUILayout.BeginHorizontal();
		if (GUILayout.Button("Debug Dialog", GUILayout.Width(100), GUILayout.Height(35)) && Application.isPlaying)
		{
			DebugDialog();
		}
		if (GUILayout.Button("Starting Dialog", GUILayout.Width(100), GUILayout.Height(35)) && Application.isPlaying)
		{
			StartingDialog();
		}
		if (GUILayout.Button("Break Dialog", GUILayout.Width(100), GUILayout.Height(35)) && Application.isPlaying)
		{
			BreakDialog();
		}
		EditorGUILayout.EndHorizontal();
	}
	
	private void DebugDialog()
	{
		subtitleController.DebugDialog();
	}
	
	private void StartingDialog()
	{
		subtitleController.StartingDialog();
	}
	
	private void BreakDialog()
	{
		subtitleController.BreakDialog();
	}
}
