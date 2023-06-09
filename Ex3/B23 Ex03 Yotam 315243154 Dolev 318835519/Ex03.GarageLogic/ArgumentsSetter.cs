﻿using System;
using System.Collections.Generic;


namespace GarageLogic
{
    class ArgumentsSetter
    {
        public static T GetArgument<T>(Dictionary<string, object> i_ArgumentDictionary, string i_ArgumentName)
        {
            if (i_ArgumentDictionary.ContainsKey(i_ArgumentName))
            {
                object objectValue = i_ArgumentDictionary[i_ArgumentName];

                if (objectValue is T classValue)
                {
                    return classValue;
                }
                else
                {
                    throw new FormatException("Value is not of the expected type.");
                }
            }
            else
            {
                throw new ArgumentException("Specified argument name does not exist.");
            }

        }
    }
}
