// Este algoritimo não é recomentado para senha, pois é muito performático, e no caso de senhas, precisa ser lento.

using Org.BouncyCastle.Crypto.Digests;
using System.Security.Cryptography;
using System.Text;

var mensagem = "estudando criptografia";
Console.WriteLine("Mensagem: {0}", mensagem);
// dotnet não oferece suporte ao 224.

Console.WriteLine();
Console.WriteLine("============= SHA-3 =============");

var SHA3 = (int bitLenght, string mensagem) =>
{
    var hashAlgorithm = new Sha3Digest(bitLenght);
    var input = Encoding.UTF8.GetBytes(mensagem);

    hashAlgorithm.BlockUpdate(input, 0, input.Length);
    var result = new byte[bitLenght / 8];
    hashAlgorithm.DoFinal(result, 0);

    return Convert.ToHexStringLower(result);
};

Console.WriteLine("SHA3-224: {0}", SHA3(224, mensagem));
Console.WriteLine("SHA3-256: {0}", SHA3(256, mensagem));
Console.WriteLine("SHA3-384: {0}", SHA3(384, mensagem));
Console.WriteLine("SHA3-512: {0}", SHA3(512, mensagem));

Console.WriteLine();
Console.WriteLine("============= SHA-2 =============");
Console.WriteLine("SHA-224: .NET nao oferece suporte nativo ao 224.");

var sha256Hash = SHA256.HashData(Encoding.ASCII.GetBytes(mensagem));
Console.WriteLine("SHA-256: {0}", Convert.ToHexStringLower(sha256Hash));

var sha384Hash = SHA384.HashData(Encoding.ASCII.GetBytes(mensagem));
Console.WriteLine("SHA-384: {0}", Convert.ToHexStringLower(sha384Hash));

var sha512Hash = SHA512.HashData(Encoding.ASCII.GetBytes(mensagem));
Console.WriteLine("SHA-512: {0}", Convert.ToHexStringLower(sha512Hash));

Console.WriteLine();
Console.WriteLine("============= SHA-1 =============");

var sha1Hash = SHA1.HashData(Encoding.ASCII.GetBytes(mensagem));
Console.WriteLine("SHA-1: {0}", Convert.ToHexStringLower(sha1Hash));
