//---------------------------------------------------------------------------------
// Copyright 2012 Tomasz Cielecki (tomasz@ostebaronen.dk)
// Licensed under the Apache License, Version 2.0 (the "License"); 
// You may not use this file except in compliance with the License. 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, 
// INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR 
// CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, 
// MERCHANTABLITY OR NON-INFRINGEMENT. 

// See the Apache 2 License for the specific language governing 
// permissions and limitations under the License.
//---------------------------------------------------------------------------------

using System;
using System.Xml.Serialization;
using System.IO;

namespace MonoDroid.WAToolkit.Library.Utilities
{
    public class SerializationHelper
    {
        public static void SerializeData<T>(T data, Stream stream)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            ser.Serialize(stream, data);
        }

        public static T DeserializeData<T>(Stream stream)
            where T : class
        {
            if (stream == null) throw new ArgumentNullException("stream");
            XmlSerializer ser = new XmlSerializer(typeof(T));
            return (T)ser.Deserialize(stream);
        }
    }
}