using UnityEngine;
using UnityEditor;

public class DebugTools : EditorWindow
{
    [MenuItem("Arctiq/Debug Tools/Open Debug Tools")]
    private static void OpenWindow()
    {
        GetWindow<DebugTools>("Debug Tools");
    }

    private void OnGUI()
    {
        GUILayout.Label("Debug Tools", EditorStyles.boldLabel);

        if (GUILayout.Button("Log Selected Objects"))
        {
            LogSelectedObjects();
        }

        if (GUILayout.Button("Toggle Renderer Components"))
        {
            ToggleRenderers();
        }
    }

    private void LogSelectedObjects()
    {
        if (Selection.gameObjects.Length == 0)
        {
            EditorUtility.DisplayDialog("Log Objects", "No objects selected.", "OK");
            return;
        }

        foreach (GameObject obj in Selection.gameObjects)
        {
            Debug.Log($"Selected Object: {obj.name}, Position: {obj.transform.position}");
        }

        EditorUtility.DisplayDialog("Log Objects", "Selected objects logged to Console.", "OK");
    }

    private void ToggleRenderers()
    {
        if (Selection.gameObjects.Length == 0)
        {
            EditorUtility.DisplayDialog("Toggle Renderers", "No objects selected.", "OK");
            return;
        }

        int toggledCount = 0;
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer rend = obj.GetComponent<Renderer>();
            if (rend != null)
            {
                Undo.RecordObject(rend, "Toggle Renderer");
                rend.enabled = !rend.enabled;
                toggledCount++;
            }
        }

        EditorUtility.DisplayDialog("Toggle Renderers",
            toggledCount > 0 ? $"Toggled {toggledCount} renderer(s)." : "No renderers found on selected objects.",
            "OK");
    }
}
