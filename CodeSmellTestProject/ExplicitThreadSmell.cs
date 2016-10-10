using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeSmellTestProject
{
    class ExplicitThreadSmell
    {
        public void Test1()
        {
            new Thread(Compute).Start();

        }

        public void Test2()
        {
            var thread = new Thread(Compute);
            thread.Start();
            thread.Join();
            
        }
        private void Compute()
        {
            int i = 10;
            i++;
        }

        public void Test3(Thread ttt)
        {
            int i = 1;
            if (i == 1)
            {
                Thread t, l;
                t = new Thread(Compute);
                t.Start();
                Test3(t);

                l = new Thread(Compute);
                l.Start();
            }
            else
            {
                Thread t = new Thread(Compute);

                t.Start();
                //Hallo(t);
            }
        }

        private void Test4()
        {
            Thread t = new Thread(Compute);
            t.Start();
        }

        public void Test5()
        {
            new Thread(() => { int i = 10; i++; }).Start();
        }
    }
}
