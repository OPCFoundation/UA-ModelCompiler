// ***START***
#region _ClassName_Value Class
/// <summary>
/// A typed version of the _BrowseName_ variable.
/// </summary>
/// <exclude />
[System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
public class _ClassName_Value : BaseVariableValue
{
    #region Constructors
    /// <summary>
    /// Initializes the instance with its defalt attribute values.
    /// </summary>
    public _ClassName_Value(_ClassName_State variable, _DataType_ value, object dataLock) : base(dataLock)
    {
        m_value = value;

        if (m_value == null)
        {
            m_value = new _DataType_();
        }

        Initialize(variable);
    }
    #endregion

    #region Public Members
    /// <summary>
    /// The variable that the value belongs to.
    /// </summary>
    public _ClassName_State Variable
    {
        get { return m_variable; }
    }

    /// <summary>
    /// The value of the variable.
    /// </summary>
    public _DataType_ Value
    {
        get { return m_value;  }
        set { m_value = value; }
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Initializes the object.
    /// </summary>
    private void Initialize(_ClassName_State variable)
    {
        lock (Lock)
        {
            m_variable = variable;

            variable.Value = m_value;

            variable.OnReadValue = OnReadValue;
            variable.OnSimpleWriteValue = OnWriteValue;

            BaseVariableState instance = null;
            List<BaseInstanceState> updateList = new List<BaseInstanceState>();
            updateList.Add(variable);

            // ListOfChildInitializers

            SetUpdateList(updateList);
        }
    }

    /// <summary>
    /// Reads the value of the variable.
    /// </summary>
    protected ServiceResult OnReadValue(
        ISystemContext context,
        NodeState node,
        NumericRange indexRange,
        QualifiedName dataEncoding,
        ref object value,
        ref StatusCode statusCode,
        ref DateTime timestamp)
    {
        lock (Lock)
        {
            DoBeforeReadProcessing(context, node);

            if (m_value != null)
            {
                value = m_value;
            }

            return Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
        }
    }

    /// <summary>
    /// Writes the value of the variable.
    /// </summary>
    private ServiceResult OnWriteValue(ISystemContext context, NodeState node, ref object value)
    {
        lock (Lock)
        {
            m_value = (_DataType_)Write(value);
        }

        return ServiceResult.Good;
    }

    // ListOfChildMethods
    #endregion

    #region Private Fields
    private _DataType_ m_value;
    private _ClassName_State m_variable;
    #endregion
}
#endregion
// ***END***
