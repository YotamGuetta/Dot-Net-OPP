using System;
using System.Reflection;


namespace GarageLogic
{
    class TestProgram
    {
        enum eNumber
        {
            num,
            m
        }
        
        static void Main() 
        {
            Type objectTypeEnum = typeof(eNumber);
            Type objectType = typeof(eNumber);
            bool isEnum;
            isEnum = objectType.IsEnum;
            if (objectType.Equals(typeof(string)))
            {
                Console.WriteLine("Enter a value to parse: ");
                string inputValue = Console.ReadLine();
                //object enumObject = inputValue;
            }
            if (isEnum) {
                objectType = typeof(int);
            }

            MethodInfo parseMethod = objectType.GetMethod("Parse", new[] { typeof(string) });

            if (parseMethod != null)
            {
                Console.WriteLine("Enter a value to parse: ");
                string inputValue = Console.ReadLine();

                try
                {
                    object parsedValue = parseMethod.Invoke(null, new object[] { inputValue });
                    
                    if (isEnum)
                    {
                        int enumValue = (int)parsedValue;
                        object enumObject = Enum.ToObject(objectTypeEnum, enumValue);
                        eNumber convertedEnum = (eNumber)enumObject;

                        Console.WriteLine("Converted enum value: " + convertedEnum);
                    }
                    else 
                    {
                        Console.WriteLine("Parsed value: " + parsedValue);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            

            // Type type = stuff.GetType();
            //MethodInfo method = type.GetMethod("Parse");
            //method.Invoke()
            //Console.WriteLine(method.Name);
        }
    }
}
