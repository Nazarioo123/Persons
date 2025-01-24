using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using System.IO;
using System.Text.Json;
using System;



    class Program
    {
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
        }

    static void Main()
    {
        string folderPath = @"C:\HomeTask3";
        string filePath = Path.Combine(folderPath, "Person.json");

        if (Directory.Exists(folderPath)) 
        {
            Directory.CreateDirectory(folderPath);
            
        }
        Person[] persons = new Person[3];

        {
            persons[0] = new Person { FirstName = "Микола", LastName = "Миколенко", DateOfBirth = new DateTime(1822, 02, 10) };
            persons[1] = new Person { FirstName = "Матвій", LastName = "Мартинюк", DateOfBirth = new DateTime(2006, 12, 14) };
            persons[2] = new Person { FirstName = " Назарій", LastName = "Ліщинський", DateOfBirth = new DateTime(2006, 04, 17) };
            };
                         
                
                    string jsonString = JsonSerializer.Serialize(persons, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(filePath, jsonString);
                    Console.WriteLine("данні записано");
        

               
                    string fileContent = File.ReadAllText(filePath);
                    Person[] deserializedPersons = JsonSerializer.Deserialize<Person[]>(fileContent);

                    Console.WriteLine("Дані з файлу");
                    foreach (var person in deserializedPersons)
                    {
                        Console.WriteLine($"Імя : {person.FirstName}, Прізвище: {person.LastName}, Дата {person.DateOfBirth}  ");
                    }
           }    
    }

          
        
    
