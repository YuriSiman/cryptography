// Algoritmo mais recomendado para senhas, pois é muito lento

using Sodium;

var password = "estudando criptografia";
var hash = PasswordHash.ArgonHashString(password, PasswordHash.StrengthArgon.Moderate);

Console.WriteLine($"Message: {password}");
Console.WriteLine($"Hash: {hash}");