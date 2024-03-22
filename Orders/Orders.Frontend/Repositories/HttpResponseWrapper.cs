using System.Net;

namespace Orders.Frontend.Repositories
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public T? Response { get; private set; }
        public bool Error { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; }
        public T? ActionResponse { get; set; }

        public HttpResponseMessage HttpActionResponseMessage { get; set; }

        public async Task<string?> GetErrorMessageAsync()
        {
            if (!Error)
            {
                return null;
            }

            var statusCode = HttpActionResponseMessage.StatusCode;
            if (statusCode == HttpStatusCode.NotFound)
            {
                return "Recurso no encontrado";
            }
            if (statusCode == HttpStatusCode.BadRequest)
            {
                return await HttpActionResponseMessage.Content.ReadAsStringAsync();
            }
            if (statusCode == HttpStatusCode.Unauthorized)
            {
                return "Tienes que logearte para hacer esta operación";
            }
            if (statusCode == HttpStatusCode.Forbidden)
            {
                return "No tienes permisos para hacer esta operación";
            }

            return "Ha ocurrido un error inesperado";


        }
    }
}