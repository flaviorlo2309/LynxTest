using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BaseResponse<T> where T : class
    {
        public BaseResponse() { }

        public BaseResponse(HttpStatusCode statusCode, string message, T data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public BaseResponse(T data, HttpStatusCode statusCode)
        {
            Data = data;
            StatusCode = statusCode;
        }

        public BaseResponse(string message, T data, HttpStatusCode statusCode, bool success)
        {
            Message = message;
            Data = data;
            StatusCode = statusCode;
            Success = success;
        }

        public BaseResponse(string message, HttpStatusCode statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

        // ATRIBUTOS
        [JsonProperty("statusCode")]
        public HttpStatusCode StatusCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; } = true;

        [JsonProperty("data")]
        public T Data { get; set; }

        // VALIDAÇÕES
        public static BaseResponse<T> CriarRetornoTokenInvalido(T data = null)
        {
            return new BaseResponse<T>("Token inválido", HttpStatusCode.Unauthorized) { Data = data };
        }

        public static BaseResponse<T> CriarRetornoXApiKeyInvalido()
        {
            return new BaseResponse<T>("x-api-key inválido", HttpStatusCode.Unauthorized);
        }

        public static BaseResponse<T> CriarRetornoBadRequest(string message)
        {
            if (string.IsNullOrEmpty(message)) throw new ArgumentNullException($"{nameof(message)} não pode ser nulo ou vazio");
            return new BaseResponse<T>(message, HttpStatusCode.BadRequest);
        }
    }
}
