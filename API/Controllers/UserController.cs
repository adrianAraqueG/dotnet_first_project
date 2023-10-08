using System;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Interfaces;

namespace API.Controllers;

public class UserController : ApiBaseController
{
    public readonly IUnitOfWork _unitOfWork;
    public UserController(IUnitOfWork unitOfWork){
        _unitOfWork = unitOfWork;
    }

    [HttpGet("all-users")]
    public async Task<ActionResult> GetAll(){
        var users = await _unitOfWork.Users.GetAllAsync();

        return Ok(users);
    }
}