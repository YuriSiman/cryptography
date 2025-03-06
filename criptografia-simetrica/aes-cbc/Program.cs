// O modelo CBC é uma evolução do ECD, ele resolve o problema de eventualmente, ao termos
// dois blocos iguais, poder gerar dois cyphers iguais.
// No seu caso, ele resolve esse problema da seguinte forma:
// Após a criptografia do primeiro bloco, com o seu resultado é realizado um XOR com o segundo bloco.
// O segundo bloco passa por um procecsso de criptografia e também é feito um XOR com o próximo bloco, e assim por diante.
// Dessa forma o resultado sempre será diferente, mesmo que o bloco tenha a mesma mensagem.

// Também há como, conforme o exmplo abaixo, acrescentar um vetor de inicialização ao primeiro bloco no CBC. Assim o primeiro
// bloco também ficará irreconhecível.

using System.Security.Cryptography;
using System.Text;

var message = "estudando criptografia";
var random  = RandomNumberGenerator.Create();
var key = new byte[16];
var iv = new byte[16];

random.GetBytes(key);
random.GetBytes(iv);

Console.WriteLine("================= CRIPTOGRAFANDO =================");

var aes = Aes.Create();
aes.Key = key;
aes.IV = iv;
var ciphertext = aes.EncryptCbc(Encoding.UTF8.GetBytes(message), iv, PaddingMode.PKCS7);

Console.WriteLine($"Mensagem: {message}");
Console.WriteLine($"Password: {Convert.ToHexString(key)}");
Console.WriteLine($"Cipher: {Convert.ToHexString(ciphertext)}");
Console.WriteLine();

Console.WriteLine("================= DESCRIPTOGRAFANDO =================");

Console.WriteLine(Encoding.UTF8.GetString(aes.DecryptCbc(ciphertext, iv, PaddingMode.PKCS7)));
