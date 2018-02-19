using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms
{
    public static class BubbleSortAlgorithms
    {
        
        public static ICollection<T> BubbleSort<T>(this ICollection<T> collection, bool isKeyValuePairDataStructure, SortingOrder orderby, KeyValuePairSortingOn keyValuePairSortingOn, string propertyName = Constant.EmptyString)
        {
            
            switch (orderby)
            {
                case SortingOrder.Ascending:
                    break;

                case SortingOrder.Descending:
                    break;

            }
            if (!isKeyValuePairDataStructure)
            {
                T[] Arrays=new T[collection.Count];
                for (int i = 0; i < collection.Count; i++)
                {
                    Arrays[i] = collection.ElementAt(i);
                }
                Type genricArguments =collection.GetType().GetGenericArguments()[0];
                if (genricArguments.IsValueType)
                {
                    for (int i = 0; i < Arrays.Length; i++)
                    {
                        for (int j = 0; j < Arrays.Length - i; j++)
                        {
                            dynamic value1 = Arrays[j];
                            dynamic value2 = Arrays[j+1];
                            if (value1 > value2)
                            {
                                var temp = Arrays[j];
                                Arrays[j] = Arrays[j + 1];
                                Arrays[j + 1] = temp;
                                
                            }
                        }
                    }
                }
                else
                { 
                    if (string.IsNullOrEmpty(propertyName))
                    {
                        throw new PropertyNameException(Constant.PropertyErrorMsg);
                    }
                    else
                    {
                        var member = genricArguments.FindMembers(System.Reflection.MemberTypes.Property | System.Reflection.MemberTypes.Field, System.Reflection.BindingFlags.Default, null, null);
                        string type = string.Empty; 
                        if (member.Count() == 1 && member.GetType().IsValueType)
                        {
                            Type typeofMember = member.GetType();
                            if (typeofMember == typeof(System.Int16) || typeofMember == typeof(System.Int32) || typeofMember == typeof(System.Int64) || typeofMember == typeof(System.Double) || typeofMember == typeof(float) || typeofMember == typeof(System.Decimal))
                            {
                                type = "Numeric";
                            }
                            else if (typeofMember == typeof(System.String))
                            {
                                type = "String";
                            }
                            else if (typeofMember == typeof(System.DateTime))
                            {
                                type = "DateTime";
                            }
                            for (int i = 0; i < Arrays.Length; i++)
                            {
                                for (int j = 0; j < Arrays.Length - i; j++)
                                {
                                    var property1 = Arrays[j].GetType().GetField(propertyName, System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.GetField);
                                    var property2 = Arrays[j + 1].GetType().GetField(propertyName, System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.GetField);
                                    dynamic valueOfProp1=string.Empty;
                                    dynamic valueOfProp2= string.Empty;
                                    switch (type)
                                    {
                                        case "Numeric":
                                            valueOfProp1 = Convert.ToDouble(property1.GetValue(Arrays[j]));
                                            valueOfProp2 = Convert.ToDouble(property1.GetValue(Arrays[j+1]));
                                            break;
                                        case "String" :
                                            valueOfProp1 = Convert.ToString(property1.GetValue(Arrays[j]));
                                            valueOfProp2 = Convert.ToString(property1.GetValue(Arrays[j + 1]));
                                            break;
                                        case "DateTime":
                                            valueOfProp1 = Convert.ToDateTime(property1.GetValue(Arrays[j]));
                                            valueOfProp2 = Convert.ToDateTime(property1.GetValue(Arrays[j + 1]));
                                            break;
                                        default:
                                            break;
                                    }
                                    if (valueOfProp1 > valueOfProp2)
                                    {
                                        var temp = Arrays[j];
                                        Arrays[j] = Arrays[j + 1];
                                        Arrays[j + 1] = temp;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (member.Count() > 1 || member.Count() == 0)
                                throw new MultipleOrNoPropertyException(Constant.MultipleOrNoPropertyErrorMsg);
                            else
                                throw new ReferenceTypePropException(Constant.ReferenceTypePropErrorMsg);
                        }
                    }
                }
            }

            return collection;
        }

        
    }
}
