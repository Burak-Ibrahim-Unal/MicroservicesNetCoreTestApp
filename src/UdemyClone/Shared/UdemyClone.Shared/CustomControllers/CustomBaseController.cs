using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyClone.Shared.Dtos;

namespace UdemyClone.Shared.CustomControllers
{
	public class CustomBaseController : ControllerBase
	{
		public IActionResult CreateActionResultInstance<T>(Response<T> response)
		{
			return new ObjectResult(response)
			{
				StatusCode = response.StatusCode,
			};
		}
	}
}
