using System;
using Unity;

namespace OopDesigner.Registry
{
    /// <summary>
    /// Definition of the class that is used to parse all assemblies in the current app domain to find a class implementing the specific IUiKitRegistration assembly to
    /// be embedded within this designer.
    /// Caution : we use Unity to perform this registration.
    /// </summary>
    /// <remarks>The assemblies beginning by System are ignored.</remarks>
    public static class UiKitRegistrator
    {
        public static void Configure(IUnityContainer unityContainer)
        {

        }
    }
}
