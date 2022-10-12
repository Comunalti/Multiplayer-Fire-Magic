using IngameDebugConsole;
using Unity.Netcode;

namespace Core.Testing
{
    public static class ConsoleNetworkHandler
    {
        [ConsoleMethod("StartServer", "Start server")]
        public static void StartServer()
        {
            NetworkManager.Singleton.StartServer();
        }
        
        
        [ConsoleMethod("StartClient", "Start Client")]
        public static void ClientServer()
        {
            NetworkManager.Singleton.StartClient();
        }
        
        
        [ConsoleMethod("StartHost", "Start Host")]
        public static void HostServer()
        {
            NetworkManager.Singleton.StartHost();
        }
    }
}