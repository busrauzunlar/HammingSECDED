using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busra_Uzunlar_Mimari_Proje.Classes
{
    public class memory
    {
            // Bellekteki kodlanmış veri
            public string EncodedData { get; private set; }

            // Veriyi belleğe yaz
            public void Write(string data)
            {
                EncodedData = data;
            }

            // Bellekten oku
            public string Read()
            {
                return EncodedData;
            }

            // Belirli bir bit pozisyonunu boz (yapay hata)
            public void InjectError(int bitPosition)
            {
                if (string.IsNullOrEmpty(EncodedData) || bitPosition < 0 || bitPosition >= EncodedData.Length)
                    return;

                char[] bits = EncodedData.ToCharArray();
                bits[bitPosition] = bits[bitPosition] == '0' ? '1' : '0';  // Flip the bit
                EncodedData = new string(bits);
            }
    }

}
