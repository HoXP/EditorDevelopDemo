using UnityEditor;
using UnityEngine;

public class CustomWindow : EditorWindow
{
    [MenuItem("█自定义窗口/Show")]
    public static void CustomWindowShow()
    {
        GetWindow<CustomWindow>().Show();       //无论执行打多少次显示窗口命令，只有一个窗口打开
        //CreateInstance<CustomWindow>().Show();  //执行一次显示窗口命令就打开一个新的窗口
    }

    [MenuItem("█自定义窗口/ShowAsDropDown")]
    public static void CustomWindowShowAsDropDown()
    {
        GetWindow<CustomWindow>().ShowAsDropDown(new Rect(10, 10, 600, 400), new Vector2(800, 600));
    }

    [MenuItem("█自定义窗口/ShowAuxWindow")]
    public static void CustomWindowShowAuxWindow()
    {
        GetWindow<CustomWindow>().ShowAuxWindow();
    }

    [MenuItem("█自定义窗口/ShowPopup")]
    public static void CustomWindowShowPopup()
    {
        GetWindow<CustomWindow>().ShowPopup();
    }

    [MenuItem("█自定义窗口/ShowUtility")]
    public static void CustomWindowShowUtility()
    {
        GetWindow<CustomWindow>().ShowUtility();
    }

    //-------------------------------------------------------------------
    //EditorWindow内置事件

    private Vector2 scrollViewPos;
    private int intField;
    private float floatField;
    private string textField;
    private string textArea = "ds";
    private string passwordField;
    private Color colorField;
    private float sliderVal;
    private int intSlider;
    private Vector2 v2MinMax = new Vector2(0.3f, 0.7f);
    private Vector2 vector2Field;
    private Vector3 vector3Field;
    private Vector4 vector4Field;
    private Rect rectField;
    private Bounds boundsField;
    private int popupVal;
    private int intPopupVal;
    private Condition enumPopupVal;
    private string tagField;
    private int layerField;
    private bool foldout;
    private bool toggle;
    private bool toggleGroup;
    private AnimationCurve curveField = new AnimationCurve();
    private bool inspectorTitlebar;
    private Object objectField;

    /// <summary>
    /// 绘制窗口
    /// </summary>
    public void OnGUI()
    {
        if (GUILayout.Button("关闭"))
        {//关闭按钮
            Close();
        }
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("显示通知"))
        {
            GUIContent content = new GUIContent();
            content.text = "通知";
            content.tooltip = "ShowNotification";
            ShowNotification(new GUIContent(content));
        }
        if (GUILayout.Button("关闭通知"))
        {
            RemoveNotification();
        }
        EditorGUILayout.EndHorizontal();

        //滚动视图分组↓
        scrollViewPos = EditorGUILayout.BeginScrollView(scrollViewPos);

        //Label
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("文本");
        EditorGUILayout.SelectableLabel("可选文本");
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        //水平分组↓
        EditorGUILayout.BeginHorizontal();
        //数值输入
        intField = EditorGUILayout.IntField("整数", intField);
        floatField = EditorGUILayout.FloatField("浮点数", floatField);
        EditorGUILayout.EndHorizontal();
        //水平分组↑

        EditorGUILayout.Space();

        //文本输入
        EditorGUILayout.BeginHorizontal();
        textField = EditorGUILayout.TextField("文本输入框", textField);
        passwordField = EditorGUILayout.PasswordField("密码输入框", passwordField);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("可换行的文本输入框");
        textArea = EditorGUILayout.TextArea(textArea);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        //颜色
        colorField = EditorGUILayout.ColorField("取色器", colorField);

        EditorGUILayout.Space();

        //垂直分组
        EditorGUILayout.BeginVertical();
        //滑动条
        sliderVal = EditorGUILayout.Slider("浮点数滚动条", sliderVal, 0, 1);
        intSlider = EditorGUILayout.IntSlider("整数滚动条", intSlider, 0, 10);
        EditorGUILayout.MinMaxSlider("区间滚动条", ref v2MinMax.x, ref v2MinMax.y, 0, 1);
        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();

        //多元数
        vector2Field = EditorGUILayout.Vector2Field("二维向量", vector2Field);
        vector3Field = EditorGUILayout.Vector3Field("三维向量", vector3Field);
        vector4Field = EditorGUILayout.Vector4Field("四维向量", vector4Field);
        rectField = EditorGUILayout.RectField("矩形", rectField);
        boundsField = EditorGUILayout.BoundsField("边界", boundsField);

        EditorGUILayout.Space();

        //下拉列表
        popupVal = EditorGUILayout.Popup("返回选项数组下标", popupVal, new string[] { "A", "B" });
        intPopupVal = EditorGUILayout.IntPopup("返回选项数组下标对应的整数数组值", intPopupVal, new string[] { "A", "B" }, new int[] { 1, 2 });
        enumPopupVal = (Condition)EditorGUILayout.EnumPopup("返回枚举", enumPopupVal);

        EditorGUILayout.Space();

        //
        tagField = EditorGUILayout.TagField("TagField", tagField);
        layerField = EditorGUILayout.LayerField("LayerField", layerField);

        EditorGUILayout.Space();

        foldout = EditorGUILayout.Foldout(foldout, "折叠");
        if (foldout)
        {
            EditorGUILayout.LabelField("折叠内容1");
            EditorGUILayout.LabelField("折叠内容2");
        }

        EditorGUILayout.Space();

        toggle = EditorGUILayout.Toggle("复选框", toggle);

        EditorGUILayout.Space();

        //启用/禁用分组中的内容
        toggleGroup = EditorGUILayout.BeginToggleGroup("启用/禁用分组中的内容", toggleGroup);
        EditorGUILayout.TextField("sdk");
        EditorGUILayout.EndToggleGroup();

        EditorGUILayout.Space();

        curveField = EditorGUILayout.CurveField("动画片段", curveField);
        inspectorTitlebar = EditorGUILayout.InspectorTitlebar(inspectorTitlebar, objectField);    //将选择的物体放在面板上
        objectField = EditorGUILayout.ObjectField("ObjectField", objectField, typeof(RectTransform), true);

        EditorGUILayout.EndScrollView();
        //滚动视图分组↑
    }

    /// <summary>
    /// 刷新方法，100次/秒
    /// </summary>
    public void Update() { }
    /// <summary>
    /// 刷新方法，比Update()少
    /// </summary>
    public void OnInspectorUpdate() { }

    /// <summary>
    /// 选择对象
    /// </summary>
    public void OnSelectionChange()
    {
        UnityEngine.Object obj = Selection.activeObject;
        Debug.Log(string.Format("OnSelectionChange 选择对象：{0}", obj == null ? "未选择" : obj.name));
    }

    /// <summary>
    /// 获得焦点
    /// </summary>
    public void OnFocus()
    {
        Debug.Log("OnFocus 获得焦点");
    }
    /// <summary>
    /// 失去焦点
    /// </summary>
    public void OnLostFocus()
    {
        Debug.Log("OnLostFocus 失去焦点");
    }

    /// <summary>
    /// Hierarchay视图GameObject发生改变
    /// </summary>
    public void OnHierarchyChange()
    {
        Debug.Log("OnHierarchayChange Hierarchay视图GameObject发生改变");
    }
    /// <summary>
    /// Project视图文件发生改变
    /// </summary>
    public void OnProjectChange()
    {
        Debug.Log("OnProjectChange Project视图文件发生改变");
    }

    /// <summary>
    /// 销毁窗口
    /// </summary>
    public void OnDestroy()
    {
        Debug.Log("OnDestroy 关闭窗口");
    }
}