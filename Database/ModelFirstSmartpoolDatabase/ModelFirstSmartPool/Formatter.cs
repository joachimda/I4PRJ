namespace ModelFirstSmartPool
{
    public class Formatter
    {
        public FullName FormatRealNameInputFromStringArray(string[] nameStrings, FullName name)
        {
            switch (nameStrings.Length)
            {
                case 1:
                    name.FirstName = nameStrings[0];
                    break;
                case 2:
                    name.FirstName = nameStrings[0];
                    name.LastName = nameStrings[1];
                    break;
                case 3:
                    name.FirstName = nameStrings[0];
                    name.MiddleName = nameStrings[1];
                    name.LastName = nameStrings[2];
                    break;
            }
            return name;
        }
    }
}