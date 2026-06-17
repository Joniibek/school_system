using System.ComponentModel.DataAnnotations;
using MediatR;
using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.Domain.Enums;
using MyAspNetProject.Models.DTO.Response;

namespace MyAspNetProject.Models.DTO.Request;

public record StudentCreateCommand(Guid KlassId)
    : BaseUserCreateDto, IRequest<StudentCreateResponseDto>;
  

public record StudentUpdateDto : BaseUserUpdateDto {}