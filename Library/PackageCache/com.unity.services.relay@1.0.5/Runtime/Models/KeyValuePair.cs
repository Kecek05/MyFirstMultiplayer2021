//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Scripting;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Unity.Services.Relay.Http;



namespace Unity.Services.Relay.Models
{
    /// <summary>
    /// KeyValuePair model
    /// </summary>
    [Preserve]
    [DataContract(Name = "KeyValuePair")]
    public class KeyValuePair
    {
        /// <summary>
        /// Creates an instance of KeyValuePair.
        /// </summary>
        /// <param name="key">key param</param>
        /// <param name="value">value param</param>
        [Preserve]
        public KeyValuePair(string key, string value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Parameter key of KeyValuePair
        /// </summary>
        [Preserve]
        [DataMember(Name = "key", IsRequired = true, EmitDefaultValue = true)]
        public string Key{ get; }
        
        /// <summary>
        /// Parameter value of KeyValuePair
        /// </summary>
        [Preserve]
        [DataMember(Name = "value", IsRequired = true, EmitDefaultValue = true)]
        public string Value{ get; }
    
        /// <summary>
        /// Formats a KeyValuePair into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (Key != null)
            {
                serializedModel += "key," + Key + ",";
            }
            if (Value != null)
            {
                serializedModel += "value," + Value;
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a KeyValuePair as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (Key != null)
            {
                var keyStringValue = Key.ToString();
                dictionary.Add("key", keyStringValue);
            }
            
            if (Value != null)
            {
                var valueStringValue = Value.ToString();
                dictionary.Add("value", valueStringValue);
            }
            
            return dictionary;
        }
    }
}
