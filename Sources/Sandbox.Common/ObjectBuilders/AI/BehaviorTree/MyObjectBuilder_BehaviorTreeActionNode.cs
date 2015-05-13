﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Sandbox.Common.ObjectBuilders.AI
{
    [Flags]
    public enum MyMemoryParameterType : byte
    {
        IN = 1 << 0,
        OUT = 1 << 1,
        IN_OUT = IN | OUT,
    }

    [ProtoContract]
    [MyObjectBuilderDefinition]
    public class MyObjectBuilder_BehaviorTreeActionNode : MyObjectBuilder_BehaviorTreeNode
    {
        [ProtoContract]
        public abstract class TypeValue
        {
            public abstract object GetValue();
        }

        [ProtoContract]
        public class IntType : TypeValue
        {
            [XmlAttribute]
            [ProtoMember(1)]
            public int IntValue;
            public override object GetValue()
            {
                return IntValue;
            }
        }

        [ProtoContract]
        public class StringType : TypeValue
        {
            [XmlAttribute]
            [ProtoMember(1)]
            public string StringValue;

            public override object GetValue()
            {
                return StringValue;
            }
        }

        [ProtoContract]
        public class FloatType : TypeValue
        {
            [XmlAttribute]
            [ProtoMember(1)]
            public float FloatValue;

            public override object GetValue()
            {
                return FloatValue;
            }
        }

        [ProtoContract]
        public class BoolType : TypeValue
        {
            [XmlAttribute]
            [ProtoMember(1)]
            public bool BoolValue;

            public override object GetValue()
            {
                return BoolValue;
            }
        }

        [ProtoContract]
        public class MemType : TypeValue
        {
            [XmlAttribute]
            [ProtoMember(1)]
            public string MemName;

            public override object GetValue()
            {
                return MemName;
            }
        }

        [ProtoMember(1)]
        public string ActionName = null;

        [ProtoMember(2)]
        [XmlArrayItem("Parameter")]
        public TypeValue[] Parameters = null;
    }
}