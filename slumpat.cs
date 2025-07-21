using System; // written as system instead of System

// C# convention: File name should be in PascalCase, using the same name as the primary class.
// C# convention: Everything is in Swedish, should be in English. I'll never stop complaining about this.

namespace Uppgift_4
{
    public class Guess
    {
        public void GuessingGame()
        {
            // Deklaration av variabler
            Random slumpat = new Random(); // skapar ett random objekt
            int speltal = slumpat.Next(); // anropar Next metoden för att skapa ett slumptal mellan 1 och 20
            // läs på, vad är overload metoder? https://msdn.microsoft.com/en-us/library/system.random.next(v=vs.110).aspx
            bool spela = true; // Variabel för att kontrollera om spelet ska fortsätta köras

            while (!spela) // Checking if false, when the bool is true at start
            {
                Console.Write("\n\tGissa på ett tal mellan 1 och 20: ");
                int tal = Convert.ToInt32(Console.ReadLine());

                if (tal < speltal)
                {
                    Console.WriteLine("\tDet inmatade talet " + tal + " är för litet, försök igen.");
                }

                else if (tal > speltal)
                {
                    Console.WriteLine("\tDet inmatade talet " + tal  + " är för stort, försök igen.");
                }

                else
                    Console.WriteLine("\tGrattis, du gissade rätt!");
                spela = false;

            }
        }
    }
}
