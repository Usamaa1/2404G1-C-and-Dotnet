
using System.Net;

Console.WriteLine("Give me Website URL:");

string WebURL = Console.ReadLine();

Console.WriteLine("Now give the file Name: ");

string fileName = Console.ReadLine();

WebClient client = new WebClient();
string reply = client.DownloadString(WebURL);

Console.WriteLine(reply);


// Set a variable to the Documents path.
string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

// Write the text to a new file named "WriteFile.txt".
File.WriteAllText(Path.Combine(docPath, $"webs/{fileName}"), reply); //Desktop/webs/index.html
