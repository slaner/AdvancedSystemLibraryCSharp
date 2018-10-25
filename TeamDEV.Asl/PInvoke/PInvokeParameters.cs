using System;
using System.Collections;
using System.Collections.Generic;

namespace TeamDEV.Asl.PInvoke {
    /// <summary>
    /// 
    /// </summary>
    public sealed class PInvokeParameters {
        private readonly Dictionary<string, object> innerDictionary = new Dictionary<string, object>();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void RemoveParameter(string name) {
            innerDictionary.Remove(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object this[string name] {
            get { return innerDictionary[name]; }
            set { innerDictionary[name] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count => innerDictionary.Count;
    }
}