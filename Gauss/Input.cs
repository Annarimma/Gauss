using System;
using System.Linq;
using System.IO;


namespace Gauss
{
    static class Input
    {
        static public double[,] matrix;
        static public double[] f;
        static public int n;

        static public double det;
        static public int IER=0;
        static public double[] x = new double[n];
        static public double[] u = new double[n];
        static public double[] p = new double[n];

        static public void Read()
        {
            n = Convert.ToInt32(File.ReadLines("input.txt").Skip(0).First());

            matrix = new double[n,n];
            f = new double[n];

            string temp;
            

            for (int u = 1; u < n+1; u++)
            {
                temp = File.ReadLines("input.txt").Skip(u).First();
                double [] result = temp.Split(' ').Select(double.Parse).ToArray();
                for (int i=0; i<n; i++)
                {
                    matrix[u - 1, i] = result[i];
                }

            }


            string temp1 = File.ReadLines("input.txt").Skip(n+1).First();
            double[] result1 = temp1.Split(' ').Select(double.Parse).ToArray();
            for (int i = 0; i < n; i++)
            {
                f[i] = result1[i];
            }
        }
    }
}
