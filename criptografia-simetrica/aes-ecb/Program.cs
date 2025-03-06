// O modelo ECD não é recomendado para criptografia, pois é inseguro.
// O problema é que ele eventualmente, ao termos
// dois blocos iguais (ou seja, com a mesma mensagem), pode gerar dois cyphers iguais. 

// Ex: ao criptogragar a mensagem: "eu sei, eu sou isso..." os blocos que contém o 'eu' irão gerar os mesmos cyphers.

using System.Security.Cryptography;
using System.Text;

var message = "estudando criptografia";

var random = RandomNumberGenerator.Create();
var key = new byte[16];
random.GetBytes(key);

Console.WriteLine("================= CRIPTOGRAFANDO =================");

var aes = Aes.Create();
aes.Key = key;
var ciphertext = aes.EncryptEcb(Encoding.UTF8.GetBytes(message), PaddingMode.PKCS7);

Console.WriteLine($"Mensagem: {message}");
Console.WriteLine($"Password: {Convert.ToHexString(key)}");
Console.WriteLine($"Cipher: {Convert.ToHexString(ciphertext)}");
Console.WriteLine();

Console.WriteLine("================= DESCRIPTOGRAFANDO =================");

Console.WriteLine(Encoding.UTF8.GetString(aes.DecryptEcb(ciphertext, PaddingMode.PKCS7)));