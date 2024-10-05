using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services
{
    public class ResponseService : IResponseService
    {

        ActionResult<BaseResponse<T>> IResponseService.NoContent<T>()
        {
            return new OkObjectResult(new BaseResponse<T>
            {
                Success = true,
                Message = "Success, but no content",
                Status = 204,
            });
        }

        ActionResult<BaseResponse<T>> IResponseService.Ok<T>(T data)
        {
            return new OkObjectResult(new BaseResponse<T>
            {
                Success = true,
                Message = "Succes",
                Status = 200,
                Data = data
            });
        }
    }
}
