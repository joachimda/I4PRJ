namespace Smartpool
{
    public interface IPoolAccess
    {
        IUserAccess UserAccess { get; set; }
        bool AddPool(string email, string name, double volume);
        bool IsPoolNameAvailable(string email, string name);
        Pool FindSpecificPool(string email, string name);
        bool RemovePool(string email, string name);
        void DeleteAllPools();
        bool EditPoolName(string ownerEmail, string currentName, string newName);
        bool EditPoolVolume(string ownerEmail, string name, int newVolume);
        bool EditPoolUser(string currectOwnerEmail, string name, string newUserEmail);
    }
}