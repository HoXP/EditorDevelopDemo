using UnityEditor;

/// <summary>
/// [CustomEditor]属性应用
///     Type inspectedType          该Editor脚本所关联的Component类型，一般用typeof()获取
///     bool editorForChildClasses  Inspector面板中是否显示inspectedType子类的字段，默认false
/// --------------------------------
/// </summary>
[CustomEditor(typeof(BeautifyInspector))]
public class BeautifyInspectorEditor : Editor
{
    public SerializedObject so;
    public SerializedProperty spCondition;
    public SerializedProperty spInt;
    public SerializedProperty spFloat;
    public SerializedProperty spStr;
    public SerializedProperty spColor;
    public SerializedProperty spCustomClass;

    public void OnEnable()
    {
        so = new SerializedObject(target);
        spCondition = so.FindProperty("enmCondition");
        spInt = so.FindProperty("intVal");
        spFloat = so.FindProperty("floatVal");
        spStr = so.FindProperty("stringVal");
        spColor = so.FindProperty("colorVal");
        spCustomClass = so.FindProperty("customClassVal");
    }

    /// <summary>
    /// 重写该方法以自定义Inspector
    /// </summary>
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Space();

        //实现根据不同选项显隐不同内容
        so.Update();
        EditorGUILayout.PropertyField(spCondition);
        switch (spCondition.enumValueIndex)
        {
            case 0:
                break;
            case 1:
                EditorGUILayout.PropertyField(spInt);
                break;
            case 2:
                EditorGUILayout.PropertyField(spFloat);
                break;
            case 3:
                EditorGUILayout.PropertyField(spStr);
                break;
            case 4:
                EditorGUILayout.PropertyField(spColor);
                break;
            case 5:
                EditorGUILayout.PropertyField(spCustomClass, true);
                break;
        }
        so.ApplyModifiedProperties();
    }
}