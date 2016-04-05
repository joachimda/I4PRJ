namespace Smartpool
{
    public abstract class DbAccessFactory
    {
        public IUserAccess CreateUserAccess()
        {
            return new UserAccess();
        }
    }
}