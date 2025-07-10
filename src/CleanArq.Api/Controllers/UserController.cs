using CleanArq.Application.DataBase.User.Commands.CreateUser;
using CleanArq.Application.DataBase.User.Commands.DeleteUser;
using CleanArq.Application.DataBase.User.Commands.UpdateUser;
using CleanArq.Application.DataBase.User.Queries.GetAllUser;
using CleanArq.Application.DataBase.User.Queries.GetByIdUser;
using CleanArq.Application.DataBase.User.Queries.LoginUser;
using CleanArq.Application.Exceptions;
using CleanArq.Application.External.TokenJwt;
using CleanArq.Application.Features;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArq.Api.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class UserController : ControllerBase
    {
        [HttpGet, Route("GetAllUser")]
        public async Task<IActionResult> GetAllUser([FromServices] IGetAllUserQuery qry)
        {
            var data = await qry.Execute();
            return StatusCode(200, ResponseApiService.Response(200, "Ejecución exitosa", data));
        }

        [HttpGet, Route("GetByIdUser")]
        public async Task<IActionResult> GetByIdUser(int userId, [FromServices] IGetByIdUserQuery qry)
        {
            var data = await qry.Execute(userId);
            return StatusCode(200, ResponseApiService.Response(200, "Ejecución exitosa", data));
        }

        [HttpPost, Route("CreateUser")]
        public async Task<IActionResult> CreateUser(
            [FromBody] CreateUserModel model,
            [FromServices] ICreateUserCommand cmd,
            [FromServices] IValidator<CreateUserModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(400, ResponseApiService.Response(400, "", validate.Errors));

            var data = await cmd.Execute(model);

            return StatusCode(200, ResponseApiService.Response(200, "Usuario creado", null));
        }

        [HttpPut, Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(
            [FromBody] UpdateUserModel model,
            [FromServices] IUpdateUserCommand cmd,
            [FromServices] IValidator<UpdateUserModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(400, ResponseApiService.Response(400, "", validate.Errors));

            var data = await cmd.Execute(model);

            if (!data)
                return StatusCode(200, ResponseApiService.Response(200, "Usuario incorrecto", null));

            return StatusCode(200, ResponseApiService.Response(200, "Usuario actualizado", null));
        }

        [HttpDelete, Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(
            int userId,
            [FromServices] IDeleteUserCommand cmd)
        {
            var data = await cmd.Execute(userId);

            if (!data)
                return StatusCode(200, ResponseApiService.Response(200, "Usuario incorrecto", null));

            return StatusCode(200, ResponseApiService.Response(200, "Usuario eliminado", null));
        }

        [AllowAnonymous]
        [HttpGet, Route("LoginUser")]
        public async Task<IActionResult> LoginUser(
            [FromBody] LoginUserModel model,
            [FromServices] ILoginUserQuery cmd,
            [FromServices] IValidator<LoginUserModel> validator,
            [FromServices] ITokenJwtService tokenJwt)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(400, ResponseApiService.Response(400, "", validate.Errors));

            var data = await cmd.Execute(model.UserName, model.Password);

            if (data == null)
                return StatusCode(200, ResponseApiService.Response(200, "Usuario o contraseña incorrectos", new List<string>()));

            string token = tokenJwt.Execute(model.UserName);

            return StatusCode(200, ResponseApiService.Response(200, "Ejecución exitosa", token));
        }

    }
}
