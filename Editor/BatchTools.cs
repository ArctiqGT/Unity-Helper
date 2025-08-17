using UnityEngine;
using UnityEditor;

public class BatchTools : EditorWindow
{
    private string renamePrefix = "NewName";
    private Material newMaterial;

    [MenuItem("Arctiq/Batch Tools/Open Batch Tools")]
    private static void OpenWindow()
    {
        GetWindow<BatchTools>("Batch Tools");
    }

    private void OnGUI()
    {
        GUILayout.Label("Batch Rename", EditorStyles.boldLabel);
        renamePrefix = EditorGUILayout.TextField("Prefix", renamePrefix);
        if (GUILayout.Button("Rename Selected Objects"))
        {
            BatchRename();
        }

        GUILayout.Space(10);
        GUILayout.Label("Quick Material Swap", EditorStyles.boldLabel);
        newMaterial = (Material)EditorGUILayout.ObjectField("New Material", newMaterial, typeof(Material), false);
        if (GUILayout.Button("Swap Materials on Selected"))
        {
            QuickMaterialSwap();
        }
    }

    private void BatchRename()
    {
        if (Selection.gameObjects.Length == 0)
        {
            EditorUtility.DisplayDialog("Batch Rename", "No objects selected.", "OK");
            return;
        }

        int counter = 1;
        foreach (GameObject obj in Selection.gameObjects)
        {
            Undo.RecordObject(obj, "Batch Rename");
            obj.name = $"{renamePrefix}_{counter}";
            counter++;
        }

        EditorUtility.DisplayDialog("Batch Rename", "Selected objects renamed successfully.", "OK");
    }

    private void QuickMaterialSwap()
    {
        if (Selection.gameObjects.Length == 0)
        {
            EditorUtility.DisplayDialog("Material Swap", "No objects selected.", "OK");
            return;
        }

        if (newMaterial == null)
        {
            EditorUtility.DisplayDialog("Material Swap", "No material selected.", "OK");
            return;
        }

        int changedCount = 0;
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                Undo.RecordObject(renderer, "Material Swap");
                renderer.sharedMaterial = newMaterial;
                changedCount++;
            }
        }

        EditorUtility.DisplayDialog("Material Swap",
            changedCount > 0 ? $"Materials swapped on {changedCount} objects." : "No renderers found on selected objects.",
            "OK");
    }
}
