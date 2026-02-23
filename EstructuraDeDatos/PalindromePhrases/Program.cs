using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    //blueprint (data input)
    Console.Clear();
    Console.WriteLine("*** FRASES PALINDROMAS ***");
    var phrase = ConsoleExtension.GetString("Ingrese una palabra o frase de su gusto: ");

    //processes
    var isStringPalindrome = CheckPalindromism(phrase);

    //show result
    Console.WriteLine($"La palabra, o frase: {phrase}, { (isStringPalindrome ? "SI" : "NO") } es palíndroma.");
    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?....: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Gracias por usar el programa! Game Over :)");

bool CheckPalindromism(string? phrase) //we have to do an algorith that compares the first an the last letter, then the second and the second to last, until we get to the middle, and if all of the letters in the comparison are equal, then the phrase is a palindrome.
{
    //bypass blank spaces with a new method
    phrase = PreparePhrase(phrase);
    var n = phrase!.Length;
    for (var i = 0; i <= n / 2; i++)
    {
        if (phrase[i] != phrase[n - i - 1])
        {
            return false;
        }
    }
    return true;
}

string? PreparePhrase(string? phrase)
{
    //convert the phrase to everything lowercase so we wont have any problems comparing, and take out all the blank spaces
    phrase = phrase!.ToLower();
    var newPhrase = string.Empty;
    //array for every blank space, comma, punctuaction, etc.
    var exceptions = new List<char> { ' ', ',', '.', '!', '¡', '?', '¿', ':', ';'};
    foreach (var c in phrase) //iterate through each character in the phrase so its easier to get
    {
        if (exceptions.Contains(c)) //if the exceptions contain the char in the exceptions table, then ignore it.
        {
            newPhrase += c;
        }
    }

    //for tildes, we replace in each character for the letter without them
    newPhrase = newPhrase.Replace('á', 'a');
    newPhrase = newPhrase.Replace('é', 'e');
    newPhrase = newPhrase.Replace('í', 'i');
    newPhrase = newPhrase.Replace('ó', 'o');
    newPhrase = newPhrase.Replace('ú', 'u');

    return newPhrase;
}