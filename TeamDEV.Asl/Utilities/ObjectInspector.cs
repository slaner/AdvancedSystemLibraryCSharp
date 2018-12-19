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
        public static void Inspect<T>(T instance, char indentChar = TraceBuffer.DefaultIndentChar, int indentSize = TraceBuffer.DefaultIndentSize) {
            Inspect(instance, BindingFlags.Public | BindingFlags.Instance, indentChar, indentSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="bindingFlags"></param>
        public static void Inspect<T>(T instance, BindingFlags bindingFlags, char indentChar = TraceBuffer.DefaultIndentChar, int indentSize = TraceBuffer.DefaultIndentSize) {
            TraceBuffer buffer = new TraceBuffer(indentChar, indentSize);
            Type type = typeof(T);
            buffer.AppendLine(type.Name, false);
            InspectInternal(instance, type, bindingFlags, buffer);
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

        private static void TraceMemberInfo(TraceBuffer buffer, MemberInfo memberInfo, Type type, object value, BindingFlags bindingFlags) {
            buffer.Append($"{type.Name} {memberInfo.Name}", true);
            if (type.IsAtomicType()) {
                if (type.IsStringType()) value = $"\"{value}\"";
                buffer.AppendLine($" = {value}", false);
            } else {
                if (value == null) buffer.AppendLine(" = null", false);
                else {
                    buffer.AppendLineNoIndent();
                    InspectInternal(value, type, bindingFlags, buffer);
                }
            }
        }
        
        private static void InspectField<T>(TraceBuffer buffer, FieldInfo field, T instance, BindingFlags bindingFlags) {
            object value = GetFieldValue(field, instance);
            TraceMemberInfo(buffer, field, field.FieldType, value, bindingFlags);
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

            object value = GetMethodValue(method, instance);
            TraceMemberInfo(buffer, property, property.PropertyType, value, bindingFlags);
        }

        private static void InspectMembers<T>(TraceBuffer buffer, T instance, Type type, BindingFlags bindingFlags) {
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
            object value;
            try { value = method.Invoke(instance, null); }
            catch { return null; }
            return value;
        }
        private static object GetFieldValue(FieldInfo field, object instance = null) {
            object value;
            try { value = field.GetValue(instance); }
            catch { return null; }
            return value;
        }
        private static bool IsDefault<T>(T value) {
            return Equals(value, default(T));
        }
    }
}