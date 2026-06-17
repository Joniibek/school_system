using AutoMapper.Internal;
using MediatR;
using MyAspNetProject.Exceptions;
using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Request;
using MyAspNetProject.Models.DTO.Response;
using MyAspNetProject.Models.Query;
using MyAspNetProject.Repositories;
using MyAspNetProject.Utilities;

namespace MyAspNetProject.Handlers;


// Command Handlers
public class TeacherCreateHandler(
    ITeacherRepository repository,
    ISubjectRepository subjectRepository
    ): IRequestHandler<TeacherCreateCommand, TeacherShortListDto>
{
    
    private readonly ITeacherRepository _repository = repository;
    
    public async Task<TeacherShortListDto> Handle(
        TeacherCreateCommand request, CancellationToken cancellationToken)
    {
        TeacherEntity teacherEntity = request.ToEntity();
        var teacher = await _repository.Create(teacherEntity);
        return teacher.ToShortListDto();
    }
}


public class TeacherSubjectSetHandler(
    ITeacherRepository repository,
    ISubjectRepository subjectRepository
    ) : IRequestHandler<TeacherSubjectsSetCommand>
{
    private readonly ITeacherRepository _repository = repository;
    private readonly ISubjectRepository _subjectRepository = subjectRepository;

    public async Task Handle(TeacherSubjectsSetCommand request, CancellationToken cancellationToken)
    {
        List<SubjectEntity> subjectEntities = await _subjectRepository
            .GetMany(request.SubjectIds);
        
        await _repository.SetSubjects(request.TeacherId, subjectEntities);
    }
}


// Query Handlers
public class TeacherListQueryHandler(ITeacherRepository repository)
    : IRequestHandler<TeacherListQuery, List<TeacherListDto>>
{
    private ITeacherRepository _repository = repository;
    
    public async Task<List<TeacherListDto>> Handle(TeacherListQuery query, CancellationToken cancellationToken)
    {
        List<TeacherListDto> teacherListDtos = new();
        List<TeacherEntity> entities = await _repository.List(query);
        
        foreach (var entity in entities)
        {
            teacherListDtos.Add(entity.ToDto());
        }

        return teacherListDtos;
    }
}