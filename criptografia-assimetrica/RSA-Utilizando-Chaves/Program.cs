using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

var rsa = RSA.Create();
var mensagem = "estudando criptografia";

var pem = File.ReadAllText("C:\\Users\\yuris\\source\\repos\\public\\csharp\\cryptography\\criptografia-assimetrica\\RSA-Utilizando-Chaves\\rsa-private-key.pem");
rsa.ImportFromPem(pem);

Console.WriteLine("========================== CRIPTOGRAFAR ==========================");

var cypher = rsa.Encrypt(Encoding.UTF8.GetBytes(mensagem), RSAEncryptionPadding.Pkcs1);
Console.WriteLine($"Cypher: {BitConverter.ToString(cypher)}");

Console.WriteLine("========================== DESCRIPTOGRAFAR ==========================");
var clearText = rsa.Decrypt(cypher, RSAEncryptionPadding.Pkcs1);
Console.WriteLine($"Clear Text: {Encoding.UTF8.GetString(clearText)}");

Console.WriteLine("========================== ASSINAR DIGITALMENTE ==========================");

var assinatura = rsa.SignData(Encoding.UTF8.GetBytes(mensagem), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
var documento = new { Mensagem = mensagem, Assinatura = assinatura };
Console.WriteLine($"Documento: {JsonSerializer.Serialize(documento, new JsonSerializerOptions() { WriteIndented = true })}");

Console.WriteLine("========================== VALIDAR ASSINATURA ==========================");

var validarAssinatura = rsa.VerifyData(Encoding.UTF8.GetBytes(mensagem), assinatura, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
Console.WriteLine($"Assinatura está correta: {validarAssinatura}");




Console.WriteLine("========================== CARREGAR CHAVE PÚBLICA ==========================");

// recriamos a RSA importando a chave pública
rsa = RSA.Create();
pem = File.ReadAllText("C:\\Users\\yuris\\source\\repos\\public\\csharp\\cryptography\\criptografia-assimetrica\\RSA-Utilizando-Chaves\\rsa-public-key.pem");
rsa.ImportFromPem(pem);
Console.WriteLine("Utilizando objeto RSA apenas como chave pública");

Console.WriteLine("========================== CRIPTOGRAFAR COM CHAVE PÚBLICA ==========================");

cypher = rsa.Encrypt(Encoding.UTF8.GetBytes(mensagem), RSAEncryptionPadding.Pkcs1);
Console.WriteLine($"Cypher: {BitConverter.ToString(cypher)}");

Console.WriteLine("========================== VALIDAR ASSINATURA COM CHAVE PÚBLICA ==========================");

validarAssinatura = rsa.VerifyData(Encoding.UTF8.GetBytes(mensagem), assinatura, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
Console.WriteLine($"Assinatura está correta: {validarAssinatura}");

Console.WriteLine("========================== TENTAR DESCRIPTOGRAFAR COM CHAVE PÚBLICA ==========================");

try
{
	rsa.Decrypt(cypher, RSAEncryptionPadding.Pkcs1);
}
catch (Exception e)
{
    Console.WriteLine(e);
}

Console.WriteLine("========================== TENTAR ASSINAR COM CHAVE PÚBLICA ==========================");

try
{
    rsa.SignData(Encoding.UTF8.GetBytes(mensagem), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
}
catch (Exception e)
{
    Console.WriteLine(e);
}



