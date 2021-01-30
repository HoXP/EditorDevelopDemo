using System;
using UnityEngine;

public class BeautifyInspector : MonoBehaviour
{
    //☆首先要知道，被序列化的字段会在Inspector显示，无论访问修饰符是啥，相反，被指定不序列化的字段不会在Inspector显示
    /// <summary>
    /// public修饰的字段会被序列化
    /// </summary>
    public int intVal1 = 3;
    /// <summary>
    /// [HideInInspector]属性应用
    /// 该字段由于public修饰会被序列化，但是[HideInInspector]属性会隐藏该字段
    /// </summary>
    [HideInInspector]
    public int intVal2 = 3;
    /// <summary>
    /// [NonSerialized]属性应用
    /// 指定所修饰的字段不被序列化，即使其为public的，因此依然不会显示在Inspector
    /// </summary>
    [NonSerialized]
    public int intVal3 = 3;
    /// <summary>
    /// [SerializeField]属性应用
    /// 强制序列化该字段，因此，即使其为private的，依然会显示在Inspector
    /// </summary>
    [SerializeField]
    private int intVal4 = 5;

    ///--------------------------------------------------------------------------

    [HideInInspector]
    public Condition enmCondition;
    [HideInInspector]
    public int intVal;
    [HideInInspector]
    public float floatVal;
    [HideInInspector]
    public string stringVal;
    [HideInInspector]
    public Color colorVal;
    /// <summary>
    /// 该类被[Serializable]修饰，因此会被序列化，显示在Inspector
    /// </summary>
    public SerializableClass customClassVal = new SerializableClass();
}

/// <summary>
/// [Serializable]属性应用
/// 可使所修饰的自定义类的对象及其public字段被序列化
/// </summary>
[Serializable]
public class SerializableClass
{
    public int intVal;
    public float floatVal;
    public Color colorVal;
}

public enum Condition
{
    None = 0,
    Int,
    Float,
    Str,
    Color,
    CustomClass
}