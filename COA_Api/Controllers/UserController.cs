using AutoMapper;
using COA_Api.Core.Models.DTOs;
using COA_Api.Core.Services.Interfaces;
using COA_Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace COA_Api.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public UserController(IUserService userService, IMapper mapper)
    {
        this._userService = userService;
        this._mapper = mapper;
    }

    [HttpGet]
    [Route("get/users")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var user = _userService.Find(u => u.isActive == true);            
            return user != null ? Ok(_mapper.Map<IEnumerable<UserGetDTO>>(user))
                                : NotFound("The list of user has not been found"); 
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpGet]
    [Route("get/users/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var user = await _userService.GetById(id);
            return user != null ? Ok(_mapper.Map<UserGetStateDTO>(user)) 
                                : NotFound("User doesn't exists");  
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]       
    [Route("create/user")]
    public async Task<IActionResult> Create([FromForm] UserCreateDTO dto)
    {          
        try
        {                                  
            // request          
            await _userService.Insert(_mapper.Map<User>(dto));                
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }                       
        return Ok(new 
        {
            Status = "Success",
            Message = "User creation successfully!"
        });                
    }

    [HttpPut]       
    [Route("update/user/{id}")]
    public async Task<IActionResult> Edit(int id, [FromForm] UserUpdateDTO dto)
    {          
        if (id != dto.Id)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new
            {
                Status = "Error",
                Message = "Id number not found!"
            });
        }  
        try
        {     
            var user = await _userService.GetById(id);
            if(user == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    Status = "Error",
                    Message = "User deoesn't exists."
                });    
            }

            // Mapping and request
            _mapper.Map(dto,user);               
            var updated = await _userService.Update(user);
            if(updated == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    Status = "Error",
                    Message = "Error updating data"
                });    
            }                             
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }                       
        return Ok(new 
        {
            Status = "Success",
            Message = "User updated successfully!"
        });                
    }

    [HttpDelete]       
    [Route("delete/user/{id}")]
    public async Task<IActionResult> SoftDelete(int? id)
    {
        try
        {
            var user = await _userService.GetById(id.Value);
            if(user == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    Status = "Error",
                    Message = "User not found or doesn't exist."
                });   
            }

            // request  
            await _userService.SoftDelete(user, id);
            await _userService.Update(user);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return Ok(new 
        {
            Status = "Success",
            Message = "User deleted successfully!"
        }); 
    }
}
