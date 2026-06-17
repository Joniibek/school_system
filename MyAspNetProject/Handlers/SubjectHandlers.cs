using MediatR;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Models.Query;
using MyAspNetProject.Repositories;
using MyAspNetProject.Utilities;

namespace MyAspNetProject.Handlers;


// Command Handlers
public class SubjectCreateHandler(ISubjectRepository repository): IRequestHandler<SubjectCreateCommand, SubjectListDto>
{
    private readonly ISubjectRepository _repository = repository;

    public async Task<SubjectListDto> Handle(SubjectCreateCommand request, CancellationToken cancellationToken)
    {
        var subject = await _repository.Create(request.ToEntity());
        return subject.ToListDto();
    }
}


// Query Handlers
public class SubjectListQueryHandler(ISubjectRepository repository): IRequestHandler<SubjectListQuery, List<SubjectListDto>>
{
    private readonly ISubjectRepository _repository = repository;
    public async Task<List<SubjectListDto>> Handle(SubjectListQuery query, CancellationToken cancellationToken)
    {
        var subjects = await _repository.List(query);
        List<SubjectListDto> subjectListDtos = new();

        foreach (var subject in subjects)
        {
            subjectListDtos.Add(subject.ToListDto());
        }

        return subjectListDtos;
    }
} 