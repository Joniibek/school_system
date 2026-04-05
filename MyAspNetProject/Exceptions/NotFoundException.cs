namespace MyAspNetProject.Exceptions;

public class NotFoundException(string entity, int id) 
    : Exception($"Object of {entity} with id - {id} was not found");