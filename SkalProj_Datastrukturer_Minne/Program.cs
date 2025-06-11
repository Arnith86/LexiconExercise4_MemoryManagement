using System;
using System.Text.RegularExpressions;




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


            // Loops until the user inputs "0" to exit to main menu.
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
                        // Makes sure that the value exist in the list before trying to remove it.
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
             * Övning 2: ExamineQueue()
             * 
             *  1.  Simulering av kö på "Papper". Kön går från vänster till höger.
             *  
             *      1. *Tom*
             *      2. Kalle
             *      3. Kalle, Greta
             *      4. Greta
             *      5. Greta, Stina
             *      6. Stina
             *      7. Stina, Olle .... and so on..
             *  
             *  2.  Queue implementation, har formaterat utskriften lite, så att ni enklare kan läsa.. 
             *      
             *      Please enter your chosen input: +kalle
             *      Queue State: 
             *      kalle
             *      
             *      Please enter your chosen input: +Greta
             *      Queue State: 
             *      kalle 
             *      Greta
             *      
             *      Please enter your chosen input: -
             *      kalle removed from the queue!
             *      Queue State: 
             *      Greta 
             *      
             *      Please enter your chosen input: +Stina
             *      Queue State: 
             *      Greta 
             *      Stina
             *      
             *      Please enter your chosen input: -
             *      Greta removed from the queue! 
             *      Queue State: 
             *      Stina
             *      
             *      Please enter your chosen input: +Olle
             *      Queue State: 
             *      Stina 
             *      Olle
             */

			/*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

			Console.WriteLine("Enqueue or Dequeue elements to the Queue by using the bellow option before your chosen inputs.");
			Console.WriteLine("+ : Enqueue input to the Queue.");
			Console.WriteLine("- : Dequeues element to the list.");
			Console.WriteLine("0 : Exit to main menu.");
			Console.WriteLine("");

            Queue<string> theQueue = new Queue<string>();
			string input = string.Empty;

			// Loops until the user inputs "0" to exit to main menu.
			do
			{
				Console.Write("Please enter your chosen input: ");
				input = Console.ReadLine();

				char nav = input[0];
				string value = input.Substring(1);

				switch (nav)
				{
					case '+':
						theQueue.Enqueue(value);
						break;
					case
						'-':
                        // Checks if the queue has any elements before trying to dequeue.
						if (theQueue.Count > 0)
                            Console.WriteLine($"{theQueue.Dequeue()} removed from the queue!");
						else
							Console.WriteLine("Queue is empty. Try adding something first!");
                        break;
					default:
						Console.WriteLine("Your input must start with -, + or 0 to exit. \nTry again!");
						break;
				}

				Console.WriteLine("Queue State: ");
                foreach (var item in theQueue)
                {
					Console.WriteLine(item);
                }

			} while (input != "0");


		}

		/// <summary>
		/// Examines the datastructure Stack
		/// </summary>
		static void ExamineStack()
        {

			/*
		     * Övning 3: ExaminStack()
		     * 
		     *  1.  Simulering av kö på "Papper". Kön går från vänster till höger.
		     *  
		     *      1. *Tom*
		     *      2. Kalle
		     *      3. Greta, Kalle 
		     *      4. Kalle 
		     *      5. Stina, Kalle
		     *      6. Kalle
		     *      7. Olle, Kalle.... and so on..
		     *      
		     *      Det blir inget flöde i "kön" utan stackars Kalle får stå kvar längst ner i stacken tills det slutar fylla på i "kassan"
		     **/

			/*
			 * Loop this method until the user inputs something to exit to main menue.
			 * Create a switch with cases to push or pop items
			 * Make sure to look at the stack after pushing and and poping to see how it behaves
			*/
			
            Console.WriteLine("String reverser, start input with bellow option before your chosen inputs.");
			Console.WriteLine("+ : starts the reverser.");
			Console.WriteLine("0 : Exit to main menu.");
			Console.WriteLine("");

			Stack<string> theStack = new Stack<string>();
			string input = string.Empty;

			// Loops until the user inputs "0" to exit to main menu.
			do
			{
				Console.Write("Please enter what you want to reverse: ");
				input = Console.ReadLine();

				char nav = input[0];
				string value = input.Substring(1);

				switch (nav)
				{
					case '+':
                        // Iterates through the string and pushes each character onto the stack.
                        for (int i = 0; i < value.Count(); i++)
                            theStack.Push(value[i].ToString());
					    break;
                    case '0':
                        return;
					default:
						Console.WriteLine("Your input must start with -, + or 0 to exit. \nTry again!");
						break;
				}

				Console.Write("Input reversed: ");
				// As long as there are elements in the stack, pop them and print them.
                while(theStack.Count > 0)
                    Console.Write(theStack.Pop());
				
                Console.WriteLine("");

			} while (input != "0");

		}

		static void CheckParanthesis()
        {
			/*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
			
            /*
             *  Övning 4: CheckParenthesis()
             *      
             *      1.  En lösning skulle kunna vara att iterera igenom hela strängen och spara alla instanser av parenteser i en lista, och sedan räkna hur 
             *          många instanser av varje sort det finns. Är alla jämna så är strängen välformad. Ett stort problem med den lösningen är att det inte 
             *          utesluter att parenteser är placerade fel, som i detta exempel: })][({.
             *          
             *          Därför måste vi även tänka på parenteser som "par" – en startparentes och en matchande slutparentes. Problemet vi möter då är att
             *          vi möter startparenteser i "exekveringsordning", medan vi möter slutparenteser i omvänd ordning. Om vi tar detta exempel, [({})], 
             *          för att illustrera:
             *          
             *          start     slut       
             *            [         }
             *            (         )
             *            {         ]
             * 
             *          Den lösning jag skulle implementera använder sig av två olika strukturer, Queue och Stack, för att hantera just det problemet. 
             *          När vi itererar igenom en sträng lagrar vi startparenteserna i en Stack och slutparenteserna i en Queue. 
             *          
             *          
             *          Originalordning:      Stack Pop    /   Queue Dequeue-ordning:
             *          start     slut           start         slut       
             *            [         }               {           }
             *            (         )               (           )
             *            {         ]               [           ]
             *          
             *          På så vis matchas start- och slutparenteser. Gör de inte det så vet vi att det inte är en välformad delmängd/sträng.
             *          Så fort både Queue:n och Stack:en har lika många element startas en kontroll av den delmängd av start- och slutparenteser som 
             *          hittats. När båda har lika många element betyder det att de uppfyller kravet för vad som kan klassas som en välformad delmängd 
             *          av parenteser. Beroende på om detta test har godkänts så fortsätter iterationen av strängen för att hitta möjliga fler mönster.
             */
		

			Console.WriteLine("Balanced Parentheses. Supply your input and this algorithm will check if all parentheses have a matching start and finish.");
			Console.WriteLine("                      Start the string with '+'.");
			Console.WriteLine("+ : starts the balanced parentheses check.");
			Console.WriteLine("0 : Exit to main menu.");
			Console.WriteLine("");

			
			string input = string.Empty;

			// Loops until the user inputs "0" to exit to main menu.
			do
			{
                Console.Write("Please enter the string you want to check: ");
				input = Console.ReadLine();

				char nav = input[0];
				string value = input.Substring(1);

				switch (nav)
				{
					case '+':
                        DisplayBalancedParenthesesResult(value); 
                        break;
					case '0':
						return;
					default:
						Console.WriteLine("Your input must start with -, + or 0 to exit. \nTry again!");
						break;
				}

			} while (input != "0");
		}

		private static void DisplayBalancedParenthesesResult(string value)
		{
			Console.Write("Are the parentheses balanced: ");
			Console.Write(IsParenthesesBalancedInCompleteString(value));
			Console.WriteLine("");
		}

		private static bool IsSetOfParenthesesBalanced(
			Stack<char> startParentheses,
			Queue<char> endParentheses)
		{
			bool isBalanced = true;

			// As long as there are elements in the collections retrieve next elements and see if it 
            // is balanced parentheses. 
			if (startParentheses.Count == endParentheses.Count)
			{
				while (startParentheses.Count > 0)
				{
					isBalanced = IsMatchingParentheses(
						startParentheses.Pop(),
						endParentheses.Dequeue()
					);

					if (!isBalanced) break;
				}
			}
			else
			{
				isBalanced = false;
			}

            return isBalanced;
		}
	
        private static bool IsParenthesesBalancedInCompleteString(string value)
		{
            bool isBalanced = true;
			Stack<char> startParentheses = new Stack<char>();
			Queue<char> endParentheses = new Queue<char>();

			for (int i = 0; i < value.Length; i++)
			{
				if (IsStartParentheses(value[i]))
                {
                    startParentheses.Push(value[i]);
                }
				else if (IsEndParentheses(value[i]))
                {
                    endParentheses.Enqueue(value[i]);
                }

                // If the same amount of start and end parentheses have been found, then we have found what should be a balanced set
                // of parentheses and can check if it is true. If not then a set of parentheses are not balanced which makes the whole
                // string not balanced. 
                if (startParentheses.Count == endParentheses.Count)
                {
                    if (isBalanced = IsSetOfParenthesesBalanced(startParentheses, endParentheses))
                        continue;
                    else 
                        break;
                } 

			}

            // If there are still parentheses that have not been handled, then the string is not balanced
            if (startParentheses.Count > 0 || endParentheses.Count > 0)
            {
				Console.WriteLine("");
            }

            return isBalanced;
		}

		private static bool IsMatchingParentheses(char start, char end)
		{
            switch (start)
            {
                case '(':
                    return ')' == end;
                case '{':
					return '}' == end;
                case '[':
					return ']' == end;

				default:
					Console.WriteLine("No start parentheses found..");
                    return false; 
            }
        }

		private static bool IsStartParentheses(char value)
		{
            return value == '(' || value == '{' || value == '['; 
		}

		private static bool IsEndParentheses(char value)
		{
			return value == ')' || value == '}' || value == ']';
		}
	}
}

