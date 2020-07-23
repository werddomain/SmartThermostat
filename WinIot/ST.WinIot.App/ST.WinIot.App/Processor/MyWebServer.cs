using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Net;

namespace ST.WinIot.App.Processor
{
    internal class MyWebserver
    {

        public MyWebserver(Func<Request, string> requestResponse, int port = 8081) {
            this.port = port;
            this.requestResponse = requestResponse;
        }
        
        private const uint BufferSize = 8192;
        int port = 8081;
        Func<Request, string> requestResponse;
        public async void Start()
        {
            var listener = new StreamSocketListener();

            await listener.BindServiceNameAsync("8081");

            listener.ConnectionReceived += async (sender, args) =>
            {
                var request = new StringBuilder();

                using (var input = args.Socket.InputStream)
                {
                    var data = new byte[BufferSize];
                    IBuffer buffer = data.AsBuffer();
                    var dataRead = BufferSize;

                    while (dataRead == BufferSize)
                    {
                        await input.ReadAsync(
                             buffer, BufferSize, InputStreamOptions.Partial);
                        request.Append(Encoding.UTF8.GetString(
                                                      data, 0, data.Length));
                        dataRead = buffer.Length;
                    }
                }

                string query = GetQuery(request);

                using (var output = args.Socket.OutputStream)
                {
                    using (var response = output.AsStreamForWrite())
                    {
                        var r = new Request {
                            RequestString = request.ToString(),
                            Uri = GetUri(request)
                        };
                        var html = Encoding.UTF8.GetBytes(requestResponse(r));
                        //var html = Encoding.UTF8.GetBytes(
                        //$"<html><head><title>Background Message</title></head><body>Hello from the background process!<br/>{query}</body></html>");
                        using (var bodyStream = new MemoryStream(html))
                        {
                            
                            var header = $"HTTP/1.1 200 OK\r\nContent-Length: {bodyStream.Length}\r\nConnection: close\r\n\r\n";
                            var headerArray = Encoding.UTF8.GetBytes(header);
                            await response.WriteAsync(headerArray,
                                                      0, headerArray.Length);
                            await bodyStream.CopyToAsync(response);
                            await response.FlushAsync();
                        }
                    }
                }
            };
        }

        private static string GetQuery(StringBuilder request)
        {
            var requestLines = request.ToString().Split(' ');

            var url = requestLines.Length > 1
                              ? requestLines[1] : string.Empty;

            var uri = new Uri("http://localhost" + url);
            var query = uri.Query;
            return query;
        }
        private static Uri GetUri(StringBuilder request)
        {
            var requestLines = request.ToString().Split(' ');

            var url = requestLines.Length > 1
                              ? requestLines[1] : string.Empty;

            return new Uri("http://localhost" + url);
            
        }
        public class Request {
            public string RequestString { get; set; }
            public Uri Uri { get; set; }

        }
        public class Response {

        }
    }
}
