using UnityEngine;
using UnityEditor;

/// <summary>
/// Unity内置的GUIStyle示例
/// </summary>
public class EditorStyleExample : EditorWindow
{
    private bool toggles = false;

    [MenuItem("█自定义窗口/内置GUIStyle/示例", false, 1)]
    static void Init()
    {
        EditorWindow.GetWindow(typeof(EditorStyleExample));
    }

    void OnGUI()
    {
        GUILayout.Label("  Options", "LargeLabel");

        GUILayout.BeginVertical("HelpBox");
        GUILayout.BeginHorizontal();

        EditorGUILayout.TextField("Search", "", "ToolbarSeachTextField");
        GUILayout.Button("Close", "ToolbarSeachCancelButton");

        GUILayout.Space(20);

        GUILayout.Button("minibuttonleft", "minibuttonleft");
        GUILayout.Button("minibuttonright", "minibuttonright");

        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        if (GUILayout.Button("Advanced", "MiniToolbarButton"))
        {
            toggles = !toggles;
        }
        if (toggles)
        {
            GUILayout.BeginVertical("ProgressBarBack");
            GUILayout.BeginHorizontal();

            GUILayout.BeginVertical();
            GUILayout.Label("WhiteMiniLabel", "WhiteMiniLabel");
            GUILayout.Label("ErrorLabel", "ErrorLabel");
            GUILayout.EndVertical();

            GUILayout.BeginVertical("GroupBox");

            GUILayout.BeginHorizontal();
            GUILayout.Button("OL Plus", "OL Plus");
            GUILayout.Button("OL Minus", "OL Minus");
            GUILayout.EndHorizontal();
            GUILayout.Space(10);

            GUILayout.Button("OL Title", "OL Title");
            GUILayout.Space(10);
            GUILayout.BeginHorizontal();
            GUILayout.Button("OL Titleleft", "OL Titleleft");
            GUILayout.Button("OL Titlemid", "OL Titlemid");
            GUILayout.Button("OL Titleright", "OL Titleright");
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();

            GUILayout.EndHorizontal();
            GUILayout.Space(20);
            GUILayout.EndVertical();

            GUILayout.BeginHorizontal("GroupBox");
            GUILayout.Label("CN EntryInfo", "CN EntryInfo");
            GUILayout.Label("CN EntryWarn", "CN EntryWarn");
            GUILayout.Label("CN EntryError", "CN EntryError");
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();
    }
}