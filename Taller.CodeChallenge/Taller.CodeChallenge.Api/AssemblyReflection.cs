using System.Reflection;

namespace Taller.CodeChallenge.Api
{
    public static class AssemblyReflection
    {
        /// <summary>
        /// Get Assemblies
        /// </summary>
        /// <returns></returns>
        public static Assembly[] GetCurrentAssemblies()
        {
            return new Assembly[]
            {
                Assembly.Load("Taller.CodeChallenge.Api"),
                Assembly.Load("Taller.CodeChallenge.Domain"),
                Assembly.Load("Taller.CodeChallenge.Infrastructure")
            };
        }
    }
}
