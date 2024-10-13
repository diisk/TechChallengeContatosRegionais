using Application.DTOs;
using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace Application.Interfaces
{
    public interface IResponseService
    {
        public ActionResult<BaseResponse<T>> Ok<T>(T data);
        public ActionResult<BaseResponse<T>> NoContent<T>();
    }
}
