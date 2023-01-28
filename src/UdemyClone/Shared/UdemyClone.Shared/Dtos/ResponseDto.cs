using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace UdemyClone.Shared.Dtos
{
	public class ResponseDto<T>
	{
		public T Data { get; private set; }

		[JsonIgnore]
		public int StatusCode { get; private set; }

		public bool IsSuccessfull { get; private set; }

		public List<String> Errors { get; set; }


		public static ResponseDto<T> Success(T data, int statusCode)
		{
			return new ResponseDto<T> { Data = data, StatusCode = statusCode, IsSuccessfull = true };
		}

		public static ResponseDto<T> Success(int statusCode)
		{
			return new ResponseDto<T> { Data = default(T), StatusCode = statusCode, IsSuccessfull = true };
		}

		public static ResponseDto<T> Fail(List<String> errors, int statusCode)
		{
			return new ResponseDto<T>
			{
				Errors = errors,
				StatusCode = statusCode,
				IsSuccessfull = false
			};
		}

		public static ResponseDto<T> Fail(String error, int statusCode)
		{
			return new ResponseDto<T>
			{
				Errors = new List<string> { error },
				StatusCode = statusCode,
				IsSuccessfull = false
			};
		}
	}
}
