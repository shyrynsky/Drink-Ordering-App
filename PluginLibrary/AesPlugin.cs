using System.Security.Cryptography;
using BaseClassLibrary;

namespace PluginLibrary;

public class AesPlugin: IFilePlugin
{
    public Stream GetInputStream(Stream initStream, string param)
    {
        using var aes = Aes.Create();
        byte[] iv = new Byte[]{
            0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
            0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
        };

        var paramArr = BitConverter.GetBytes(long.Parse(param.Trim()));
        var list = new List<byte>(paramArr);
        list.AddRange(paramArr);
        byte[] key = list.ToArray();
        
        return new CryptoStream(initStream, aes.CreateDecryptor(key, iv), CryptoStreamMode.Read);
    }

    public Stream GetOutputStream(Stream initStream, string param)
    {
        using var aes = Aes.Create();
        var paramArr = BitConverter.GetBytes(long.Parse(param.Trim()));
        var list = new List<byte>(paramArr);
        list.AddRange(paramArr);
        aes.Key = list.ToArray();
        aes.IV = new Byte[]{
            0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
            0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
        };
        
        return new CryptoStream(initStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
    }

    public string PluginName { get; } = "aes плагин";
}