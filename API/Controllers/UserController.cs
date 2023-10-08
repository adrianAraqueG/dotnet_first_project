using System;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using Domain.Interfaces;
using AutoMapper;

namespace API.Controllers;

public class UserController : ApiBaseController
{
    public readonly IUnitOfWork _unitOfWork;
    public readonly IMapper _mapper;
    public UserController(IUnitOfWork unitOfWork, IMapper mapper){
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet("list/basic")]
    public async Task<ActionResult> GetUsersBasic(){
        var users = await _unitOfWork.Users.GetAllAsync();

        var usersMapped = _mapper.Map<IEnumerable<BasicUserDto>>(users);
        
        return Ok(usersMapped);
    }

    [HttpGet("list/all")]
    public async Task<ActionResult> GetUsersAll(){
        var users = await _unitOfWork.Users.GetAllUsers();

        var usersMapped = _mapper.Map<IEnumerable<UserDto>>(users);
        
        return Ok(usersMapped);
    }
}