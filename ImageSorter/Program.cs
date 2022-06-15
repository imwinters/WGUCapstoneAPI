
Console.WriteLine("Categorizing Target Training Files...");

string[] fileInfo = File.ReadAllLines("C:/Users/isaac/repos/Capstone/archive (1)/test/test.txt"); 
// File.ReadAllLines("C:/Users/isaac/repos/Capstone/archive (1)/train/train.txt");

var positiveFiles = new HashSet<string>(); 

//foreach (string file in fileInfo)
//{
//    var fileParts = file.Split(" ");

//    if (fileParts[2] == "positive")
//    {
//        positiveFiles.Add(fileParts[1]);
//    }
//}

//Console.WriteLine($"There are {positiveFiles.Count()} positive files.");

//foreach(var file in Directory.GetFiles("C:/Users/isaac/repos/Capstone/archive (1)/train"))
//{
//    var trimmedString = file.Replace("C:/Users/isaac/repos/Capstone/archive (1)/train\\", "");
//    if (positiveFiles.Contains(trimmedString))
//    {
//        File.Move(file, $"C:/Users/isaac/repos/Capstone/archive (1)/organized/train/positive/{trimmedString}");
//    }
//    else
//    {
//        File.Move(file, $"C:/Users/isaac/repos/Capstone/archive (1)/organized/train/negative/{trimmedString}");
//    }
//}

fileInfo = File.ReadAllLines("C:/Users/isaac/repos/Capstone/archive (1)/test/test.txt");

positiveFiles = new HashSet<string>();

foreach (string file in fileInfo)
{
    var fileParts = file.Split(" ");

    if (fileParts[2] == "positive")
    {
        positiveFiles.Add(fileParts[1]);
    }
}

Console.WriteLine($"There are {positiveFiles.Count()} positive files.");

foreach (var file in Directory.GetFiles("C:/Users/isaac/repos/Capstone/archive (1)/test"))
{
    var trimmedString = file.Replace("C:/Users/isaac/repos/Capstone/archive (1)/test\\", "");
    if (positiveFiles.Contains(trimmedString))
    {
        File.Move(file, $"C:/Users/isaac/repos/Capstone/archive (1)/organized/test/positive/{trimmedString}");
    }
    else
    {
        File.Move(file, $"C:/Users/isaac/repos/Capstone/archive (1)/organized/test/negative/{trimmedString}");
    }
}

Console.WriteLine("Files moved!");
