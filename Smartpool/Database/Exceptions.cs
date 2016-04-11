using System;

namespace Smartpool.UserAccess
{
    public class UserNotFoundException : Exception
    {
    }

    public class MultipleOccourencesOfEmailWasFoundException : Exception
    {
    }

    public class PoolNotFoundException : Exception
    { 
    }
}