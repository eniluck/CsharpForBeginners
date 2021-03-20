using System.Net;

namespace CafeForDevs.Server.Handlers
{
    //Обработчик
    public interface IHandler
    {
        public string Path { get; }

        void Handle(HttpListenerContext context);
    }
}
