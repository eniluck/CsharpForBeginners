using CafeForDevs.Models;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace CafeForDevs.Server
{
    internal class ServerApplication
    {
        private HttpListener _httpListener;

        public ServerApplication(HttpListener httpListener)
        {
            _httpListener = httpListener;
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

                    switch (path)
                    {
                        case "menu":
                            switch (context.Request.HttpMethod)
                            {
                                case "GET":
                                    var menu = GetMenu();
                                    var stream = context.Response.OutputStream;

                                    // TODO: преобразовать меню к строчному виду.

                                    context.Response.StatusCode = (int)HttpStatusCode.OK;

                                    var outputBytes = Encoding.UTF8.GetBytes("");
                                    stream.Write(outputBytes, 0, outputBytes.Length);
                                    break;
                            }
                            break;
                        case "order":
                            switch (context.Request.HttpMethod)
                            {
                                case "POST":
                                    var inputStream = context.Request.InputStream;
                                    var inputBytes = new byte[context.Request.ContentLength64];
                                    inputStream.Read(inputBytes,0,(int)context.Request.ContentLength64);

                                    // TODO: Преобразовать строку запроса к модели. создать модель.

                                    SelectMenuItem(1, 1);

                                    context.Response.StatusCode = (int)HttpStatusCode.OK;

                                    break;
                                case "GET":
                                    var order = GetOrder();
                                    var outputStream = context.Response.OutputStream;

                                    // TODO: преобразовать меню к строчному виду.

                                    context.Response.StatusCode = (int)HttpStatusCode.OK;

                                    var outputBytes = Encoding.UTF8.GetBytes("");
                                    outputStream.Write(outputBytes, 0, outputBytes.Length);

                                    break;
                            }
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

        internal Menu GetMenu()
        {
            // получить меню

            // сформировать результат

            // отправить клиенту
        }

        internal void SelectMenuItem(int menuItemId, int quantity)
        {
            // получить блюдо из меню по menuItemId

            // формируем новую позицию в заказе
        }

        //TODO: Не один пункт меню а несколько

        internal Order GetOrder()
        {
            // получить заказ

            // сформировать результат

            // отправить клиенту
        }
    }
}
