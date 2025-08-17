using UnityEngine;
using UnityEditor;

public static class ObjectUtilities
{
    [MenuItem("Arctiq/Object Utilities/Reset Transforms")]
    private static void ResetTransforms()
    {
        if (Selection.gameObjects.Length == 0)
        {
            EditorUtility.DisplayDialog("Reset Transforms", "No objects selected.", "OK");
            return;
        }

        foreach (GameObject obj in Selection.gameObjects)
        {
            Undo.RecordObject(obj.transform, "Reset Transforms");
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            obj.transform.localScale = Vector3.one;
        }

        EditorUtility.DisplayDialog("Reset Transforms", "Selected objects' transforms reset.", "OK");
    }

    [MenuItem("Arctiq/Object Utilities/Remove Missing Scripts")]
    private static void RemoveMissingScripts()
    {
        if (Selection.gameObjects.Length == 0)
        {
            EditorUtility.DisplayDialog("Remove Missing Scripts", "No objects selected.", "OK");
            return;
        }

        int totalRemoved = 0;
        foreach (GameObject obj in Selection.gameObjects)
        {
            Undo.RegisterFullObjectHierarchyUndo(obj, "Remove Missing Scripts");
            totalRemoved += GameObjectUtility.RemoveMonoBehavioursWithMissingScript(obj);
        }

        EditorUtility.DisplayDialog("Remove Missing Scripts",
            totalRemoved > 0 ? $"Removed {totalRemoved} missing scripts successfully." : "No missing scripts found.",
            "OK");
    }
}
