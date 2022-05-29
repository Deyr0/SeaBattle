using System;
using System.Net.Sockets;
using System.Text;
using System.IO;
    
namespace ChatServer
{
    class ClientObject
    {
        protected internal string Id { get; private set; }
        protected internal NetworkStream Stream { get; private set; }
        string userName;
        TcpClient client;
        ServerObject server; // объект сервера
       protected internal bool first;
        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
                         first= true;
            serverObject.AddConnection(this);

        }

        public void Process()
        {
            try
            {
                Stream = client.GetStream();
                // получаем имя пользователя
                string message = GetMessage();
                userName = message;
                
                message = userName + " вошел в чат";
                // посылаем сообщение о входе в чат всем подключенным пользователям
                //server.BroadcastMessage(message, this.Id);
                Console.WriteLine(message);
                
                // в бесконечном цикле получаем сообщения от клиента
                while (true)
                {
                    try
                    {
                        byte[] mess = Getmessage();
                        if (mess.Length != 0)
                        {
                            Console.WriteLine("new message from {0}", userName);
                            string m = Encoding.Unicode.GetString(mess, 0, mess.Length);
                            Console.WriteLine(m);
                            server.BroadcastMessage(mess, this.Id);
                        }
                        
                    }
                    catch
                    {
                        message = String.Format("{0}: покинул чат", userName);
                        Console.WriteLine(message);
                        //server.BroadcastMessage(message, this.Id);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // в случае выхода из цикла закрываем ресурсы
                server.RemoveConnection(this.Id);
                Close();
            }
        }

        // чтение входящего сообщения и преобразование в строку
        private string GetMessage()
        {
            byte[] data = new byte[64]; // буфер для получаемых данных
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (Stream.DataAvailable) ;

            return builder.ToString();
        }

        private byte[] Getmessage()
        {
            byte[] data = new byte[64]; // буфер для получаемых данных
            MemoryStream stream = new MemoryStream();
            do
            {
                Stream.Read(data, 0, data.Length);
                stream.Append(data);

            }
            while (Stream.DataAvailable);
            byte[] bytes = stream.ToArray();
            
            return bytes;
        }

        // закрытие подключения
        protected internal void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
        }
    }
    public static class MemoryStreamExtensions
    {
        public static void Append(this MemoryStream stream, byte value)
        {
            stream.Append(new[] { value });
        }

        public static void Append(this MemoryStream stream, byte[] values)
        {
            stream.Write(values, 0, values.Length);
        }
    }
}
