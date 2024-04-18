using System.Numerics;

class Program
{
    static void Main()
    {
        List<string> generatedCodes = GenerateUniqueCodes(100);
        foreach (var code in generatedCodes)
        {
            Console.WriteLine(code);
        }
    }
    static List<string> GenerateUniqueCodes(int numCodes)
    {
        List<string> generatedCodes = new List<string>();
        Random random = new Random();

        // 1 ile 23 arasındaki sayıları arasında random bir küme oluştur
        List<int> indices = new List<int>();

        for (int i = 0; i < 8; i++)
        {
            indices.Add(random.Next(1, 23)); // 1 ve 23 arasında rastgele sayı üretir
        }

        // 7'li permütasyonu al ve numCodes sayısına kadar olan olasılıkları elde et
        List<List<int>> permutations = GetPermutations(indices, 7).Distinct().Take(numCodes).ToList();

        foreach (List<int> permutation in permutations)
        {
            string code;
            do
            {
                code = GenerateCode(permutation, random);
            } while (generatedCodes.Contains(code));
            generatedCodes.Add(code);
        }

        return generatedCodes;
    }

    static string GenerateCode(List<int> permutation, Random random)
    {
        string code = "";
        int start = random.Next(1, 23); // Kodun başlangıç indexi için random bir değer seçiyoruz
        int prevIndex = start;

        //BU KISMI KONTROL İÇİN DE KULLAN
        foreach (int index in permutation)
        {
            int nextIndex = (prevIndex + index - 1) % 23; // Modulus 23 işlemi
            char nextChar = "ACDEFGHKLMNPRTXYZ234579"[nextIndex];
            code += nextChar;
            prevIndex = nextIndex;
        }
        return code;
    }

    static List<List<T>> GetPermutations<T>(List<T> list, int length)
    {
        if (length == 1) return list.Select(t => new List<T> { t }).ToList();
        return GetPermutations(list, length - 1)
            .SelectMany(t => list.Where(e => !t.Contains(e)),
                        (t1, t2) => t1.Concat(new List<T> { t2 }).ToList()).ToList();
    }

    static bool IsValidCode(string code)
    {
        int[] connections = { 2, 5, 6, 10, 16, 18, 21, 22 }; // Bağlantılar
        BigInteger codeNum = 0;

        // Karakterlerin indekslerini al ve bağlantıları hesapla
        List<int> indexes = code.Select(c => "ACDEFGHKLMNPRTXYZ234579".IndexOf(c) + 1).ToList();
        List<int> differences = new List<int>();
        for (int i = 1; i < indexes.Count; i++)
        {
            int diff = (indexes[i] - indexes[i - 1] + 23) % 23;
            differences.Add(diff);
        }

        // Bağlantıları string olarak birleştir ve BigInteger'a dönüştür
        string connectionString = string.Join("", differences);
        bool isValidBigInt = BigInteger.TryParse(connectionString, out codeNum);
        if (!isValidBigInt) return false;

        // 1. ve 10.000.000. satırlar arasında veya eşit olmalı
        BigInteger minNum = BigInteger.Parse("10161852622");
        BigInteger maxNum = BigInteger.Parse("100951416107142359695918155112222518313");
        return codeNum >= minNum && codeNum <= maxNum;
    }
}
