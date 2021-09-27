using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
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
    public class PegawaiController : ControllerBase
    {
        private readonly PegawaiRepository repository;

        public PegawaiController(PegawaiRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get all data pegawai.
        /// </summary>
        /// <response code="200">Success</response>  
        /// <response code="400">Bad Request</response>     
        /// <response code="401">Unauthorize / Login Required</response>
        [HttpGet]
        public ActionResult GetAll([FromQuery] PaginationVM pagination)
        {

            try
            {
                var validFilter = new PaginationVM(pagination.PageNumber, pagination.PageSize);
                var getAll = repository.GetAll()
                    .Where(p => p.Isdelete == false)
                    .Select(p => new GetPegawaiVM()
                    { 
                        Id = p.Id,
                        Name = p.Name,
                        Unit = new GetUnitVM
                        {
                            Id = p.Unit.Id,
                            Name = p.Unit.Name,
                            Code = p.Unit.Code,
                            Created_at = p.Unit.Created_at,
                            Created_by = p.Unit.Created_by,
                            Isactive = p.Unit.Isactive
                        }, 
                        Created_at = p.Created_at,
                        Created_by = p.Created_by,
                        Isactive = p.Isactive,
                    })
                    .ToList().OrderByDescending(p => p.Id)
                    .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                    .Take(validFilter.PageSize);

                var totalRecords = getAll.Count();
                var response = new ResponseVM
                {
                    Success = true,
                    Message = "Success",
                    Total_data = totalRecords,
                    Data = getAll
                };

                return Ok(response);

            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        /// <summary>
        /// Get specific data pegawai by id.
        /// </summary>
        /// <response code="200">Success</response>  
        /// <response code="404">No data found</response>   
        /// <response code="401">Unauthorize / Login Required</response>    
        [ProducesResponseType(typeof(Pegawai), StatusCodes.Status200OK)]
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
        /// Insert new data pegawai.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "name": "user",
        ///        "unit_id": 1,
        ///        "password": "password",
        ///        "isactive": true,
        ///        "created_by": "string"
        ///     }
        /// </remarks>
        /// <response code="201">Created new data</response>  
        /// <response code="400">Bad Request</response>   

        [HttpPost]
        public ActionResult Post(Pegawai entity)
        {
            try
            {
                if(entity.Unit_id == null || entity.Unit_id == 0)
                {
                    return BadRequest("unit_id cannot be null");
                }
                else
                {
                    entity.Created_at = DateTime.Now;
                    var result = repository.Post(entity) > 0 ? (ActionResult)Ok("Data has been successfully inserted.") : BadRequest("Data can't be inserted");
                    return result;
                }
          
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }


        /// <summary>
        /// Delete data pegawai by id.
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
        /// Change data pegawai by Id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "id": 0,
        ///        "name": "user",
        ///        "unit_id": 1,
        ///        "created_by": "user1",
        ///        "isactive": true,
        ///        "update_by": "string",
        ///        "isdelete": false,
        ///        "password": "string"
        ///     }
        /// </remarks>
        /// <response code="204">Update Successfuly</response>  
        /// <response code="404">Id not found to be Updated</response>
        /// <response code="401">Login Required</response>
        [HttpPut]
        public ActionResult Put(Pegawai entity)
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