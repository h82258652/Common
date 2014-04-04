using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Test
{
    internal class JavaScriptVar<T>
    {
        public T Value
        {
            get;
            set;
        }

        public JavaScriptVar(T value)
        {
            this.Value = value;
        }

        public static implicit operator JavaScriptVar<T>(T value)
        {
            Console.WriteLine("var temp = " + value + ";");
            var o = new JavaScriptVar<T>(value);
            if (ForTest.wrr == null)
            {
                ForTest.wrr = new WeakReference(o);
            }
            else
            {
                var xxx = ForTest.wrr.Target as JavaScriptVar<T>;
                xxx.Value = value;
                return xxx;
            }
            return o;
        }

        public static implicit operator T(JavaScriptVar<T> jsv)
        {
            return jsv.Value;
        }
    }

   class Window
    {
       public static void Alert<T>(JavaScriptVar<T> jsv)
       {
           Console.WriteLine("alert(" + jsv.Value + ");");
       }
    }

    class ForTest
    {
        public static WeakReference wrr;

        public static bool X<T>(T myArgument)
        {
            return (object.Equals(myArgument, default(T)));
        }

        public static void MyMain()
        {
            Console.WriteLine(X(0));
            Console.WriteLine(X("ss"));
            string s = null;

            Console.WriteLine(X(s));
            Console.ReadKey();


            Expression<Func<string>> e =()=> "a";

var qqq=            Expression.Parameter(typeof (int), "ax");


var q=            Expression.Constant(1, typeof (int));

            //JSvar v = 1;//var temp = 1;
            //v.Value = 4444;// temp = 4444;

            //Window.Alert(v);// alert(temp);


            int a = 1;
            WeakReference wr = new WeakReference(a);
            Console.WriteLine(wr.Target);

            JavaScriptVar<int> j = 1;
            Console.WriteLine(wrr.IsAlive);
            j = 2;
            GC.Collect();
            Console.WriteLine(wrr.IsAlive);
            int x = j;
            Window.Alert(j);
            Console.ReadKey();
        }
    }
}
