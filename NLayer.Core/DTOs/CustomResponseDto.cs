using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class CustomResponseDto<T>  // generic T tipinde
    {
        public T Data { get; set; }

        [JsonIgnore]   // status kod clientlara görünmicek.zaten postman bu kodu döner.
        public int StatusCode { get; set; }

        public List<String> Errors { get; set; }

        // new ile oluşturmak yerine burda static olarak yazıyorum.
        // aşağıdaki kodlama stili static factory method dp olarak geçer.
        public static CustomResponseDto<T> Success(int statusCode,T data)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Data = data};
        }
        public static CustomResponseDto<T> Success(int statusCode)   // her zaman geriye data dönmeyiz.sadece durum kodu döneriz.
        {
            return new CustomResponseDto<T> { StatusCode = statusCode };
        }
        public static CustomResponseDto<T> Fail(int statusCode , List<string> errors)   // her zaman geriye data dönmeyiz.sadece durum kodu döneriz.
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors  };
        }
        public static CustomResponseDto<T> Fail(int statusCode, string error)   // her zaman geriye data dönmeyiz.sadece durum kodu döneriz.
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
