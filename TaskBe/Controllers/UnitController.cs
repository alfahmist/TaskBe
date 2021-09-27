using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBe.Models;
using TaskBe.Repository;
using TaskBe.ViewModels;

namespace TaskBe.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly UnitRepository repository;

        public UnitController(UnitRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get all data unit.
        /// </summary>
        /// <response code="200">Success</response>  
        /// <response code="400">Bad Request</response> 
        /// <response code="401">Unauthorize / Login Required</response>     
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var get = repository.GetAll();
                return Ok(get);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }

        }

        /// <summary>
        /// Get specific data unit by id.
        /// </summary>
        /// <response code="200">Success</response>  
        /// <response code="404">No data found</response>   
        /// <response code="401">Unauthorize / Login Required</response>    
        [ProducesResponseType(typeof(Unit), 200)]
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                if (id != null)
                {
                    var getById = repository.GetById(id);
                    if (getById == null)
                    {
                        return NotFound("No Data Found");
                    }
                    return Ok(getById);
                }
                return BadRequest("Id is required");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }


        /// <summary>
        /// Insert new data unit.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "name": "unit",
        ///        "code": "u1",
        ///        "created_by" : "user",
        ///        "isactive": true,
        ///        "isdelete" : false
        ///     }
        /// </remarks>
        /// 
        /// <response code="201">Created new data</response>  
        /// <response code="400">Bad Request</response>   
        /// <response code="401">Login Required</response> 
        /// <response code="401">Unauthorize / Login Required</response>    

        [HttpPost]
        public ActionResult Post(Unit entity)
        {
            try
            {
                entity.Created_at = DateTime.Now;
                var result = repository.Post(entity) > 0 ? (ActionResult)Ok("Data has been successfully inserted.") : BadRequest("Data can't be inserted");
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        /// <summary>
        /// Delete data by id unit.
        /// </summary>
        /// <response code="200">Delete Success</response>  
        /// <response code="404">Data not found to be deleted</response>   
        /// <response code="400">Bad request</response>   
        /// <response code="401">Login Required</response>

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = repository.Delete(id) > 0 ? (ActionResult)Ok("Data has been successfully deleted.") : NotFound("No Data Found to be deleted");
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }

        }

        /// <summary>
        /// Change data by Id unit.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "id" : 1,
        ///        "name": "unit",
        ///        "code": "u1",
        ///        "created_by" : user,
        ///        "isactive": true,
        ///        "update_by": "user",
        ///        "isdelete" : false
        ///     }
        /// </remarks>
        /// <response code="204">Update Successfuly</response>  
        /// <response code="404">Id not found to be Updated</response>
        /// <response code="401">Login Required</response>

        [HttpPut]
        public ActionResult Put(Unit entity)
        {
            try
            {
                entity.Update_at = DateTime.Now;
                var result = repository.Put(entity) > 0 ? (ActionResult)NoContent() : NotFound("Data can't be updated.");
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
    }
}