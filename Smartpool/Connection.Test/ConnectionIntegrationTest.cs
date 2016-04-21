using System;
using System.Net;
using System.Net.Sockets;
using NUnit.Framework;
using Smartpool.Connection.Client;
using Smartpool.Connection.Model;

namespace Connection.Test
{
    [TestFixture]
    public class ConnectionIntegrationTest
    {
        private IClientMessager _clientMessager;
        private IClient _client;
        private IpFinder _ipFinder;
        
        [SetUp]
        public void Setup()
        {
            _ipFinder = new IpFinder();
            _client = new SynchronousSocketClient(_ipFinder.GetLocalIPAddress());
            _clientMessager = new ClientMessager(_client);
        }

        // *** Server must be running on same pc with VPN active ***
        [Test]
        public void SendMessage_CorrectLoginMessage_ReturnsLoginSuccessfulIsTrue() 
        {
            var response = (LoginResponseMsg)_clientMessager.SendMessage(new LoginRequestMsg("test", "test"));
            
            Assert.That(response.LoginSuccessful, Is.True);
        }

    }

    public class IpFinder
    {
        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
    }
}
