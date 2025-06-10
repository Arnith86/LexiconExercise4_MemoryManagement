using System;

/**
 * Questions and Exercises:
 * 
 * Frågor:
 * 1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion?
 *
 *    En stack har en fast storlek och har en LIFO-struktur (Last In, First Out), vilket betyder att det som sist lades på stacken 
 *    kommer vara det första som hanteras. Det går inte att komma åt ett element i stacken utan att först ta bort alla element ovanför det.
 *    
 *    Medan heapen har en dynamisk storlek, där dess struktur gör att alla element är nåbara direkt via dess referens. 
 *    Detta är alltså olikt heap-strukturen som används i algoritmer, som bäst beskrivs som ett träd där element är länkade till varandra.
 *    
 *    2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?
 *    
 *    Value types är datatyper som lagras direkt i minnet (stacken). Detta betyder att de måste vara deklarerade innan de används. 
 *    Det finns undantag för detta dock. Deklareras de i en metod så lagras de i stacken som nämnt innan, men om de deklareras i en klass 
 *    så lagras de i heapen. Ett par exempel på dessa typer är int, double, char, struct.
 *    
 *    Reference types är datatyper som lagras i heapen, medan dess referens är lagrad i stacken.
 *    Ett par exempel på dessa typer är string, class, object, interface och delegater.
 *    
 *    3. Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför?
 *    
 *    ReturnValue()
 *    
 *    int är, som precis nämnt, en value type, vilket innebär att den lagras direkt på stacken. 
 *    När x och y deklareras i metoden så skapas de därför som separata instanser i stacken. 
 *    Vi ser att x = 3 och y = x, vilket betyder att y tar det direkta värdet av x som då är 3. 
 *    Värdet av y ändras sedan till 4. Men då de är separata instanser så påverkas inte x av den ändringen, 
 *    vilket gör att x fortfarande har värdet 3 när metoden returnerar.
 *    
 *    ReturnValue2()
 *    
 *    Här skapas istället två instanser av klassen MyInt. En klass är, som nämnt, en referenstyp, vilket innebär att 
 *    det enbart är referensen till klassinstansen som lagras i stacken, medan själva instansen lagras i heapen. 
 *    Det vi ser är att x.MyValue får värdet 3 och sedan får y en kopia av referensen till x.
 *    Den har alltså bara tillgång till minnesadressen till instansen – det är inte en ny instans. 
 *    Vilket då betyder att när y.MyValue ändras till 4 så ändrar det värdet i instansen som både x och y refererar till. 
 *    Därför returnerar metoden 4 och inte 3 som i första exemplet.
 * 
 **/



namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
			/*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

			/*
             * Övning 1: ExamineList()
             * 
             *  2.  När vi startar med 0 element i listan har arrayen storlek 0. Så fort det första elementet sätts till ökan kapaciteten till 4.
             *      när vi överstiger det värdet (fler än 4 element) så förstoras storleken av arrayen till 8. Samma sak händer när vi överstiger
             *      8 element. Svaret är att storleken ändras när vi överstiger det nuvarande storleken av arrayen.
             *  
             *  3.  Kapaciteten ökas binärt från storleken 4. Dvs att vi först har 4 element, sedan 8, 16, 32, 64 och så vidare.
             *  
             *  4.  En Array är en referens typ där man måste ange hur stor arrayen ska vara vid skapandet av arrayen. Skulle vi öka storleken 
             *      på arrayen i takt med elementen så måste vi först skapa en ny array med +1 i storlek och sedan kopiera över samtliga värden
             *      från den originella arrayen. Detta för varje förstoring, vilket är en dyr process.
             *      
             *  5.  Nej, storleken förblir detsamma vid en förminskning. Den bebehåller där med dess största storlek oavvsätt hur många element
             *      det finns i Arrayen.
             * 
             *  6.  Det är fördelaktigt att använda en egendefinierad array, när vi vet att storleken på innehållet kommer att förbli detsamma. 
             */


			Console.WriteLine("Add or subtract elements to the list by using the bellow option before your chosen inputs.\n " +
                "Only single words will be registered.");
			Console.WriteLine("+ : Adds input to the list.");
			Console.WriteLine("- : Removes inputted value from the list, if an exact match is found.");
			Console.WriteLine("0 : Exit to main menu.");
			Console.WriteLine("");

            List<string> theList = new List<string>();
            string input = string.Empty;

            do
            {
				Console.Write("Please enter your chosen input: ");
                input = Console.ReadLine();

                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        break;
                    case
                        '-':
                        
                        if (theList.Contains(value))
                            theList.Remove(value);
                        else
                            Console.WriteLine("No such word in the list. Try again!");
                            
                        break;
                    default:
                        Console.WriteLine("Your input must start with -, + or 0 to exit. \nTry again!");
                        break;
                }

            } while (input != "0");
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

