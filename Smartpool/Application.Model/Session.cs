//========================================================================
// FILENAME :   Session.cs
// DESCR.   :   Session singleton
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Model
{
    public class Session
    {
        private static Session _sharedSession;

        public static Session SharedSession => _sharedSession ?? (_sharedSession = new Session());

        public string UserName { get; set; }
        public string TokenString { get; set; }
        public int SelectedPoolIndex { private get; set; }
        public string SelectedPool => Pools.Length > SelectedPoolIndex ? Pools[SelectedPoolIndex] : "";
        public string[] Pools { get; set; }

        private Session()
        {
            // Private constructer - Use SharedSession to create a static instance

            SelectedPoolIndex = 0;
        }
    }
}