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
        var user = _userService.Find(u => u.isActive == true);            
        return user != null ? Ok(_mapper.Map<IEnumerable<UserGetDTO>>(user))
                            : NotFound("The list of user has not been found");               
    }

    [HttpGet]
    [Route("get/users/{id}")]
    public async Task<IActionResult> GetById(int id)
    {        
        var user = await _userService.GetById(id);
        return user != null ? Ok(_mapper.Map<UserGetStateDTO>(user)) 
                            : NotFound("User doesn't exists");          
    }

    [HttpPost]       
    [Route("create/user")]
    public async Task<IActionResult> Create([FromBody] UserCreateDTO dto)
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
    [Route("update/user")]
    public async Task<IActionResult> Edit([FromBody] UserUpdateDTO dto)
    {          
        var user = await _userService.GetById(dto.Id);
        if(user == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new
            {
                Status = "Error",
                Message = "User deoesn't exists."
            });    
        }

        var validate = _userService.Find(u => u.ID == dto.Id);
        if (validate == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new
            {
                Status = "Error",
                Message = "Id number not found!"
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

        return Ok(new 
        {
            Status = "Success",
            Message = "User deleted successfully!"
        }); 
    }
}
