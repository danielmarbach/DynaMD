﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaMD.TestChildProcess
{
    public class Program
    {
        public const string Ready = "Ready";

        static void Main(string[] args)
        {
            var values = new object[]
            {
                new ClassWithReference(),
                new ClassWithStringField(),
                new ClassWithStringProperty(),
                new ClassWithULongField(),
                new ClassWithArray(),
                new StructWithStringField("OK"),
                new StructWithULongField(666),
                new ClassWithStructField(),
                new ClassWithArrayOfStruct(),
                new ClassWithArrayOfClass(),
                new StructWithStructField(666),
                new StructWithStructWithStructField(666)
            };

            Console.WriteLine(Ready);

            Console.ReadLine();

            GC.KeepAlive(values);
        }
    }

    public class ClassWithArray
    {
        public int Field;
        public int Field2;
        public int Field3;
        public int[] Values = Enumerable.Range(0, 10).Select(i => 10 - i).ToArray();
    }

    public class ClassWithArrayOfClass
    {
        public int Field;
        public int Field2;
        public int Field3;
        public ClassWithStringField[] Values = Enumerable.Range(0, 10).Select(i => new ClassWithStringField { Value = i.ToString() }).ToArray();
    }


    public class ClassWithReference
    {
        public ClassWithStringField Reference = new ClassWithStringField();
    }

    public class ClassWithStringField
    {
        public string Value = "OK";
    }

    public class ClassWithStringProperty
    {
        public string Field { get; set; }

        public ClassWithStringProperty()
        {
            Field = "OK";
        }
    }

    public class ClassWithULongField
    {
        public ulong Value = 666;
    }

    public struct StructWithStringField
    {
        public string Value;

        public StructWithStringField(string value)
        {
            Value = value;
        }
    }

    public struct StructWithStructWithStructField
    {
        public int Field1;
        public int Field2;
        public StructWithStructField Value;

        public StructWithStructWithStructField(ulong value)
        {
            Field1 = 42;
            Field2 = 43;
            Value = new StructWithStructField(value);
        }
    }

    public struct StructWithStructField
    {
        public int Field1;
        public int Field2;
        public StructWithULongField Value;

        public StructWithStructField(ulong value)
        {
            Field1 = 42;
            Field2 = 43;
            Value = new StructWithULongField(value);
        }
    }

    public struct StructWithULongField
    {
        public int Field;
        public int Field2;
        public int Field3;
        public int Field4;
        public int Field5;
        public ulong Value;

        public StructWithULongField(ulong value)
        {
            Field = 42;
            Field2 = 43;
            Field3 = 44;
            Field4 = 45;
            Field5 = 46;
            Value = value;
        }
    }

    public class ClassWithStructField
    {
        public int Field = 4;
        public int Field2 = 4;
        public StructWithULongField Value = new StructWithULongField(666);
    }

    public class ClassWithArrayOfStruct
    {
        public int Field = 4;
        public int Field2 = 4;
        public StructWithULongField[] Array;

        public ClassWithArrayOfStruct()
        {
            Array = new StructWithULongField[4];

            for (int i = 0; i < 4; i++)
            {
                Array[i] = new StructWithULongField((ulong)i);
            }
        }
    }

}
