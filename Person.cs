using System;
using System.Reflection.Metadata;
namespace Namespace_ExercicePerson;

public class Person
{
    // Mes Public Properties
    public required string FirstName {get; set;}
    public required string LastName {get; set;}
    public required DateTime BirthDate {get; init;}
}

