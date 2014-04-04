﻿using System;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static uint DeserializeToUInt32(string input, Type type)
        {
            uint ui;
            if (uint.TryParse(input, out ui) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return ui;
        }
    }
}
