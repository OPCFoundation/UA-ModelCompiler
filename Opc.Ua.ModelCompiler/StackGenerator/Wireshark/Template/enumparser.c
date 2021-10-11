// ***START***

/** _NAME_ enum table */
static const value_string g__NAME_Table[] = {
// _ENTRY_
  { 0, NULL }
};
static int hf_opcua__NAME_ = -1;

void parse_NAME_(proto_tree *tree, tvbuff_t *tvb, gint *pOffset)
{
    proto_tree_add_item(tree, hf_opcua__NAME_, tvb, *pOffset, 4, TRUE); *pOffset+=4;
}

// ***END***
