using System.Security.Cryptography;
using System.Text;
using System.Text.Json;


var mensagem = "estudando criptografia";
var chavePrivadaSimetrica = new byte[16];
var initializationVector = new byte[12];
var authTag = new byte[16];

// Gera a chave e o iv
RandomNumberGenerator.Fill(chavePrivadaSimetrica);
RandomNumberGenerator.Fill(initializationVector);

// ========================== CRIPTOGRAFAR MENSAGEM COM AES ==========================
Console.WriteLine("========================== CRIPTOGRAFAR ==========================");
Console.WriteLine($"Mensagem: {mensagem}");

// Converte a mensagem para bytes
var plainBytes = Encoding.UTF8.GetBytes(mensagem);
var cypher = new byte[plainBytes.Length];

// Criptografar com AES (criptografia simétrica)
using (var aesGcm = new AesGcm(chavePrivadaSimetrica, 16))
    aesGcm.Encrypt(initializationVector, plainBytes, cypher, authTag);

// ========================== CRIPTOGRAFAR CHAVE PRIVADA SIMÉTRICA COM RSA (chave pública) ==========================

// Criptografar a chave privata (simétrica AES) com a chave pública (assimétrica RSA)
var rsa = RSA.Create();
var pem = File.ReadAllText("C:\\Users\\yuris\\source\\repos\\public\\csharp\\cryptography\\criptografia-assimetrica\\RSA-Utilizando-Chaves\\rsa-public-key.pem");
rsa.ImportFromPem(pem);
var senha = rsa.Encrypt(chavePrivadaSimetrica, RSAEncryptionPadding.Pkcs1);

var conteudoCriptografia = new
{
    cypher,
    initializationVector,
    authTag,
    senha
};

Console.WriteLine(JsonSerializer.Serialize(conteudoCriptografia, new JsonSerializerOptions() { WriteIndented = true }));


Console.WriteLine("========================== DESCRIPTOGRAFAR ==========================");
// ========================== DESCRIPTOGRAFAR SENHA COM CHAVE PRIVADA (assimétrica RSA) ==========================

// Descriptografar a senha com a chave privada (assimétrica RSA)
rsa = RSA.Create();
pem = File.ReadAllText("C:\\Users\\yuris\\source\\repos\\public\\csharp\\cryptography\\criptografia-assimetrica\\RSA-Utilizando-Chaves\\rsa-private-key.pem");
rsa.ImportFromPem(pem);
var senhaOriginal = rsa.Decrypt(conteudoCriptografia.senha, RSAEncryptionPadding.Pkcs1);

// ========================== DESCRIPTOGRAFAR MENSAGEM COM CHAVE PRIVADA (simétrica AES) ==========================

var decryptedBytes = new byte[cypher.Length];

using (var aesGcm = new AesGcm(senhaOriginal, 16))
    aesGcm.Decrypt(conteudoCriptografia.initializationVector, conteudoCriptografia.cypher, conteudoCriptografia.authTag, decryptedBytes);

var decryptedText = Encoding.UTF8.GetString(decryptedBytes);
Console.WriteLine($"Mensagem: {decryptedText}");
