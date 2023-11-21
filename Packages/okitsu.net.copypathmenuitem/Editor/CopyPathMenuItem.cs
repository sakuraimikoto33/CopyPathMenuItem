using UnityEditor;
 
public static class CopyPathMenuItem
{
    [MenuItem("GameObject/Copy Path %#c", false, -753)]
    private static void CopyPath()
    {
        var go = Selection.activeGameObject;
 
        if (go == null)
        {
            return;
        }
 
        var path = go.name;
 
        while (go.transform.parent != null)
        {
            go = go.transform.parent.gameObject;
            path = string.Format("{0}/{1}", go.name, path);
        }
 
        EditorGUIUtility.systemCopyBuffer = path;
    }

    [MenuItem("GameObject/Copy Path %#c", true)]
    private static bool CopyPathValidation()
    {
        // We can only copy the path in case 1 object is selected
        return Selection.gameObjects.Length == 1;
    }

    [MenuItem("GameObject/Copy Path Excluding Root %#c", false, -753)]
    private static void CopyPathExcludingRoot()
    {
        var go = Selection.activeGameObject;

        if (go == null)
        {
            return;
        }

        var path = go.name;

        while (go.transform.parent != null)
        {
            go = go.transform.parent.gameObject;
            if (go.transform.parent != null) // Check if this is not the root
            {
                path = string.Format("{0}/{1}", go.name, path);
            }
        }

        EditorGUIUtility.systemCopyBuffer = path;
    }

    [MenuItem("GameObject/Copy Path Excluding Root %#c", true)]
    private static bool CopyPathExcludingRootValidation()
    {
        // We can only copy the path in case 1 object is selected
        return Selection.gameObjects.Length == 1;
    }
}