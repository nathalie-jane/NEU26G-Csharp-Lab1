string text = "29535123p48723487597645723645"; // Test input

long totalSum = 0; // Store total sum

// Check each character
for (int startIndex = 0; startIndex < text.Length; startIndex++)
{
    // Check for digit
    if (char.IsDigit(text[startIndex]))
    {
        // Search for matching digit
        for (int searchIndex = startIndex + 1; searchIndex < text.Length; searchIndex++)
        {
            // Stop at non-digit
            if (!char.IsDigit(text[searchIndex]))
            {
                break;
            }

            // Check for matching digit
            if (text[searchIndex] == text[startIndex])
            {
                int segmentLength = (searchIndex - startIndex) + 1;
                string numberSegment = text.Substring(startIndex, segmentLength);

                DisplayHighlightedSegment(text, numberSegment, startIndex, searchIndex);

                // Convert segment and add to total
                long segmentValue = long.Parse(numberSegment);
                totalSum += segmentValue;

                break;
            }
        }
    }
}

// Helper method for highlighted output
static void DisplayHighlightedSegment(string text, string numberSegment, int startIndex, int searchIndex)
{
    string beforeSegment = text.Substring(0, startIndex);
    string afterSegment = text.Substring(searchIndex + 1);

    Console.Write(beforeSegment);

    // Highlight matching segment
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write(numberSegment);

    Console.ResetColor();
    Console.WriteLine(afterSegment);
}

// Display total sum
Console.WriteLine();
Console.Write($"Total: {totalSum}");