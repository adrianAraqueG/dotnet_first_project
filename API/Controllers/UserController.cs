using System;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<BasicUserDto>>> GetUsersBasic(){
        var users = await _unitOfWork.Users.GetAllAsync();
        
        return _mapper.Map<List<BasicUserDto>>(users);
    }

    [HttpGet("list/all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersAll(){
        var users = await _unitOfWork.Users.GetAllUsers();
        
        return _mapper.Map<List<UserDto>>(users);
    }
}