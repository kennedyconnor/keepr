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

  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepRepository _repo;
    public VaultKeepsController(VaultKeepRepository repo)
    {
      _repo = repo;
    }
    //GET api/vaultkeeps
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Keep>> Get(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.GetAll(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    //POST api/vaultkeepss
    [Authorize]
    [HttpPost]
    public ActionResult<VaultKeep> Post([FromBody] VaultKeep data)
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

    //PUT api/vaultkeepss/5
    [HttpPut]
    public ActionResult<string> Put([FromBody] VaultKeep data)
    {
      try
      {
        data.UserId = HttpContext.User.FindFirstValue("Id");
        return _repo.Update(data);
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}