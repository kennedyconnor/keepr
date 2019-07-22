using keepr.Repositories;
using keepr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class KeepsController : ControllerBase
  {
    private readonly KeepRepository _repo;
    public KeepsController(KeepRepository repo)
    {
      _repo = repo;
    }
    //GET api/keeps
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      try
      {
        return Ok(_repo.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // GET api/keeps/5
    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
    {
      try
      {
        return Ok(_repo.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    //GET api/keeps/user
    [Authorize]
    [HttpGet("user")]

    public ActionResult<IEnumerable<Keep>> GetByUser()
    {
      try
      {
        var id = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.GetByUser(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    //POST api/keeps
    [Authorize]
    [HttpPost]
    public ActionResult<Keep> Post([FromBody] Keep data)
    {
      try
      {
        data.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.Create(data));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    //PUT api/keeps/5
    [HttpPut("{id}")]
    public ActionResult<Keep> Put(int id, [FromBody] Keep data)
    {
      try
      {
        data.Id = id;
        return Ok(_repo.Update(data));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_repo.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}