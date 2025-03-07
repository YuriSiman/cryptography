using System;
using System.Security.Cryptography;
using System.Text;

var message = "estudando criptografia";
var hash = new StringBuilder();

var crypto = MD5.HashData(Encoding.UTF8.GetBytes(message));

foreach (var item in crypto)
    hash.Append(item.ToString("x2"));

Console.WriteLine($"Message: {message}");
Console.WriteLine($"Hash: {hash}");