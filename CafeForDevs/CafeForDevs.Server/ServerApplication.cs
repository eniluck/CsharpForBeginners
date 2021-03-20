using System;
using System.IO;
using System.Net;

namespace CafeForDevs.Server
{
    internal partial class ServerApplication
    {
        private HttpListener _httpListener;
        private readonly Router _router;

        public ServerApplication(HttpListener httpListener, Router router)
        {
            _httpListener = httpListener;
            _router = router;
        }

        internal void Start()
        {
            Console.WriteLine("ServerApplication started");
            _httpListener.Start();

            try
            {
                while (true)
                {
                    var context = _httpListener.GetContext();
                    var path = context.Request.Url.PathAndQuery;
                    var handler = _router.Get(path);
                    handler.Handle(context);

                    switch (path)
                    {
                        case "menu":
                            
                            break;
                        case "order":
                            
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("serverLogs.log",ex.ToString());
            }
            finally
            {
                _httpListener.Stop();
            }
        }
    }
}
