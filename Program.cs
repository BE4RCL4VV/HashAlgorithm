using System;

namespace HashAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fred = new string[5];
            fred = AddPerson("Dan", fred);
            fred = AddPerson("Aiden", fred);
            fred = AddPerson("Matt", fred);
            fred = AddPerson("Mitch", fred);

            foreach (string entry in fred)
            {
                if (entry != null)
                {
                    Console.WriteLine(entry + "'s hash value is: " + "");
                }
            }
        }
        static string[] AddPerson(string name, string[] fred)
        {
            if (CheckIfEmpty(HashValue(name, fred), fred))
            {
                fred[HashValue(name, fred)] = name;
                return fred;
            }
            else
            {
                fred[FindHole(HashValue(name, fred), fred)] = name;
                return fred;
            }           
        }
        static bool CheckIfEmpty(int location, string[] array)
        {
            if (array[location] != null)
            {
                return false;
            }
            return true;
        }
        static int FindHole(int location, string[] array)
        {         
            if (array[location] != null)
            {
                location++;
            }
            else
            {
                return location;
            }
            if (CheckIfEmpty(location, array))
            {
                return location;
            }
            else
            {
                location = FindHole(location, array);
            }
            return location;
        }
        static int HashValue(string input, string[] array)
        {
            int value = ASCIIValue(input);
            return value %= array.Length;
        }
        static int ASCIIValue(string input)
        {
            int value = 0;
            foreach (char character in input)
            {
                value += (int)character;
            }
            return value;
        }
    }
}
