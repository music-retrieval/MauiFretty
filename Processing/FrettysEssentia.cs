using System.Net.Sockets;
using System.Text;
using Fretty.Shared;

namespace Fretty.Processing;

// Represents a connection to our FrettysEssentia server
public class FrettysEssentia(string address, int port) : IServer
{
    public FrettysEssentia() : this("127.0.0.1", 27015) {}

    private TcpClient  Client => new(address, port);
    
    public void Dispose()
    {
        Client.Dispose();
    }

    public IAudioAnalysis SendAndAwaitResponse(string filePath)
    {
        string response;
        TcpClient client = Client;
        
        try
        {
            using NetworkStream stream = client.GetStream();
            using (FileStream fileStream = File.OpenRead(filePath))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    stream.Write(buffer, 0, bytesRead);
                }
            }
            
            // Signal the server that the file has been sent
            client.Client.Shutdown(SocketShutdown.Send);
            
            byte[] responseBuffer = new byte[1024];
            int responseBytesRead = stream.Read(responseBuffer, 0, responseBuffer.Length);
            response = Encoding.UTF8.GetString(responseBuffer, 0, responseBytesRead);
        }
        catch (Exception e)
        {
            response = "No chords found: " + e.Message;
        }
        
        return FrettysAnalysis.FromResponse(response);
    }
}