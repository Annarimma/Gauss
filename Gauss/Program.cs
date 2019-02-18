
namespace Gauss
{
    class Program
    {
        static void Main(string[] args)
        {
            Input.Read();
            GaussMethod gaussMethod = new GaussMethod();

            gaussMethod.Gaussian();

            if (Input.IER==0)
            {
                gaussMethod.findDet();
            }
            Output output = new Output();
        }
    }
}
