using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TeamDEV.Asl.Extensions;

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
            Inspect(instance, BindingFlags.Public | BindingFlags.Instance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="bindingFlags"></param>
        public static void Inspect<T>(T instance, BindingFlags bindingFlags) {
            // check if given parameter is default value
            if (instance.Equals(default(T))) return;

            // Get type from type parameter
            Type targetType = typeof(T);

            // StringBuilder instance for fastest text operation
            StringBuilder buffer = new StringBuilder();

            // Inspect fields
            InspectFields(buffer, instance, targetType, bindingFlags);
            InspectProperties(buffer, instance, targetType, bindingFlags);


            InspectMembers(buffer, instance, targetType, bindingFlags);

            Console.WriteLine(buffer.ToString());
        }

        private static void InspectFields<T>(StringBuilder buffer, T instance, Type type, BindingFlags bindingFlags) {
            // HEADER
            buffer.AppendLine($"<{Const.Field}>");

            var fields = type.GetFields(bindingFlags);
            if (fields.IsEmpty()) {
                buffer.AppendLine($"  {Const.Empty}");
                return;
            }

            foreach (var field in fields) {
                Type fieldType = field.FieldType;


                if (fieldType.IsAtomicType()) {

                }
                object value = field.GetValue(instance);

                if (field.FieldType.IsAtomicType()) {
                    buffer.AppendLine($"  {field.FieldType} {field.Name} = {field.GetValue(instance)}");
                } else {
                    buffer.AppendLine($"  {field.FieldType} {field.Name}");
                }
            }
        }

        private static void InspectProperties<T>(StringBuilder buffer, T instance, Type type, BindingFlags bindingFlags) {
            // HEADER
            buffer.AppendLine($"<{Const.Property}>");

            var properties = type.GetProperties(bindingFlags);
            if (properties.IsEmpty()) {
                buffer.AppendLine($"  {Const.Empty}");
                return;
            }

            foreach (var property in properties) {
                buffer.AppendLine($"  {property.PropertyType} {property.Name} = {property.GetValue(instance)}");
            }
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



        private static bool IsAtomicType(this Type t) {
            return Const.AtomicTypes.ContainsKey(t.Name) && (t == Const.AtomicTypes[t.Name]);
        }
    }
}