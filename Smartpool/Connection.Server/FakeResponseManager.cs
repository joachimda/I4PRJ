namespace Smartpool.Connection.Server
{
    public class FakeResponseManager
    {
        public string Respond(string content)
        {
            var receivedStrings = content.Split(',');

            switch (receivedStrings[0])
            {
                case "Login":
                    if (receivedStrings[1] == "Joachim" && receivedStrings[2] == "1234")
                        return "Login";
                    else
                    {
                        return "Login failed";
                    }
                case "GetPoolInfo":
                    return "Temperature in pool is 25 degrees";
                default:
                    return "The server did not recognize your request";
            }
        }
    }
}