// ***START***
/******************************************************************************
** $Id$
**
** Copyright (C) 2006-2008 ascolab GmbH. All Rights Reserved.
** Web: http://www.ascolab.com
**
** This program is free software; you can redistribute it and/or
** modify it under the terms of the GNU General Public License
** as published by the Free Software Foundation; either version 2
** of the License, or (at your option) any later version.
**
** This file is provided AS IS with NO WARRANTY OF ANY KIND, INCLUDING THE
** WARRANTY OF DESIGN, MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.
**
** Project: OpcUa Wireshark Plugin
**
** Description: Service table and service dispatcher.
**
** DON'T MODIFY THIS FILE!
**
******************************************************************************/

#ifdef HAVE_CONFIG_H
# include "config.h"
#endif

#include <gmodule.h>
#include <epan/packet.h>
#include "opcua_identifiers.h"
#include "opcua_serviceparser.h"

ParserEntry g_arParserTable[] = {

// _PARSER_ENTRY_
};
const int g_NumServices = sizeof(g_arParserTable) / sizeof(ParserEntry);

/** Service type table */
const value_string g_requesttypes[] = {
// _REQUEST_ENTRY_
  { 0, NULL }
};

/** Dispatch all services to a special parser function. */
void dispatchService(proto_tree *tree, tvbuff_t *tvb, gint *pOffset, int ServiceId)
{
    int index = 0;

    while (index < g_NumServices)
    {
        if (g_arParserTable[index].iRequestId == ServiceId)
        {
            (*g_arParserTable[index].pParser)(tree, tvb, pOffset);
            break;
        }
        index++;
    }
}

// ***END***