using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace rfcBaika
{
    public class DB_VoiceCod
    {
    }
}
public  class VoiceCode
{
    public  responce_VOICE Compute(string GTIN, string lot, DateTime? packDate)
    {
        responce_VOICE res = new responce_VOICE();
        ushort crc = Crc16.ComputeChecksum(Encoding.ASCII.GetBytes(string.Format("{0}{1}{2}", GTIN, lot, packDate.HasValue ? packDate.Value.ToString("yyMMdd") :
        string.Empty)));
        res.voice = string.Format("{0:0000}", crc % 10000);
        res.VoiceA = res.voice.Substring(0, 2);
        res.VoiceB = res.voice.Substring(2, 2);
        return res;
    }
}

public class responce_VOICE
{
    public String voice;
    public String VoiceA;
    public String VoiceB;
}
public static class Crc16
{
    #region static members
    private const ushort polynomial = 0xA001; private static ushort[] table = new ushort[256];
    static Crc16()
    {
        ushort value; ushort temp;
        for (ushort i = 0; i < table.Length; ++i)
        {
            value = 0;
            temp = i; for (byte j = 0; j < 8; ++j)
            {
                if (0 != ((value ^ temp) & 0x0001))
                {
                    value = (ushort)((value >> 1) ^ polynomial);
                }
                else
                {
                    value >>= 1;
                } temp >>= 1;
            }
            table[i] = value;
        }
    }
    #endregion

    public static ushort ComputeChecksum(byte[] bytes)
    {
        ushort crc = 0;
        for (int i = 0; i < bytes.Length; ++i)
        {
            byte index = (byte)(crc ^ bytes[i]);
            crc = (ushort)((crc >> 8) ^ table[index]);
        } return crc;
    }
}