using System;

namespace Gauss
{
    class GaussMethod
    {
        double[] x;
        double[] u_vector = new double[Input.n];
        double[] exact = new double[Input.n];
        double[] p;

        public void Gaussian()
        {
            int i, k, j = 0;
            double[,] l = new double[Input.n, Input.n];
            x = new double[Input.n];


            for (k = 0; k < Input.n - 1; k++)
            {
                if (Input.matrix[k,k]==0)
                {
                    int IER = 1;
                    Input.IER = IER;
                    return;
                }

                for (i=k+1; i<Input.n; i++)
                {
                    l[i, k] = Input.matrix[i, k] / Input.matrix[k,k];
                }

                for (i=k+1; i<Input.n; i++)
                {
                    for (j=k+1; j< Input.n; j++)
                    {
                        Input.matrix[i, j] = Input.matrix[i, j] - l[i, k] * Input.matrix[k, j];
                    }
                    Input.f[i] = Input.f[i] - l[i, k] * Input.f[k];
                    Input.matrix[i, k] = 0;
                }

            }

            x[Input.n - 1] = Input.f[Input.n - 1] / Input.matrix[Input.n - 1, Input.n - 1];

            double result;
            for (i= Input.n-2; i>=0; i--)
            {
                result = 0.0;
                for (j = i + 1; j<Input.n; j++) {
                    result = result + Input.matrix[i, j] * x[j];
                }
                x[i] = (Input.f[i] - result) / Input.matrix[i, i];
                Input.x = x;
            }

            GaussDiscrepancy();
            error();
        }

        public void GaussDiscrepancy()
        {
            for (int i = 0; i < Input.n; ++i)
            {
                double actual_b_i = 0.0;
                for (int j = 0; j < Input.n; ++j)
                    actual_b_i += Input.matrix[i, j] * x[j];
                u_vector[i] = Input.f[i] - actual_b_i;
            }
            Input.u = u_vector;
        }

        public void findDet()
        {
            double det = 1;
            for (int i = 0; i < Input.n; i++)
            {
                for (int j = 0; j < Input.n; j++)
                {
                    if (i == j)
                    {
                        det *= Input.matrix[i, j];
                    }
                }
            }
            Input.det = det;
        }

        //функция для проверки погрешности для конкретного теста
        public void error()
        {
            p = new double[Input.n];

            exact[0] = 4;
            exact[1] = 0;
            exact[2] = -1;

            for (int i = 0; i < p.Length; i++)
            {
                p[i] = Math.Abs(exact[i] - x[i]);
                Input.p = p;
            }

        }
    }
}
