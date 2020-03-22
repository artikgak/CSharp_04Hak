using System.Windows.Controls;

namespace KMACSharp04Hak.Tools.Navigation
{
    internal interface IContentOwner
    {
        INavigatable Content { get; set; }
    }
}
