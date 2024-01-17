using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Cross.Security.Reflection
{
    /// <summary>
    /// Clase de ayuda para trabajar con System.Reflection.
    /// </summary>
    public static class ReflectionHelper
    {
        #region Constantes

        /// <summary>
        /// Representa una lista vacía de argumentos.
        /// </summary>
        public static readonly object[] EmptyArgs = new object[] { };

        /// <summary>
        /// Establece el criterio de búsqueda de miembros para instancias.
        /// </summary>
        public static readonly BindingFlags InstanceFlags =
          BindingFlags.Instance | BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Public;

        /// <summary>
        /// Establece el criterio de búsqueda de miembros para clases.
        /// </summary>
        public static readonly BindingFlags ClassFlags =
          BindingFlags.Static | BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Public;

        #endregion

        #region Campos

        #region General

        /// <summary>
        /// Devuelve el campo de la instancia especificada.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="fieldName">Nombre del campo.</param>
        /// <returns>El campo de la instancia especificada.</returns>
        public static FieldInfo GetInstanceField(object obj, string fieldName)
        {
            Type type = obj.GetType();
            FieldInfo field = type.GetField(fieldName, ReflectionHelper.InstanceFlags);

            // HACK: Busca el campo en la clase de la instancia especificada y en sus superclases.
            while (field == null && type.BaseType != null)
            {
                type = type.BaseType;
                field = type.GetField(fieldName, ReflectionHelper.InstanceFlags);
            } // while

            return field;
        }

        /// <summary>
        /// Establece el valor del campo de la instancia especificada.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="fieldName">Nombre del campo.</param>
        /// <param name="value">Nuevo valor.</param>
        public static void SetInstanceFieldValue(object obj, string fieldName, object value)
        {
            FieldInfo field = ReflectionHelper.GetInstanceField(obj, fieldName);
            field.SetValue(obj, value);
        }

        /// <summary>
        /// Devuelve el valor del campo.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="fieldName">Nombre del campo.</param>
        /// <returns>El valor del campo.</returns>
        public static object GetInstanceFieldValue(object obj, string fieldName)
        {
            FieldInfo field = ReflectionHelper.GetInstanceField(obj, fieldName);
            return field.GetValue(obj);
        }

        #endregion

        #region Int32

        /// <summary>
        /// Devuelve el valor del campo.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="fieldName">Nombre del campo.</param>
        /// <returns>El valor del campo.</returns>
        public static int GetInt32FieldValue(object obj, string fieldName)
        {
            return (int)ReflectionHelper.GetInstanceFieldValue(obj, fieldName);
        }

        #endregion

        #region Array

        /// <summary>
        /// Devuelve el valor del campo.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="fieldName">Nombre del campo.</param>
        /// <returns>El valor del campo.</returns>
        public static Array GetArrayFieldValue(object obj, string fieldName)
        {
            return (Array)ReflectionHelper.GetInstanceFieldValue(obj, fieldName);
        }

        #endregion

        #region String

        /// <summary>
        /// Devuelve el valor del campo.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="fieldName">Nombre del campo.</param>
        /// <returns>El valor del campo.</returns>
        public static string GetStringFieldValue(object obj, string fieldName)
        {
            return (string)ReflectionHelper.GetInstanceFieldValue(obj, fieldName);
        }

        /// <summary>
        /// Establece el valor del campo.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="fieldName">Nombre del campo.</param>
        /// <param name="value">Nuevo valor del campo.</param>
        public static void SetStringFieldValue(object obj, string fieldName, string value)
        {
            ReflectionHelper.SetInstanceFieldValue(obj, fieldName, value);
        }

        #endregion

        #region IDictionary

        /// <summary>
        /// Devuelve el valor del campo.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="fieldName">Nombre del campo.</param>
        /// <returns>El valor del campo.</returns>
        public static IDictionary GetIDictionaryFieldValue(object obj, string fieldName)
        {
            return (IDictionary)ReflectionHelper.GetInstanceFieldValue(obj, fieldName);
        }

        #endregion

        #endregion

        #region Instanciación

        /// <summary>
        /// Devuelve una nueva instancia de la clase especificada.
        /// </summary>
        /// <param name="type">Clase a instanciar.</param>
        /// <param name="args">Parámetros del constructor.</param>
        /// <returns>Una nueva instancia de la clase especificada.</returns>
        public static object Instantiate(Type type, object[] args)
        {
#if FULL_FRAME

      // Utiliza el Binder predeterminado y el CultureInfo del thread actual.
      return Activator.CreateInstance(type, ReflectionHelper.InstanceFlags, null, args, null);

#else

            // Utiliza el Binder predeterminado y el CultureInfo del thread actual.
            return ReflectionHelper.CreateInstance(type, args);

#endif
        }

#if !FULL_FRAME

        /// <summary>
        /// Creates an instance of the specified type using the constructor that best matches the specified parameters.
        /// </summary>
        /// <param name="type">The type of object to create.</param>
        /// <param name="args">
        /// An array of arguments that match in number, order, and type the parameters of the constructor to invoke. 
        /// If args is an empty array or null, the constructor that takes no parameters (the default constructor) is invoked.
        /// </param>
        /// <returns>A reference to the newly created object.</returns>
        private static object CreateInstance(Type type, params object[] args)
        {
            Type[] types = new Type[args.Length];

            for (int i = 0; i < args.Length; i++)
                types[i] = (args[i] == null) ? null : args[i].GetType();

            ConstructorInfo ci = type.GetConstructor(ReflectionHelper.InstanceFlags, null, types, null);

            if (ci == null)
                throw new MissingMethodException();

            return ci.Invoke(args);
        }

#endif


        /// <summary>
        /// Devuelve una nueva instancia de la clase especificada.
        /// </summary>
        /// <param name="type">Clase a instanciar.</param>
        /// <returns>Una nueva instancia de la clase especificada.</returns>
        public static object Instantiate(Type type)
        {
            return ReflectionHelper.Instantiate(type, ReflectionHelper.EmptyArgs);
        }

        #endregion

        #region Métodos

        #region De instancia

        /// <summary>
        /// Devuelve el método de la instancia especificada.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="methodName">Nombre del método.</param>
        /// <param name="types">Array de tipos utilizado para identificar una determinada sobrecarga del método.</param>
        /// <returns>El método de la instancia especificada.</returns>
        public static MethodInfo GetInstanceMethod(object obj, string methodName, Type[] types)
        {
            Type type = obj.GetType();
            MethodInfo method =
              type.GetMethod(methodName, ReflectionHelper.InstanceFlags, null, types, null);

            // HACK: Busca el campo en la clase de la instancia especificada y en sus superclases.
            while (method == null && type.BaseType != null)
            {
                type = type.BaseType;
                method = type.GetMethod(methodName, ReflectionHelper.InstanceFlags);
            } // while

            return method;
        }

        /// <summary>
        /// Invoca el método que refleja la instancia actual, utilizando los parámetros especificados.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="methodName">Nombre del método.</param>
        /// <param name="parameters">Parámetros del método.</param>
        /// <returns>Un objeto que contiene el valor devuelto del método invocado.</returns>
        public static object InvokeMethod(object obj, string methodName, object[] parameters)
        {
            Type[] types = new Type[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
                types[i] = parameters[i].GetType();

            return ReflectionHelper.GetInstanceMethod(obj, methodName, types).Invoke(obj, parameters);
        }

        /// <summary>
        /// Invoca el método que refleja la instancia especificada.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="methodName">Nombre del método.</param>
        /// <returns>Un objeto que contiene el valor devuelto del método invocado.</returns>
        public static object InvokeMethod(object obj, string methodName)
        {
            return ReflectionHelper.InvokeMethod(obj, methodName, ReflectionHelper.EmptyArgs);
        }

        #endregion

        #region De clase

        /// <summary>
        /// Devuelve el método de la clase especificada.
        /// </summary>
        /// <param name="type">Clase a evaluar.</param>
        /// <param name="methodName">Nombre del método.</param>
        /// <param name="types">Array de tipos utilizado para identificar una determinada sobrecarga del método.</param>
        /// <returns>El método de la clase especificada.</returns>
        public static MethodInfo GetInstanceMethod(Type type, string methodName, Type[] types)
        {
            MethodInfo method =
              type.GetMethod(methodName, ReflectionHelper.ClassFlags, null, types, null);

            // HACK: Busca el campo en la clase de la clase especificada y en sus superclases.
            while (method == null && type.BaseType != null)
            {
                type = type.BaseType;
                method = type.GetMethod(methodName, ReflectionHelper.ClassFlags);
            } // while

            return method;
        }

        /// <summary>
        /// Invoca el método que refleja la instancia actual, utilizando los parámetros especificados.
        /// </summary>
        /// <param name="type">Clase a evaluar.</param>
        /// <param name="methodName">Nombre del método.</param>
        /// <param name="parameters">Parámetros del método.</param>
        /// <returns>Un objeto que contiene el valor devuelto del método invocado.</returns>
        public static object InvokeMethod(Type type, string methodName, object[] parameters)
        {
            Type[] types = new Type[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
                types[i] = parameters[i].GetType();

            return ReflectionHelper.GetInstanceMethod(type, methodName, types).Invoke(type, parameters);
        }

        /// <summary>
        /// Invoca el método que refleja la clase especificada.
        /// </summary>
        /// <param name="type">Clase a evaluar.</param>
        /// <param name="methodName">Nombre del método.</param>
        /// <returns>Un objeto que contiene el valor devuelto del método invocado.</returns>
        public static object InvokeMethod(Type type, string methodName)
        {
            return ReflectionHelper.InvokeMethod(type, methodName, ReflectionHelper.EmptyArgs);
        }

        #endregion

        #endregion

        #region Propiedades

        #region General

        /// <summary>
        /// Devuelve la propiedad de la instancia especificada.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="propertyName">Nombre de la propiedad.</param>
        /// <returns>La propiedad de la instancia especificada.</returns>
        public static PropertyInfo GetInstanceProperty(object obj, string propertyName)
        {
            Type type = obj.GetType();
            PropertyInfo property = type.GetProperty(propertyName, ReflectionHelper.InstanceFlags);

            // HACK: Busca la propiedad en la clase de la instancia especificada y en sus superclases.
            while (property == null && type.BaseType != null)
            {
                type = type.BaseType;
                property = type.GetProperty(propertyName, ReflectionHelper.InstanceFlags);
            } // while

            return property;
        }

        /// <summary>
        /// Establece el valor de la propiedad de la instancia especificada.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="propertyName">Nombre de la propiedad.</param>
        /// <param name="value">Nuevo valor.</param>
        public static void SetInstancePropertyValue(object obj, string propertyName, object value)
        {
            ReflectionHelper.SetInstancePropertyValue(obj, propertyName, value, null);
        }

        /// <summary>
        /// Establece el valor de la propiedad de la instancia especificada.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="propertyName">Nombre de la propiedad.</param>
        /// <param name="value">Nuevo valor.</param>
        /// <param name="index">Valores de índices para propiedades indizadas.</param>
        public static void SetInstancePropertyValue(object obj, string propertyName, object value, object[] index)
        {
            PropertyInfo property = ReflectionHelper.GetInstanceProperty(obj, propertyName);
            property.SetValue(obj, value, index);
        }

        /// <summary>
        /// Devuelve el valor de la propiedad.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="propertyName">Nombre de la propiedad.</param>
        /// <returns>El valor de la propiedad.</returns>
        public static object GetInstancePropertyValue(object obj, string propertyName)
        {
            return ReflectionHelper.GetInstancePropertyValue(obj, propertyName, null);
        }

        /// <summary>
        /// Devuelve el valor de la propiedad.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="propertyName">Nombre de la propiedad.</param>
        /// <param name="index">Valores de índices para propiedades indizadas.</param>
        /// <returns>El valor de la propiedad.</returns>
        public static object GetInstancePropertyValue(object obj, string propertyName, object[] index)
        {
            PropertyInfo property = ReflectionHelper.GetInstanceProperty(obj, propertyName);
            return property.GetValue(obj, index);
        }

        #endregion

        #region Int32

        /// <summary>
        /// Devuelve el valor de la propiedad.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="propertyName">Nombre de la propiedad.</param>
        /// <returns>El valor de la propiedad.</returns>
        public static int GetInt32PropertyValue(object obj, string propertyName)
        {
            return (int)ReflectionHelper.GetInstancePropertyValue(obj, propertyName);
        }

        #endregion

        #region Array

        /// <summary>
        /// Devuelve el valor de la propiedad.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="propertyName">Nombre de la propiedad.</param>
        /// <returns>El valor de la propiedad.</returns>
        public static Array GetArrayPropertyValue(object obj, string propertyName)
        {
            return (Array)ReflectionHelper.GetInstancePropertyValue(obj, propertyName);
        }

        #endregion

        #region String

        /// <summary>
        /// Devuelve el valor de la propiedad.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="propertyName">Nombre de la propiedad.</param>
        /// <returns>El valor de la propiedad.</returns>
        public static string GetStringPropertyValue(object obj, string propertyName)
        {
            return (string)ReflectionHelper.GetInstancePropertyValue(obj, propertyName);
        }

        /// <summary>
        /// Establece el valor de la propiedad.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="propertyName">Nombre de la propiedad.</param>
        /// <param name="value">Nuevo valor de la propiedad.</param>
        public static void SetStringPropertyValue(object obj, string propertyName, string value)
        {
            ReflectionHelper.SetStringPropertyValue(obj, propertyName, value, null);
        }

        /// <summary>
        /// Establece el valor de la propiedad.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="propertyName">Nombre de la propiedad.</param>
        /// <param name="value">Nuevo valor de la propiedad.</param>
        /// <param name="index">Valores de índices para propiedades indizadas.</param>
        public static void SetStringPropertyValue(object obj, string propertyName, string value, object[] index)
        {
            ReflectionHelper.SetInstancePropertyValue(obj, propertyName, value, index);
        }

        #endregion

        #region Boolean

        /// <summary>
        /// Devuelve el valor de la propiedad.
        /// </summary>
        /// <param name="obj">Instancia actual.</param>
        /// <param name="propertyName">Nombre de la propiedad.</param>
        /// <returns>El valor de la propiedad.</returns>
        public static bool GetBoolPropertyValue(object obj, string propertyName)
        {
            return (bool)ReflectionHelper.GetInstancePropertyValue(obj, propertyName);
        }

        #endregion

        #endregion

        #region DllImport

#if !FULL_FRAME

        [DllImport("coredll.dll", SetLastError = true)]
        private static extern int GetModuleFileName(IntPtr hModule, byte[] lpFilename, int nSize);

#endif

        #endregion

        #region Assembly

#if !FULL_FRAME

        /// <summary>
        /// Devuelve el <see cref="Assembly"/> que representa el proceso en ejecución.
        /// </summary>
        /// <returns>El <see cref="Assembly"/> que representa el proceso en ejecución.</returns>
        public static Assembly GetEntryAssembly()
        {
            byte[] buffer = new byte[256 * Marshal.SystemDefaultCharSize];
            int chars = GetModuleFileName(IntPtr.Zero, buffer, 255);

            if (chars > 0)
            {
                if (chars > 255)
                    throw new System.IO.PathTooLongException("Assembly name is longer than MAX_PATH characters.");

                string assemblyPath = System.Text.Encoding.Unicode.GetString(buffer, 0, chars * Marshal.SystemDefaultCharSize);

                return Assembly.LoadFrom(assemblyPath);
            }
            else
                return null;
        }

#endif

        #endregion
    }
}
