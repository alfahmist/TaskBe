using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBe.Repository;
using TaskBe.Services;
using TaskBe.ViewModels;

namespace TaskBe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly PegawaiRepository pegawaiRepository;
        private readonly IConfiguration configuration;
        public LoginController(PegawaiRepository pegawaiRepository, IConfiguration configuration)
        {
            this.pegawaiRepository = pegawaiRepository;
            this.configuration = configuration;
        }
        /// <summary>
        /// Login with name and password.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "name": "user",
        ///        "password": "user"
        ///     }
        /// </remarks>
        /// <response code="200">Success generate token</response>  
        /// <response code="401">Account has been deleted</response>  
        /// <response code="400">Bad Request</response>     
        /// <response code="403">Forbidden / password is not correct</response>     
        /// <response code="500">Interal Server Error</response>     
        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            try
            {
                var pegawai = pegawaiRepository.GetByName(loginVM.Name);
                if(pegawai != null)
                {
                    if(pegawai.Isdelete == true)
                    {
                        return Unauthorized("Account has been deleted");
                    }
                    else
                    {
                        if (loginVM.Password != pegawai.Password)
                        {
                            return Forbid();
                        }
                        var jwt = new JwtService(configuration);
                        var token = jwt.GenerateToken(loginVM.Name);
                        return Ok(token);
                    }

                }
                return NotFound("Name not found");
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
