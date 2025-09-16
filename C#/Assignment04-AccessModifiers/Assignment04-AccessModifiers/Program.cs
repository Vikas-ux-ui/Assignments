
namespace Assignment04_AccessModifiers
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            CheckAccessModifiers checkAccessModifiers = new CheckAccessModifiers();
            Console.WriteLine("Simple access");
            Console.WriteLine(checkAccessModifiers.PublicVariable);//anywhere we can access public variable 
            //Console.WriteLine(checkAccessModifiers.ProtectedInternalVariable);//protected internal variable can be access throughout the assembly

            Console.WriteLine("In order to access private variable we are using public method in CheckAccessModifiers class");
            Console.WriteLine(checkAccessModifiers.AccessPrivate());

            Console.WriteLine("In order to access Protected member we inherit CheckAccessModifiers to SubClassForPRotected");
            SubClassForPRotected subClassForPRotected = new SubClassForPRotected();
            Console.WriteLine(subClassForPRotected.ToAccessProtected());
            Console.WriteLine(subClassForPRotected.ToAccessPrivateProtected());


            Console.ReadLine();
        }
    }
}
