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
            // Get type from type parameter
            Type targetType = typeof(T);

            // StringBuilder instance for fastest text operation
            TraceBuffer buffer = new TraceBuffer();

            // Inspect Methods
            InspectMethods(buffer, instance, targetType, bindingFlags);

            // Inspect Fields
            InspectFields(buffer, instance, targetType, bindingFlags);
            //InspectProperties(buffer, instance, targetType, bindingFlags);


            //InspectMembers(buffer, instance, targetType, bindingFlags);

            Console.WriteLine(buffer.ToString());
        }

        private static void InspectMethods<T>(TraceBuffer buffer, T instance, Type type, BindingFlags bindingFlags) {
            buffer.AppendLine($"<{Const.Method}>");
            buffer.Indent();

            var methods = type.GetMethods(bindingFlags);
            if (methods.IsEmpty()) {
                buffer.AppendLine(Const.Empty);
                buffer.Unindent();
                return;
            }

            foreach (var method in methods) {
                BuildMethodDefinition(buffer, method);
            }

            buffer.AppendLine();
            buffer.Unindent();
        }

        private static void InspectFields<T>(TraceBuffer buffer, T instance, Type type, BindingFlags bindingFlags) {
            buffer.AppendLine($"<{Const.Field}>");
            buffer.Indent();

            var fields = type.GetFields(bindingFlags);
            if (fields.IsEmpty()) {
                buffer.AppendLine(Const.Empty);
                buffer.Unindent();
                return;
            }

            bool isValueType = typeof(T).IsValueType;
            bool isDefault = Equals(default(T), instance);

            foreach (var field in fields) {
                buffer.Append($"{field.FieldType} {field.Name}", true);

                object value = field.GetValue(instance);
                if (field.FieldType.IsAtomicType())
                    buffer.Append($" = {value}");
                else {
                    if (value != null) {
                        buffer.Append($" = {value}");
                    } else buffer.Append(" = null");
                }

                buffer.AppendLineNoIndent();
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



        private static void BuildMethodDefinition(TraceBuffer buffer, MethodInfo method) {
            buffer.Append($"{method.ReturnType} {method.Name}(", true);
            var parameters = method.GetParameters();
            if (parameters.Length == 0) {
                buffer.AppendLine($")", false);
                return;
            }

            int i;
            for (i = 0; i < parameters.Length - 1; i++) {
                var parameter = parameters[i];
                BuildMethodParameterDefinition(buffer, parameter);
                buffer.Append(", ");
            }

            BuildMethodParameterDefinition(buffer, parameters[i]);
            buffer.AppendLine(")", false);
        }
        private static void BuildMethodParameterDefinition(TraceBuffer buffer, ParameterInfo parameter) {
            if (parameter.IsOptional) buffer.Append("[optional] ");
            if (parameter.IsOut) buffer.Append("[out] ");
            if (parameter.IsRetval) buffer.Append("[retval] ");
            buffer.Append($"{parameter.ParameterType} {parameter.Name}");
        }
        private static bool IsAtomicType(this Type t) {
            return Const.AtomicTypes.ContainsKey(t.Name) && (t == Const.AtomicTypes[t.Name]);
        }
    }
}