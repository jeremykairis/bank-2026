
class Person
{   
    //Seule la classe peut modifier la donnée grâce au "private set".
    public string? FirstName{ get; private set; }
    public string? LastName{ get; private set; }
    public DateTime BirthDate{ get; private set; }

    //Note: La methode en dessous est un "constructeur". 
    //Ca permet de "forcer" l'instanciation quand on fait new()
    public Person(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }
}
