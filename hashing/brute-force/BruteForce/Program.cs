//#r "nuget: Blake3, 0.5.0"

using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Sodium;

long _time = 20_000;

var hashMD5 = (string password, out double totaltime, out int count) =>
{
    var seconds = Stopwatch.StartNew();
    var hashCount = 0;
    var bytes = Encoding.ASCII.GetBytes(password);
    do
    {
        MD5.HashData(bytes);
        hashCount++;
    } while (seconds.ElapsedMilliseconds < _time);

    seconds.Stop();
    totaltime = seconds.Elapsed.TotalSeconds;
    count = hashCount;
};

//var Blake = (string password, out double totaltime, out int count) =>
//{
//    var seconds = Stopwatch.StartNew();
//    var hashCount = 0;
//    var bytes = Encoding.ASCII.GetBytes(password);

//    do
//    {
//        //Blake3.Hasher.Hash(bytes);
//        hashCount++;
//    } while (seconds.ElapsedMilliseconds < _time);

//    seconds.Stop();
//    totaltime = seconds.Elapsed.TotalSeconds;
//    count = hashCount;
//};

var hashSha256 = (string password, out double totaltime, out int count) =>
{
    var bytes = Encoding.ASCII.GetBytes(password);

    var seconds = Stopwatch.StartNew();
    var hashCount = 0;
    do
    {
        SHA256.HashData(bytes);
        hashCount++;
    } while (seconds.ElapsedMilliseconds < _time);

    seconds.Stop();
    totaltime = seconds.Elapsed.TotalSeconds;
    count = hashCount;
};

var Argon2 = (string password, out double totaltime, out int count) =>
{
    var seconds = Stopwatch.StartNew();
    var hashCount = 0;
    do
    {
        PasswordHash.ArgonHashString(password, PasswordHash.StrengthArgon.Moderate);
        hashCount++;
    } while (seconds.ElapsedMilliseconds < _time);

    seconds.Stop();
    totaltime = seconds.Elapsed.TotalSeconds;
    count = hashCount;
};


double seconds = 0;
var hashCount = 0;

var password = "Sup3rSecr3t";
Console.WriteLine($"Quantas senhas podem ser hasheadas em 20 segundos?");
Console.WriteLine();
Console.WriteLine("========================================");
Console.WriteLine("            MD5 hashes");
hashMD5(password, out seconds, out hashCount);
Console.WriteLine($"MD5: {hashCount:N}");

Console.WriteLine();
Console.WriteLine("========================================");
Console.WriteLine("            SHA256 hashes");

hashSha256(password, out seconds, out hashCount);
Console.WriteLine($"SHA256: {hashCount:N}");

//Console.WriteLine();
//Console.WriteLine("========================================");
//Console.WriteLine("            BLAKE hashes");

//Blake(password, out seconds, out hashCount);
//Console.WriteLine($"Blake3: {hashCount:N}");

Console.WriteLine();
Console.WriteLine("========================================");
Console.WriteLine("            Argon2 hashes");

Argon2(password, out seconds, out hashCount);
Console.WriteLine($"Argon2: {hashCount:N}");