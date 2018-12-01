using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TeamDEV.Asl.Utilities {
    /// <summary>
    /// 
    /// </summary>
    public static class ObjectInspector {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        public static void Inspect<T>(T instance) {
            Inspect(instance, BindingFlags.Public);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="bindingFlags"></param>
        public static void Inspect<T>(T instance, BindingFlags bindingFlags) {
            // check if given parameter is default value
            if (default(T).Equals(instance)) {
                return;
            }

            // Get type from type parameter
            Type targetType = typeof(T);

            // StringBuilder instance for fastest text operation
            StringBuilder buffer = new StringBuilder();

            // Inspect members
            InspectMembers(buffer, instance, targetType, bindingFlags);

            Console.WriteLine(buffer.ToString());
        }

        


        private static void InspectMembers<T>(StringBuilder buffer, T instance, Type type, BindingFlags bindingFlags) {
            // HEADER
            buffer.AppendLine("<Members>");

            var members = type.GetMembers();
            if (members.Count() == 0) {
                buffer.AppendLine("  None");
                return;
            }

            foreach (var member in members) {
                object value = null;

                buffer.AppendLine($"  [{member.MemberType}] {member.ReflectedType.Name} {member.Name}: ");
            }
        }
    }
}