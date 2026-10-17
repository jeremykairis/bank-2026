
class Person
{
    public string? FirstName;
    public string? LastName;
    public DateTime BirthDate;

    //Note: La methode en dessous est un "constructeur". Ca permet de "forcer" l'instanciassion quand on fait new()
    public Person(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }
}
