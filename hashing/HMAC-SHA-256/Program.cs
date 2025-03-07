// Algoritmo de Hash com senha (chave secreta que é compartilhada com o destinatário) para garatir a integridade da informação e mais segurança

using System.Security.Cryptography;
using System.Text;

var message = "estudando criptografia";
Console.WriteLine($"Mensagem: {message}");

var key = new byte[16];
RandomNumberGenerator.Fill(key);

var hmac = new HMACSHA256(key);
var hmacResult = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));

Console.WriteLine($"Senha: {Convert.ToHexStringLower(key)}");
Console.WriteLine($"HMAC-SHA-256: {Convert.ToHexStringLower(hmacResult)}");