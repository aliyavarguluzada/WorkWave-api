﻿
namespace WorkWaveAPP.Application.Core
{
    public class ServiceResult<T>
    {
        public T Response { get; set; }
        public int StatusCode { get; set; }
        public int ErrorCode { get; set; }
        public string Description { get; set; }
        public List<T>? Values { get; set; } 
        public Dictionary<string, string> ErrorList { get; set; }

        public static ServiceResult<T> Ok(T response)
        {
            return new ServiceResult<T>
            {
                Response = response,
                StatusCode = (int)HttpStatusCode.OK,
                Description = "Operation successfull",
                ErrorList = null,
                Values = new List<T> { response }
            };
        }

        public static ServiceResult<T> Error(ErrorCodesEnum errorCode, Dictionary<string, string> errorList = null, int statusCode = (int)HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>
            {
                Response = default,
                StatusCode = statusCode,
                Description = errorCode.GetEnumDescription(),
                ErrorList = errorList
            };
        }


    }
}
