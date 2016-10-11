using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellProject
{
    public class HalfSynchronizedClassSmell
    {
        public HalfSynchronizedClassSmell()
        {
            var a = new A();
            var b = new B();
            a.B = b;
            b.A = a;
            a.DoAStuff();
        }
    }

    public class A
    {
        public B B { get; set; }
        public void DoAStuff()
        {
            var x = 2;
            {
                var z = 2;
            }
            lock (this)
            {
                B.DoBStuff();
            }
        }
    }
    public class B
    {
        public A A { get; set; }
        public void DoBStuff()
        {
            lock (this)
            {
                A.DoAStuff();
            }
        }
    }
    
}
