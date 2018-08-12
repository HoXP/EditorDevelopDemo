using UnityEngine;

/// <summary>
/// [RequireComponent]属性应用
/// 当添加该组件时会自动添加RequireComponent所需的组件，且在移除RequireComponent所需组件时会提示先移除当前组件才能移除RequireComponent所需组件
/// </summary>
[RequireComponent(typeof(Rigidbody))]
/// <summary>
/// [AddComponentMenu]属性应用
/// 可将自定义Component添加进主菜单栏的Component菜单和Inspector下GameObject的Add Component按钮菜单中
/// </summary>
[AddComponentMenu("█CustomComponent")]
public class AddComponentDevelop : MonoBehaviour
{
    #region 组件上下文菜单扩展
    /// <summary>
    /// [ContextMenu]属性应用
    ///     string  itemName            菜单路径
    ///     bool    isValidateFunction  是否为验证函数，默认false
    ///     int     priority            优先级，默认1000
    /// -------------------------
    /// 可将该菜单项添加到当前自定义组件的上下文菜单中
    /// </summary>
    [ContextMenu("█ContextMenu")]
    public void ContextMenu()
    {
        Debug.Log("上下文菜单");
    }
    #endregion

    #region 组件中的字段上下文菜单扩展
    /// <summary>
    /// [ContextMenuItem]属性应用
    ///     string name     菜单路径
    ///     string function 菜单项对应的函数名，可以为成员方法
    /// -------------------------
    /// 用于修饰一个序列化字段，当在该序列化字段上右键时，会弹出上下文菜单
    /// </summary>
    [ContextMenuItem("设置默认值[test]", "ContextMenuItem")]
    public string ContextField = string.Empty;
    private void ContextMenuItem()
    {
        ContextField = "test";
    }
    #endregion
}