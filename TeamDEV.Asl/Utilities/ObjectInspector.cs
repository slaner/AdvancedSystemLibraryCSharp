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
            TraceBuffer buffer = new TraceBuffer();
            InspectInternal(instance, typeof(T), bindingFlags, buffer);
            Console.WriteLine(buffer.ToString());
        }

        private static void InspectInternal(object instance, Type type, BindingFlags bindingFlags, TraceBuffer buffer) {
            // if type is atomic type, we'll just print it
            if (type.IsAtomicType()) {
                Console.WriteLine(instance);
                return;
            }

            // if type is not value type and it is default(null), exit
            if (!type.IsValueType && IsDefault(instance)) return;
            
            // Inspect members
            InspectMembers(buffer, instance, type, bindingFlags);
        }
        
        private static void InspectField<T>(TraceBuffer buffer, FieldInfo field, T instance, BindingFlags bindingFlags) {
            buffer.Append($"{field.FieldType} {field.Name}", true);

            object value = GetFieldValue(field, instance);

            // We'll trace it's value if atomic type (primitive types and string)
            if (field.FieldType.IsAtomicType())
                buffer.AppendLine($" = {value}", false);
            
            else {
                buffer.AppendLineNoIndent();
                InspectInternal(value, field.FieldType, bindingFlags, buffer);
            }
        }
        private static void InspectProperty<T>(TraceBuffer buffer, PropertyInfo property, T instance, BindingFlags bindingFlags) {
            // If there's no getter on this property,
            // abort tracing
            if (!property.CanRead) return;

            // Check binding flag
            MethodInfo method = property.GetMethod;
            if (!method.IsPublic && !bindingFlags.HasFlag(BindingFlags.NonPublic)) return;

            // If property takes parameter,
            // abort tracing
            if (!method.GetParameters().IsEmpty()) return;
            
            buffer.Append($"{property.PropertyType} {property.Name}", true);
            object value = GetMethodValue(method, instance);

            // We'll trace it's value if atomic type (primitive types and string)
            if (property.PropertyType.IsAtomicType())
                buffer.AppendLine($" = {value}", false);

            else {
                if (value == null) buffer.Append(" = null");
                else {
                    buffer.AppendLineNoIndent();
                    InspectInternal(value, property.PropertyType, bindingFlags, buffer);
                }
            }
        }

        private static void InspectMembers<T>(TraceBuffer buffer, T instance, Type type, BindingFlags bindingFlags) {
            buffer.AppendLine(type.Name);
            buffer.Indent();

            var members = type.GetMembers();
            if (members.IsEmpty()) {
                buffer.AppendLine(Const.Empty);
                buffer.Unindent();
                return;
            }

            foreach (var member in members) {
                if (member.MemberType.HasFlag(MemberTypes.Field)) {
                    InspectField(buffer, member as FieldInfo, instance, bindingFlags);
                }

                if (member.MemberType.HasFlag(MemberTypes.Property)) {
                    InspectProperty(buffer, member as PropertyInfo, instance, bindingFlags);
                }
            }
            buffer.Unindent();
        }

        
        private static object GetMethodValue(MethodInfo method, object instance = null) {
            if (method.IsStatic && instance != null) instance = null;
            return method.Invoke(instance, null);
        }
        private static bool IsDefault<T>(T value) {
            return Equals(value, default(T));
        }
        private static object GetFieldValue(FieldInfo field, object instance = null) {
            if (field.IsStatic && instance != null) instance = null;
            return field.GetValue(instance);
        }
        private static bool IsAtomicType(this Type t) {
            return Const.AtomicTypes.ContainsKey(t.Name) && (t == Const.AtomicTypes[t.Name]);
        }
    }
}