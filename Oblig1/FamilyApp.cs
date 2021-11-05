using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1
{
    public class FamilyApp
    {
        public static List<Person> People { get; set; }
        public string WelcomeMessage { get; set; }
        public string CommandPrompt { get; set; }

        public FamilyApp(params Person[] people)
        {
            People = new List<Person>(people);
            WelcomeMessage = "Velkommen: ";
            foreach (var person in People)
            {
                WelcomeMessage += $"{person.FirstName}, ";
            }

            CommandPrompt =
                "hjelp => viser en hjelpetekst som forklarer alle kommandoene\n" +
                "liste => lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert. \nvis " +
                "<id> => viser en bestemt person med mor, far og barn (og id for disse, slik at man lett kan vise en av dem) vis 3 \n";
        }

        public string HandleCommand(string command)
        {
            if (command == "liste")
            {
                var response = "";
                foreach (var person in People)
                {
                    response += person.GetDescription();
                    response += "\n";
                }

                return response;
            }
            if (command == "hjelp")
            {
                return CommandPrompt;
            }

            if (!command.Contains("vis")) return CommandPrompt;
            var idSplit = command.Split(" ");
            var id = idSplit[1];

            var thePerson = FindPerson(id);

            if (thePerson == null) return "";

            var text = thePerson.GetDescription();
            if (FindChildren(thePerson).Length == 0) return text;
            text += "\n  Barn:\n";
            text = FindChildren(thePerson).Aggregate(text, (current, child) => current + $"    {child.FirstName} (Id={child.Id}) Født: {child.BirthYear}\n");
            return text;
        }

        private static Person FindPerson(string id)
        {
            Person thePerson = null;
            foreach (var person in People)
            {
                if (person.Id == Convert.ToInt32(id))
                {
                    thePerson = person;
                }
            }

            return thePerson;
        }


        public static Person[] FindChildren(Person p)
        {
            var children = new List<Person>();
            foreach (var person in People)
            {
                if (p.Id == person.Father?.Id || p.Id == person.Mother?.Id)
                {
                    children.Add(person);
                }
            }
            return children.ToArray();
        }

    }
}