using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busra_Uzunlar_Mimari_Proje.Classes
{
    public class hammingCoder
    {
        public string Encode(string dataBits)
        {
            int m = dataBits.Length;
            int r = 0;

            // Gerekli parity bit sayısını hesapla (2^r >= m + r + 1)
            while (Math.Pow(2, r) < (m + r + 1))
                r++;

            int totalLength = m + r;
            char[] encoded = new char[totalLength + 1]; // 1-based indexleme için +1

            // Adım 1: Parity bitlerini 0 olarak yerleştir (1,2,4,8...)
            for (int i = 1, j = 0, k = 0; i <= totalLength; i++)
            {
                if (IsPowerOfTwo(i))
                    encoded[i] = '0'; // Parity bit yeri
                else
                    encoded[i] = dataBits[j++]; // Data bit
            }

            // Adım 2: Parity bitlerini hesapla
            for (int i = 0; i < r; i++)
            {
                int parityPos = (int)Math.Pow(2, i);
                int parity = 0;

                for (int j = 1; j <= totalLength; j++)
                {
                    if ((j & parityPos) != 0)
                    {
                        parity ^= (encoded[j] - '0');
                    }
                }

                encoded[parityPos] = (char)(parity + '0');
            }

            // Encode edilmiş sonucu string olarak döndür
            string result = "";
            for (int i = 1; i <= totalLength; i++)
                result += encoded[i];

            return result;
        }

        private bool IsPowerOfTwo(int x)
        {
            return (x & (x - 1)) == 0;
        }

        public string Decode(string encodedData, out int errorPosition)
        {
            int r = 0;
            while (Math.Pow(2, r) < encodedData.Length + 1)
                r++;

            int parityCheck = 0;
            for (int i = 0; i < r; i++)
            {
                int parity = 0;
                for (int j = 1; j <= encodedData.Length; j++)
                {
                    if (((j >> i) & 1) == 1)
                        parity ^= (encodedData[j - 1] - '0');
                }

                if (parity == 1)
                    parityCheck += (1 << i);
            }

            errorPosition = parityCheck - 1;

            char[] corrected = encodedData.ToCharArray();
            if (errorPosition >= 0 && errorPosition < encodedData.Length)
            {
                corrected[errorPosition] = corrected[errorPosition] == '0' ? '1' : '0';  // düzeltme
            }

            // Orijinal veriyi parity bitleri hariç çıkar
            List<char> originalData = new List<char>();
            int parityBitIndex = 0;

            for (int i = 1; i <= corrected.Length; i++)
            {
                if (i == Math.Pow(2, parityBitIndex))
                {
                    parityBitIndex++;
                    continue;
                }
                originalData.Add(corrected[i - 1]);
            }

            return new string(originalData.ToArray());
        }

    }
}
