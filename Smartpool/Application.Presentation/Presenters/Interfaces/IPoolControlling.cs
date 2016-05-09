//========================================================================
// FILENAME :   IPoolControlling.cs
// DESCR.   :   Interface for presenters of views that show pool data
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public interface IPoolControlling
    {
        /// <summary>
        /// Called by the controller when the user has selected a pool
        /// </summary>
        void DidSelectPool(string name);
    }
}
