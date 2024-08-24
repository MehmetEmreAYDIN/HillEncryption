char[] alphabet = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ".ToCharArray();	//Enter the letters of alphabet in this field.
char[] plainText = "Kriptoloji".ToUpper().ToCharArray();	//Enter the plain text in this field.
int[] matrix = { 3, 2, 4, 1, 3, 5, 0, 2, 1 };   //Enter the numbers in the key matrix with commas between them in this field. Warning! The key matrix must be a regular matrix.
char rndLetter = char.ToUpper('j');   //If necessary, enter the letter to be added to the end of the plain text in this field.

int n = (int)Math.Sqrt(matrix.Length);
int[,] keyMatrix = new int[n, n];
for (int i = 0; i < n; i++)
{
	for (int j = 0; j < n; j++)
	{
		keyMatrix[i, j] = matrix[i * n + j];
	}
}

string cipherText = string.Empty;
for (int i = 0; i < plainText.Length; i += n)
{
    int[] matrix2 = new int[n];
    for (int j = 0; j < n; j++)
    {
        if (i + j < plainText.Length)
        {
            matrix2[j] = Array.IndexOf(alphabet, plainText[i + j]);             
        }
        else
        {
            matrix2[j] = Array.IndexOf(alphabet, rndLetter);
        }
    }
    for (int l = 0; l < n; l++)
    {
        int sum = 0;
        for (int k = 0; k < n; k++)
        {
            sum += matrix2[k] * keyMatrix[l, k];
        }
        while (sum < 0)
        {
            sum += alphabet.Length;
        }
        sum %= alphabet.Length;
        cipherText += alphabet[sum];
    }
}
Console.WriteLine(cipherText);