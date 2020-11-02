using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TreeViewFilterTest
{
    //TODO: Use Dependency Container (e.g. Ninject) to be more flexible with loading classes.
    public class ClassLoaderByNamespace
    {
        /// <summary>
        /// Creates instances of all classes for given namespace and caste them to T.
        /// </summary>
        public static IEnumerable<T> Load<T>(string @namespace)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var namespaceTypes = assembly.GetTypes().Where(t => t.Namespace == @namespace);
            foreach (var type in namespaceTypes)
            {
                yield return (T)Activator.CreateInstance(type);
            }
        }
    }
}