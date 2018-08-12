using UnityEditor;
using UnityEngine;

/// <summary>
/// [MenuItem]属性应用
/// --------------------------------------
/// MenuItem()构造方法参数：
///     string  itemName            菜单路径
///     bool    isValidateFunction  默认false，是否为验证函数，当两个方法itemName一样时，其中一个该参数为true的函数称作验证函数，其返回值需为bool类型，验证不通过时该菜单项会置灰，验证通过后才解除置灰
///     int     priority            优先级，默认1000，同一优先级的为成一组，在菜单里的表现就是不同组之间有分割线
/// --------------------------------------
/// 可扩展Unity编辑器的主菜单、Inspector面板菜单、Hierarchy视图菜单、Project视图菜单
/// </summary>
public class MenuItemDevelop : MonoBehaviour    //有[MenuItem]属性的脚本不必继承Editor类，也不是必须放在Editor文件夹下才会响应
{
    #region _
    [MenuItem("█MenuItem/直接快捷键 _y", false, 1)]    //[菜单项路径 _按键]下划线后跟小写字母，表示该命令用该字母快捷键可触发
    private static void _() //[MenuItem]属性只能描述静态方法，否则该菜单项不会显示，该方法不会响应，且会提示Warning[Method MenuItemDevelop.Test1 is not static and cannot be used for menu commands.]
    {
        Debug.Log("快捷键Y[_]");
    }
    #endregion

    #region 组合快捷键
    [MenuItem("█MenuItem/组合快捷键 %y", false, 1)]    //Ctrl
    private static void Ctrl()
    {
        Debug.Log("快捷键Ctrl+Y[%]");
    }
    [MenuItem("█MenuItem/组合快捷键 #y", false, 1)]    //Shift
    private static void Shift()
    {
        Debug.Log("快捷键Shift+Y[#]");
    }
    [MenuItem("█MenuItem/组合快捷键 &y", false, 1)]    //Alt
    private static void Alt()
    {
        Debug.Log("快捷键Alt+Y[&]");
    }
    [MenuItem("█MenuItem/组合快捷键 %#&y", false, 1)]    //Ctrl+Shift+Alt
    private static void CtrlShiftAlt()
    {
        Debug.Log("快捷键Ctrl+Shift+Alt+Y[%#&]");
    }
    #endregion

    #region Fn
    //[MenuItem("█MenuItem/Fn _F1-F12")]
    //[MenuItem("█MenuItem/特殊快捷键", false, 2)]
    [MenuItem("█MenuItem/特殊快捷键/F1 _F1")]
    private static void Fn()
    {
        Debug.Log("快捷键 Fn");
    }
    #endregion

    #region Arrow
    [MenuItem("█MenuItem/特殊快捷键/← _LEFT")]
    [MenuItem("█MenuItem/特殊快捷键/→ _RIGHT")]
    [MenuItem("█MenuItem/特殊快捷键/↑ _UP")]
    [MenuItem("█MenuItem/特殊快捷键/↓ _DOWN")]
    private static void Arrow()
    {
        Debug.Log("快捷键 箭头");
    }
    #endregion

    #region HOME END PGUP PGDN
    [MenuItem("█MenuItem/特殊快捷键/HOME _HOME")]
    [MenuItem("█MenuItem/特殊快捷键/END _END")]
    [MenuItem("█MenuItem/特殊快捷键/PGUP _PGUP")]
    [MenuItem("█MenuItem/特殊快捷键/PGDN _PGDN")]
    private static void HomeEndPgUpDown()
    {
        Debug.Log("快捷键 HOME END PGUP PGDN");
    }
    #endregion

    #region Project视图菜单扩展
    [MenuItem("Assets/█在Project视图里右键")]    //以Assets开头，则菜单项被添加进Assets菜单和Project视图的上下文菜单中
    private static void AssetsTest()
    {
        Debug.Log("在Project视图里右键");
    }
    [MenuItem("Assets/Create/█创建自定义资源")]    //以Assets/Create开头，则菜单项被添加进Assets菜单和Project视图的上下文菜单的Create菜单项中
    private static void CreateSth()
    {
        Debug.Log("创建自定义资源");
    }
    #endregion

    #region Hierarchy视图菜单扩展
    [MenuItem("GameObject/█Hierarchy视图菜单扩展/█CustomGameObject", false, 10)]
    private static void CreateCustomGameObject()
    {

    }
    //private static void CreateCustomGameObject(MenuCommand menuCommand)
    //{
    //    Debug.Log("Hierarchy视图菜单扩展");
    //    GameObject go = new GameObject("Custom Game Object");
    //    GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
    //    Undo.RegisterCreatedObjectUndo(go, string.Format("Create ", go.name));  //将创建操作注册到Undo系统
    //    Selection.activeObject = go;
    //}
    #endregion

    #region 某组件菜单扩展
    [MenuItem("CONTEXT/Transform/█DoSth")]    //以CONTEXT/[组件名]开头，则菜单项被添加进组件上下文菜单中
    private static void TransformDoSth()
    {
        Debug.Log("TransformDoSth");
    }
    #endregion

    #region 置灰
    [MenuItem("█MenuItem/不选中GameObject就会置灰", false, 3)]
    private static void SelectedGameObject()
    {
        Debug.Log("SelectedGameObject");
    }
    [MenuItem("█MenuItem/不选中GameObject就会置灰", true, 3)]  //第二个参数true表示该属性所描述的方法是验证方法，验证方法返回false，则该菜单项就置灰，否则不置灰
    private static bool SelectedGameObjectBool()
    {
        Object selectedObject = Selection.activeObject;
        if (selectedObject != null && selectedObject.GetType() == typeof(GameObject))
        {
            return true;
        }
        return false;
    }
    #endregion
}