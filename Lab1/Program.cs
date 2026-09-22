Console.Write($"Enter text to search: ");
string? inputText = Console.ReadLine();
Console.WriteLine();

// Validate user input
if (string.IsNullOrWhiteSpace(inputText))
{
    Console.WriteLine($"No input provided.");
}
else
{
    long totalSum = 0; // Store total sum

    // Check each character
    for (int startIndex = 0; startIndex < inputText.Length; startIndex++)
    {
        // Skip non-digit
        if (!char.IsDigit(inputText[startIndex]))
        {
            continue;
        }
        else
        {
            // Search for matching digit
            for (int searchIndex = startIndex + 1; searchIndex < inputText.Length; searchIndex++)
            {
                // Stop at non-digit
                if (!char.IsDigit(inputText[searchIndex]))
                {
                    break;
                }

                // Check for matching digit
                if (inputText[searchIndex] == inputText[startIndex])
                {
                    int segmentLength = (searchIndex - startIndex) + 1;
                    string numberSegment = inputText.Substring(startIndex, segmentLength);

                    DisplayHighlightedSegment(inputText, numberSegment, startIndex, searchIndex);

                    totalSum = AddSegmentToTotal(numberSegment, totalSum);

                    break;
                }
            }
        }
    }

    // Display total sum
    Console.WriteLine();
    Console.WriteLine($"Total: {totalSum}");
}

// Highlight matching segment
static void DisplayHighlightedSegment(string text, string numberSegment, int startIndex, int searchIndex)
{
    string beforeSegment = text.Substring(0, startIndex);
    string afterSegment = text.Substring(searchIndex + 1);

    Console.Write(beforeSegment);

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write(numberSegment);

    Console.ResetColor();
    Console.WriteLine(afterSegment);
}

// Convert segment and add to total
static long AddSegmentToTotal(string numberSegment, long totalSum)
{
    long segmentValue = long.Parse(numberSegment);
    totalSum += segmentValue;

    return totalSum;
}