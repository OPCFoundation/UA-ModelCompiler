// ***START***
#ifndef OPCUA_EXCLUDE__NAME_
/*============================================================================
 * The _NAME_ structure.
 *===========================================================================*/
typedef struct __TYPE_
{
    // _FieldList_
}
_TYPE_;

OPCUA_EXPORT OpcUa_Void _TYPE__Initialize(_TYPE_* pValue);

OPCUA_EXPORT OpcUa_Void _TYPE__Clear(_TYPE_* pValue);

OPCUA_EXPORT OpcUa_StatusCode _TYPE__GetSize(_TYPE_* pValue, struct _OpcUa_Encoder* pEncoder, OpcUa_Int32* pSize);

OPCUA_EXPORT OpcUa_StatusCode _TYPE__Encode(_TYPE_* pValue, struct _OpcUa_Encoder* pEncoder);

OPCUA_EXPORT OpcUa_StatusCode _TYPE__Decode(_TYPE_* pValue, struct _OpcUa_Decoder* pDecoder);

OPCUA_IMEXPORT extern struct _OpcUa_EncodeableType _TYPE__EncodeableType;
#endif
// ***END***