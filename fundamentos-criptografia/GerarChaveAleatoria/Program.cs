using System.Security.Cryptography;
using System.Text;

var random = RandomNumberGenerator.Create();
var data = new byte[256];

random.GetBytes(data);

var sb = new StringBuilder("new byte[] { ");

foreach (var item in data)
    sb.Append(item + ", ");

sb.Append("}");

Console.WriteLine(sb.ToString());