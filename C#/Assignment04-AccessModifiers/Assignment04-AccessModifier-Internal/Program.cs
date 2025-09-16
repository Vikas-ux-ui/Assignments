using Assignment04_AccessModifier_Internal;
namespace Assignment04_AccessModifier_Internal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SubClassForProtectedInternal subClassForProtectedInternal = new SubClassForProtectedInternal();


            Console.WriteLine(subClassForProtectedInternal.AccessProtectedInternal());
        }
    }
}
