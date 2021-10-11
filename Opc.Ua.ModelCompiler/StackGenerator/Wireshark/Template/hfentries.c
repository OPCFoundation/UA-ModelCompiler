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
** Description: This file contains protocol field information.
**
** DON'T MODIFY THIS FILE!
**
******************************************************************************/

#ifdef HAVE_CONFIG_H
# include "config.h"
#endif

#include <gmodule.h>
#include <epan/packet.h>

// _INDECES_

/** header field definitions */
static hf_register_info hf[] =
{

// _FIELDS_
};

/** Register field types. */
void registerFieldTypes(int proto)
{
    proto_register_field_array(proto, hf, array_length(hf));
}

// ***END***
