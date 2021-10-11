// ***START***
#ifndef OPCUA_EXCLUDE__NAME_
/*============================================================================
 * _TYPE__Initialize
 *===========================================================================*/
OpcUa_Void _TYPE__Initialize(_TYPE_* a_pValue)
{
    if (a_pValue != OpcUa_Null)
    {
        // _InitializeList_
    }
}

/*============================================================================
 * _TYPE__Clear
 *===========================================================================*/
OpcUa_Void _TYPE__Clear(_TYPE_* a_pValue)
{
    if (a_pValue != OpcUa_Null)
    {
        // _ClearList_
    }
}

/*============================================================================
 * _TYPE__GetSize
 *===========================================================================*/
OpcUa_StatusCode _TYPE__GetSize(_TYPE_* a_pValue, OpcUa_Encoder* a_pEncoder, OpcUa_Int32* a_pSize)
{
    OpcUa_Int32 iSize = 0;

    OpcUa_InitializeStatus(OpcUa_Module_Serializer, "_NAME__GetSize");

    OpcUa_ReturnErrorIfArgumentNull(a_pValue);
    OpcUa_ReturnErrorIfArgumentNull(a_pEncoder);
    OpcUa_ReturnErrorIfArgumentNull(a_pSize);

    *a_pSize = -1;

    // _GetSizeList_

    *a_pSize = iSize;

    OpcUa_ReturnStatusCode;
    OpcUa_BeginErrorHandling;

    *a_pSize = -1;

    OpcUa_FinishErrorHandling;
}

/*============================================================================
 * _TYPE__Encode
 *===========================================================================*/
OpcUa_StatusCode _TYPE__Encode(_TYPE_* a_pValue, OpcUa_Encoder* a_pEncoder)
{
    OpcUa_InitializeStatus(OpcUa_Module_Serializer, "_NAME__Encode");

    OpcUa_ReturnErrorIfArgumentNull(a_pValue);
    OpcUa_ReturnErrorIfArgumentNull(a_pEncoder);

    // _EncodeList_

    OpcUa_ReturnStatusCode;
    OpcUa_BeginErrorHandling;

    /* nothing to do */

    OpcUa_FinishErrorHandling;
}

/*============================================================================
 * _TYPE__Decode
 *===========================================================================*/
OpcUa_StatusCode _TYPE__Decode(_TYPE_* a_pValue, OpcUa_Decoder* a_pDecoder)
{
    OpcUa_InitializeStatus(OpcUa_Module_Serializer, "_NAME__Decode");

    OpcUa_ReturnErrorIfArgumentNull(a_pValue);
    OpcUa_ReturnErrorIfArgumentNull(a_pDecoder);

    _TYPE__Initialize(a_pValue);

    // _DecodeList_

    OpcUa_ReturnStatusCode;
    OpcUa_BeginErrorHandling;

    _TYPE__Clear(a_pValue);

    OpcUa_FinishErrorHandling;
}

/*============================================================================
 * _TYPE__EncodeableType
 *===========================================================================*/
struct _OpcUa_EncodeableType _TYPE__EncodeableType =
{
    "_NAME_",
    OpcUaId__NAME_,
    OpcUaId__NAME__Encoding_DefaultBinary,
    OpcUaId__NAME__Encoding_DefaultXml,
    OpcUa_Null,
    sizeof(_TYPE_),
    (OpcUa_EncodeableObject_PfnInitialize*)_TYPE__Initialize,
    (OpcUa_EncodeableObject_PfnClear*)_TYPE__Clear,
    (OpcUa_EncodeableObject_PfnGetSize*)_TYPE__GetSize,
    (OpcUa_EncodeableObject_PfnEncode*)_TYPE__Encode,
    (OpcUa_EncodeableObject_PfnDecode*)_TYPE__Decode
};
#endif
// ***END***