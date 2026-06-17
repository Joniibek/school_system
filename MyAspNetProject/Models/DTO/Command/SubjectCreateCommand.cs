using MediatR;
using MyAspNetProject.Models.DTO.Response;

namespace MyAspNetProject.Models.DTO.Request;

public record SubjectCreateCommand(string Name): IRequest<SubjectListDto>;