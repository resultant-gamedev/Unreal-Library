﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace UELib
{
    public class BinaryMetaData
    {
        public struct BinaryField : IUnrealDecompilable
        {
            public string Name;
            public object Tag;
            public long Position;
            public long Size;

            public string Decompile()
            {
                return Tag != null ? Tag.ToString() : "NULL";
            }
        }

        public Stack<BinaryField> Fields;

        [Conditional( "DEBUG" ), Conditional( "BINARYMETADATA" )]
        public void AddField( string name, object tag, long position, long size )
        {
            Debug.Assert( size > 0, String.Format( "Invalid {0} binary field!", name ) );
            if( Fields == null )
            {
                Fields = new Stack<BinaryField>();
            }

            Fields.Push
            ( 
                new BinaryField
                {
                    Name = name,
                    Tag = tag,
                    Position = position,
                    Size = size
                }
            );
        }
    }
}