using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Common.Reflection
{
    public static partial class ReflectionHelper
    {
        /// <summary>
        /// 执行一段 C# 代码并返回结果。
        /// </summary>
        /// <param name="codeBody">方法体。</param>
        /// <returns>方法的返回值。</returns>
        public static object RunCode(string codeBody)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            return RunCode(codeBody, parameters);
        }

        /// <summary>
        /// 执行一段 C# 代码并返回结果。
        /// </summary>
        /// <param name="codeBody">方法体。</param>
        /// <param name="parameters">参数（名称，值）。</param>
        /// <returns>方法的返回值。</returns>
        public static object RunCode(string codeBody, Dictionary<string, object> parameters)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameter = new CompilerParameters();
            parameter.GenerateExecutable = false;
            parameter.GenerateInMemory = true;
            StringBuilder sb = new StringBuilder();// 生成方法参数代码。
            List<object> methodParameters = new List<object>();// 调用方法时的参数对象列表。
            for (int i = 0; i < parameters.Count; i++)
            {
                var temp = parameters.ElementAt(i);
                sb.Append(temp.Value.GetType().FullName + " " + temp.Key);
                methodParameters.Add(temp.Value);
                if (i != parameters.Count - 1)
                {
                    sb.Append(",");
                }
            }
            string source = @"using System;namespace NameSpace{public class Class{public static object Method(" + sb.ToString() + @"){" + codeBody + @"}}}";// 最终代码段。
            CompilerResults result = provider.CompileAssemblyFromSource(parameter, source);// 编译代码。
            if (result.Errors.Count > 0)
            {
                throw new Exception("代码错误");
            }
            else
            {
                Assembly assembly = result.CompiledAssembly;// 获得编译成功的程序集。
                Type type = assembly.GetType("NameSpace.Class");
                return type.GetMethod("Method").Invoke(null, methodParameters.ToArray());// 执行方法。
            }
        }
    }
}
