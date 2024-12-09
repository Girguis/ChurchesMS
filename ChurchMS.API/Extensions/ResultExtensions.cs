using ChurchMS.Application.Common.Dtos.Response;
using ChurchMS.Application.Results;
using Microsoft.AspNetCore.Mvc;

namespace ChurchMS.API.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToActionResult<TResponse>(this Result<TResponse> response)
    {
        if (response.IsSuccess)
            return new ObjectResult(response.Data)
            {
                StatusCode = (int)response.StatusCode
            };

        return response.FailedActionResult();
    }

    public static IActionResult ToActionResult(this Result response)
    {
        if (response.IsSuccess)
            return new ObjectResult(null)
            {
                StatusCode = (int)response.StatusCode
            };

        return response.FailedActionResult();
    }

    public static IActionResult ToActionResult(this Application.Results.FileResult response)
    {
        if (response.IsSuccess)
            return new FileContentResult(response.FileContent, response.ContentType)
            {
                FileDownloadName = response.FileName
            };

        return response.FailedActionResult();
    }

    private static IActionResult FailedActionResult(this Result response)
    {
        return new ObjectResult(response.GetErrorDto())
        {
            StatusCode = (int)response.StatusCode
        };
    }

    private static ErrorDto GetErrorDto(this Result result)
    {
        return new ErrorDto()
        {
            ErrorCode = result.ErrorCode,
            Errors = result.Errors
        };
    }
}