string text = "29535123p48723487597645723645"; // Test input

// Check each character
for (int startIndex = 0; startIndex < text.Length; startIndex++)
{
    // Check for digit
    if (char.IsDigit(text[startIndex]))
    {
        // Search for matching digit
        for (int searchIndex = startIndex + 1; searchIndex < text.Length; searchIndex++)
        {
            // Stop search at non-digit
            if (!char.IsDigit(text[searchIndex]))
            {
                break;
            }

            // Matching digit found
            if (text[searchIndex] == text[startIndex])
            {
                int segmentLength = (searchIndex - startIndex) + 1;
                string numberSegment = text.Substring(startIndex, segmentLength);

                Console.WriteLine(numberSegment); // Test output

                break;
            }
        }
    }
}
