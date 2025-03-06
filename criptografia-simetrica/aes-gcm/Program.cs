// O modo GCM permite uma criptografia autenticada, ou seja, o receptor consegue validar antes de descriptografar 
// se o cypher é válido.

// Com ele é possível criptografar os dados em paralelo, sendo extremamente performático. Diferente do modo anterior CBC, que é linear.

// Um dos modos mais recomentado para criptografia simétrica.

using System.Security.Cryptography;
using System.Text;

static void WriteByteArray(string name, byte[] byteArray)
{
    Console.WriteLine($"{name}: {byteArray.Length} bytes, {byteArray.Length << 3}-bit:");
    Console.WriteLine($" -> {BitConverter.ToString(byteArray)} - base64:  {Convert.ToBase64String(byteArray)}");
}

var message = "estudando criptografia";
var key = new byte[16];
var iv = new byte[16];
var authTag = new byte[16];

RandomNumberGenerator.Fill(key);
RandomNumberGenerator.Fill(iv);

Console.WriteLine("================= CRIPTOGRAFANDO =================");

Console.WriteLine($"Mensagem: {message}");
Console.WriteLine($"Key: {key}");
Console.WriteLine();

var plainBytes = Encoding.UTF8.GetBytes(message);
var cipher = new byte[plainBytes.Length];

using (var aesGcm = new AesGcm(key, 16))
    aesGcm.Encrypt(iv, plainBytes, cipher, authTag);

WriteByteArray("cipher", cipher);
WriteByteArray("iv", iv);
WriteByteArray("authTag", authTag);

Console.WriteLine();

Console.WriteLine("================= DESCRIPTOGRAFANDO =================");

Console.WriteLine($"cipher: {Convert.ToBase64String(cipher)}");
Console.WriteLine($"iv: {Convert.ToBase64String(iv)}");
Console.WriteLine($"authTag: {Convert.ToBase64String(authTag)}");

Console.WriteLine();

var decryptedBytes = new byte[cipher.Length];

using (var aesGcm = new AesGcm(key, 16))
    aesGcm.Decrypt(iv, cipher, authTag, decryptedBytes);

var decrypedText = Encoding.UTF8.GetString(decryptedBytes);
Console.WriteLine($"mensagem: {decrypedText}");
Console.WriteLine();