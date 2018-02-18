#define $NamespaceDefine$
#pragma warning disable 0436

#if LOCALNAMESPACE
namespace _RootNamespace_
{
#endif
  partial class ThisAssembly
  {
  /// <summary>Provides access to the current VSIX extension information.</summary>
    public static partial class Vsix
    {
      /// <summary>Identifier: $VsixID$</summary>
      public const string Identifier = "$VsixID$";
          
      /// <summary>Name: $VsixName$</summary>
      public const string Name = "$VsixName$";

      /// <summary>Description: $VsixDescription$</summary>
      public const string Description = "$VsixDescription$";

      /// <summary>Author: $VsixAuthor$</summary>
      public const string Author = "$VsixAuthor$";

      /// <summary>Version: $VsixVersion$</summary>
      public const string Version = "$VsixVersion$";
    }
  }
#if LOCALNAMESPACE
}
#endif
#pragma warning restore 0436
