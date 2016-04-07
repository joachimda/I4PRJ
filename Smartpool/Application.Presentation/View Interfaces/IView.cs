//========================================================================
// FILENAME :   IView.cs
// DESCR.   :   Interface for views
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public interface IView
    {
        IViewController Controller { get; set; }
		void Load();
		void Unload();
    }
}