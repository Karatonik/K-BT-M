using System.ServiceModel;

namespace AnyApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var proxy = new ChannelFactory<ITerytWs1>("custom");
            proxy.Credentials.UserName.UserName = "Arventill";
            proxy.Credentials.UserName.Password = "MvM2E19N0";
            var result = proxy.CreateChannel();
            var test = result.CzyZalogowany();
        }
    }
}