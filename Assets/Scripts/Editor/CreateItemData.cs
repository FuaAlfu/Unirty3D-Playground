using System.IO;
using UnityEditor;
using UnityEngine;

public class CreateItemData
{
    [MenuItem("Assets/Create/Item Data")]
    public static void MakeItemData()
    {
        string name = "ItemData";
        ItemData asset = ScriptableObject.CreateInstance<ItemData>();
        AssetDatabase.CreateAsset(asset, string.Format("Assets/ScriptableObjects/{0}.asset", name));
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }

}
