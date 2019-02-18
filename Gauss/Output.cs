using System.IO;

namespace Gauss
{
    class Output
    {

        public Output()
        {
            using (StreamWriter output = new StreamWriter("output.txt"))
            {
                output.WriteLine("");
                output.WriteLine("IER = {0}", Input.IER);
                output.WriteLine("");
                if (Input.IER==0)
                {
                    output.WriteLine("Решение системы:");
                    for (int i = 0; i < Input.n; i++)
                    {
                        output.Write("{0:f2}\t", Input.x[i]);
                    }
                    output.WriteLine("");

                    if (Input.x[1]==0 & Input.x[2]==-1 )
                    {
                        output.WriteLine("");
                        output.WriteLine("Погрешность: ");
                        for (int i = 0; i < Input.p.Length; i++)
                        {
                            output.Write("{0:f2}\t", Input.p[i]);
                        }
                        output.WriteLine("");
                    }

                    output.WriteLine("");

                    output.WriteLine("Вектор невязки:");
                    for (int i = 0; i < Input.n; i++)
                    {
                        output.Write("{0:f2}\t", Input.u[i]);
                    }

                    output.WriteLine("");
                    output.WriteLine("");

                    output.WriteLine("Определитель матрицы: {0}", Input.det);
                }
            }
        }
    }
}
