﻿using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using RSAExtensions;

//var asNumber = (byte[] byteRep) => new BigInteger(byteRep.Reverse().Concat(new byte[1]).ToArray());

//// Cria o RSA. O algoritmo automaticamente cria uma chave de 2048 bits
//var rsa = RSA.Create(2048);
//var chavePublica = rsa.ExportParameters(false);
//var chavePrivada = rsa.ExportParameters(true);

//// Obtem os parametros como números
//var n = asNumber(chavePublica.Modulus);
//var p = asNumber(chavePrivada.P);
//var q = asNumber(chavePrivada.Q);

//// Criptografar
//var mensagem = "estudando criptografia";
//var cypher = rsa.Encrypt(Encoding.UTF8.GetBytes(mensagem), RSAEncryptionPadding.Pkcs1);

//// Descriptografar
//var clearText = rsa.Decrypt(cypher, RSAEncryptionPadding.Pkcs1);

//Console.ForegroundColor = ConsoleColor.White;
//Console.WriteLine("========================== PARAMETROS DO RSA ==========================");
//Console.WriteLine();
//Console.ResetColor();

//Console.ForegroundColor = ConsoleColor.Magenta;
//Console.WriteLine($"                            CHAVE PUBLICA (e,n):");
//Console.WriteLine();
//Console.ForegroundColor = ConsoleColor.DarkYellow;
//Console.Write("Expoente (e) = ");
//Console.ForegroundColor = ConsoleColor.Green;
//Console.WriteLine(asNumber(chavePublica.Exponent));
//Console.ForegroundColor = ConsoleColor.DarkYellow;
//Console.Write("Modulo   (n) = ");
//Console.ForegroundColor = ConsoleColor.Blue;
//Console.WriteLine(n);
//Console.ResetColor();

//Console.WriteLine();
//Console.WriteLine(rsa.ExportPublicKey(RSAKeyType.Pkcs1, true));

//Console.ForegroundColor = ConsoleColor.Magenta;
//Console.WriteLine($"                            CHAVE PRIVADA (d,n):");
//Console.WriteLine();
//Console.ForegroundColor = ConsoleColor.DarkYellow;
//Console.Write("Expoente privado (d) = ");
//Console.ForegroundColor = ConsoleColor.Red;
//Console.WriteLine(asNumber(chavePrivada.D));
//Console.ForegroundColor = ConsoleColor.DarkYellow;
//Console.Write("Inverso D            = ");
//Console.ForegroundColor = ConsoleColor.Red;
//Console.WriteLine(asNumber(chavePrivada.InverseQ));
//Console.ForegroundColor = ConsoleColor.DarkYellow;
//Console.Write("Modulo           (n) = ");
//Console.ForegroundColor = ConsoleColor.Blue;
//Console.WriteLine(n);
//Console.ResetColor();

//Console.WriteLine();
//Console.WriteLine(rsa.ExportPrivateKey(RSAKeyType.Pkcs1, true));
//Console.WriteLine();



//Console.ForegroundColor = ConsoleColor.White;
//Console.WriteLine("========================== VALIDANDO OS PARAMETROS ==========================");
//Console.ResetColor();

//Console.WriteLine();
//Console.Write($"Primo 1 (p) = ");
//Console.ForegroundColor = ConsoleColor.Cyan;
//Console.WriteLine(p);
//Console.ResetColor();
//Console.WriteLine();
//Console.Write($"Primo 2 (q) = ");
//Console.ForegroundColor = ConsoleColor.Cyan;
//Console.WriteLine(q);
//Console.ResetColor();
//Console.WriteLine();
//Console.Write($"Modulo  (n) = ");
//Console.ForegroundColor = ConsoleColor.Blue;
//Console.WriteLine(n);
//Console.ResetColor();

//Console.WriteLine();
//Console.WriteLine($"p * q = n ? {p * q == n}");
//Console.WriteLine();


//Console.ForegroundColor = ConsoleColor.White;
//Console.WriteLine("========================== CRIPTOGRAFAR ==========================");
//Console.ResetColor();

//Console.Write($"Cypher: ");
//Console.ForegroundColor = ConsoleColor.Magenta;
//Console.WriteLine(Convert.ToHexStringLower(cypher));
//Console.WriteLine();
//Console.ForegroundColor = ConsoleColor.White;



//Console.ForegroundColor = ConsoleColor.White;
//Console.WriteLine("========================== DESCRIPTOGRAFAR ==========================");
//Console.ResetColor();

//Console.Write($"Clear Text: ");
//Console.ForegroundColor = ConsoleColor.Yellow;
//Console.WriteLine(Encoding.UTF8.GetString(clearText));
//Console.ResetColor();


// PROCESSO SIMPLIFICADO (SEM TODOS OS CONSOLES)
// Durante cada execução do RSA conforme abaixo, ele irá gerar novas chaves para poder criptografar e descriptografar,
// com isso, este é apenas um exemplo de como utilizar, não sendo utilizado dessa forma no mundo real

var rsa = RSA.Create(2048);
var mensagem = "estudando criptografia";

Console.WriteLine("========================== CRIPTOGRAFAR ==========================");

var cypher = rsa.Encrypt(Encoding.UTF8.GetBytes(mensagem), RSAEncryptionPadding.Pkcs1);
Console.WriteLine($"Cypher: {BitConverter.ToString(cypher)}");

Console.WriteLine("========================== DESCRIPTOGRAFAR ==========================");
var clearText = rsa.Decrypt(cypher, RSAEncryptionPadding.Pkcs1);
Console.WriteLine($"Clear Text: {Encoding.UTF8.GetString(clearText)}");