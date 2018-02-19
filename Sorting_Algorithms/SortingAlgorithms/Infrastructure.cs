using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingAlgorithms
{
    public class Constant
    {
        public const string EmptyString="";
        public const string PropertyErrorMsg = "Property name not specified";
        public const string MultipleOrNoPropertyErrorMsg = "Mulitple Or No Property Exists with Provided Name";
        public const string ReferenceTypePropErrorMsg = "Provided Property is a reference type";
    }
    public enum SortingOrder:byte
    {
        Ascending=1,
        Descending=2
    }
    public enum KeyValuePairSortingOn:byte
    {
        Key=1,
        Value=2,
        None=3
    }


    [Serializable]
    public class PropertyNameException : Exception
    {
        public PropertyNameException() { }
        public PropertyNameException(string message) : base(message) { }
        public PropertyNameException(string message, Exception inner) : base(message, inner) { }
        protected PropertyNameException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class MultipleOrNoPropertyException : Exception
    {
        public MultipleOrNoPropertyException() { }
        public MultipleOrNoPropertyException(string message) : base(message) { }
        public MultipleOrNoPropertyException(string message, Exception inner) : base(message, inner) { }
        protected MultipleOrNoPropertyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class ReferenceTypePropException : Exception
    {
        public ReferenceTypePropException() { }
        public ReferenceTypePropException(string message) : base(message) { }
        public ReferenceTypePropException(string message, Exception inner) : base(message, inner) { }
        protected ReferenceTypePropException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public struct MemberTypeInfo:IDisposable
    {

        System.Reflection.MemberInfo memberInfo;
        public MemberTypeInfo(System.Reflection.MemberInfo memberInfo)
        {
            this.memberInfo = memberInfo;
        }

        public void Dispose()
        {
            memberInfo = null;
        }
        
    }
   
}
