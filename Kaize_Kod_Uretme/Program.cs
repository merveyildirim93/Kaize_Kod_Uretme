using System.Diagnostics;
using System.Numerics;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main()
    {
        List<string> generatedCodes = GenerateUniqueCodes(1000);
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

        // 8'li permütasyonu al ve numCodes sayısına kadar olan olasılıkları elde et
        List<List<int>> permutations = GetPermutations(indices, 8).Distinct().Take(numCodes).ToList();

        // Oluşturulan her kod için geçerlilik kontrolü yapılıyor ve eğer benzersizse listeye ekleniyor, benzersiz değilse döngü sonlanıyor
        foreach (List<int> permutation in permutations)
        {
            string code;
            do
            {
                code = GenerateCode(permutation);
                if (generatedCodes.Contains(code))
                {
                    Console.WriteLine(code + "  --- KOD GEÇERSİZ (TEKRARLI)");
                }
                else
                {
                    Console.WriteLine(code + "  --- KOD GEÇERLİ");
                }
            } 
            while (generatedCodes.Contains(code));
            generatedCodes.Add(code);
        }

        return generatedCodes;
    }

    static string GenerateCode(List<int> permutation)
    {
        Random random = new Random();
        string charSet = "ACDEFGHKLMNPRTXYZ234579";
        string code = "";
        int start = random.Next(1, 23); // Kodun başlangıç indexi için random bir değer seçiyoruz
        int prevIndex = start;

        foreach (int index in permutation)
        {
            int nextIndex = (prevIndex + index - 1) % 23; // Modulus 23 işlemi
            char nextChar = charSet[nextIndex];
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
}