using System.ComponentModel.DataAnnotations;
using MediatR;
using MyAspNetProject.Models.DTO.Response;

namespace MyAspNetProject.Models.DTO.Request;

public record KlassCreateCommand(int Year, string Group) : IRequest<KlassCreateResponseDto>;
