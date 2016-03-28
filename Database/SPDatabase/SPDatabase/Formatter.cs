namespace SPDatabase
{
    public class Formatter
    {
        public RealName FormatRealNameInputFromStringArray(string[] nameStrings, RealName name)
        {
            switch (nameStrings.Length)
            {
                case 1:
                    name.FirstName = nameStrings[0];
                    break;
                case 2:
                    name.FirstName = nameStrings[0];
                    name.SurName = nameStrings[1];
                    break;
                case 3:
                    name.FirstName = nameStrings[0];
                    name.MiddleName = nameStrings[1];
                    name.SurName = nameStrings[2];
                    break;
            }
            return name;
        }
    }
}