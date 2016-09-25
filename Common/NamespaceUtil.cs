using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Common
{
    public class NamespaceUtil
    {
        public static Type[] obterTiposPorNamespace(Assembly assembly, string @namespace)
        {
            //Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] typelist = assembly.GetTypes().Where(objAssemble => String.Equals(objAssemble.Namespace, @namespace, StringComparison.Ordinal)).ToArray();
            return typelist;
        }

        public static Type[] obterTiposPorNamespace<T>(string @namespace)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] typelist = assembly.GetTypes().Where(objAssemble => String.Equals(objAssemble.Namespace, @namespace, StringComparison.Ordinal) && objAssemble is T).ToArray();
            return typelist;
        }
    }
}
