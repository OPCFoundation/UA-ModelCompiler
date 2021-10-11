// ***START***

gint ett_opcua__NAME_ = -1;
void parse_NAME_(proto_tree *tree, tvbuff_t *tvb, gint *pOffset, char *szFieldName)
{
  proto_item *ti = proto_tree_add_text(tree, tvb, 0, -1, "%s : _NAME_", szFieldName);
  proto_tree *subtree = proto_item_add_subtree(ti, ett_opcua__NAME_);
// _BASE_
// _FIELDS_
}

// ***END***
