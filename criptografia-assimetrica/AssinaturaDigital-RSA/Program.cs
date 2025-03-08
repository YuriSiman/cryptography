using System.Security.Cryptography;
using System.Text;

var rsa = RSA.Create(2048);
var mensagem = "estudando criptografia";

Console.WriteLine("========================== ASSINAR DIGITALMENTE ==========================");

var assinatura = rsa.SignData(Encoding.UTF8.GetBytes(mensagem), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
Console.WriteLine($"Assinatura: {BitConverter.ToString(assinatura)}");

Console.WriteLine("========================== VALIDAR ASSINATURA ==========================");

var validarAssinatura = rsa.VerifyData(Encoding.UTF8.GetBytes(mensagem), assinatura, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
Console.WriteLine($"Assinatura está correta: {validarAssinatura}");