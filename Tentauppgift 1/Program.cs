 
using System.Globalization;

internal class Program
{
    private static long totalSum = 0;
    private static void Main(string[] args)
    {
        
        string input = "29535123p48723487597645723645";
        int length = input.Length;

        for (int i = 0; i < input.Length; i++) // Kollar siffra för siffra i stringen
        {
            if (char.IsDigit(input[i])) //Kollar att det faktiskt är siffror
            {
                for (int j = i + 1; j < input.Length; j++) //introducerar ny variabel [j] som motsvarar samma siffra som [i] kollar
                {
                    if (char.IsDigit(input[j])) //kollar att [j] är en siffra
                    {
                        if (input[i] == input[j] && char.IsDigit(input[j])) // sant när i är samma siffra som j
                        {
                            string partstring = input.Substring(i, j - i + 1); //plockar ut siffrorna mellan j till i +1 (för att inte få med i) och sparar i partstring

                            PrintInColor(partstring, i, j, input); //Plockar från printincolor
                            if (number(partstring))                //Plockar från number
                            {
                                PartStringSum(partstring);         //Plockar från Partstringsum
                            }
                            break;
                        }
                       
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        Console.WriteLine($"Total summa av röda delsträngar: {totalSum}");
   
     
       


    }
    public static void PrintInColor(string partstring, int i, int j, string input)
    {
        Console.Write($"{input.Substring(0, i)}");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(partstring);
        Console.ResetColor();
        Console.WriteLine($"{input.Substring(j+1, input.Length - (j+1))}");
    }

    public static bool number(string partstring)
    {
        foreach (char c in partstring)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }

    public static void PartStringSum(string partstring)
    {
        long number = long.Parse(partstring);
        totalSum += number;
    }
}
