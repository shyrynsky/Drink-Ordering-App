using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace SimpleXOREncryptPlugin
{
    [Plugin(PluginType.ptTransformFiles)]
    public class SimpleXOREncryptPlugin : ITransformFilePlugin
    {
        public string Name
        {
            get { return "Simple XOR Encrypt Stream creation Plugin"; }
        }

        public string Version
        {
            get { return "1.2.0"; }
        }

        public string Author
        {
            get { return "Maria Dorova"; }
        }

        private static byte[] _key;
        public static byte[] Key
        {
            get
            {
                if (_key == null)
                {
                    _key = GenerateDefaultKey(); // Генерируем дефолтное значение ключа
                }
                return _key;
            }
            set { _key = value; }
        }

        // Генерируем дефолтное значение ключа
        private static byte[] GenerateDefaultKey()
        {
            return new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 };
        }

        public Stream GetTransformStream(Stream stream)
        {
            return new CryptoStream(stream, new SimpleXOREncryption(Key), CryptoStreamMode.Write);
        }

        public Stream GetDetransformStream(Stream stream)
        {
            return new CryptoStream(stream, new SimpleXOREncryption(Key), CryptoStreamMode.Read);
        }

        public string GetExtension()
        {
            return "XorEncrypt";
        }
    }


    public class SimpleXOREncryption : ICryptoTransform
    {
        private bool _disposed = false;
        private byte[] _key;

        public SimpleXOREncryption(byte[] key)
        {
            _key = key;
        }

        // Реализация методов интерфейса ICryptoTransform
        public bool CanReuseTransform => false;
        public bool CanTransformMultipleBlocks => false;
        public int InputBlockSize => 1;
        public int OutputBlockSize => 1;

        public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
        {
            for (int i = 0; i < inputCount; i++)
            {
                outputBuffer[outputOffset + i] = (byte)(inputBuffer[inputOffset + i] ^ _key[i % _key.Length]);
            }
            return inputCount;
        }

        public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
        {
            byte[] outputBuffer = new byte[inputCount];
            TransformBlock(inputBuffer, inputOffset, inputCount, outputBuffer, 0);
            return outputBuffer;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Освободить управляемые ресурсы
                }
                // Освободить неуправляемые ресурсы
                _disposed = true;
            }
        }
    }
}
