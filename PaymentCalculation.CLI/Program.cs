using PaymentCalculation.Base.Entities.Abstract;
using PaymentCalculation.Base.Entities.Concrete;
using PaymentCalculation.Base.Methods.Concrete;
using PaymentCalculation.CLI.FakeData;
using System.Runtime.CompilerServices;

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("     [Version 1.0]                      Press Enter to begin...");
Console.WriteLine("██████╗  █████╗ ██╗   ██╗██████╗  ██████╗ ██╗     ██╗         ███████╗██╗   ██╗███████╗████████╗███████╗███╗   ███╗");
Console.WriteLine("██╔══██╗██╔══██╗╚██╗ ██╔╝██╔══██╗██╔═══██╗██║     ██║         ██╔════╝╚██╗ ██╔╝██╔════╝╚══██╔══╝██╔════╝████╗ ████║");
Console.WriteLine("██████╔╝███████║ ╚████╔╝ ██████╔╝██║   ██║██║     ██║         ███████╗ ╚████╔╝ ███████╗   ██║   █████╗  ██╔████╔██║");
Console.WriteLine("██╔═══╝ ██╔══██║  ╚██╔╝  ██╔══██╗██║   ██║██║     ██║         ╚════██║  ╚██╔╝  ╚════██║   ██║   ██╔══╝  ██║╚██╔╝██║");
Console.WriteLine("██║     ██║  ██║   ██║   ██║  ██║╚██████╔╝███████╗███████╗    ███████║   ██║   ███████║   ██║   ███████╗██║ ╚═╝ ██║");
Console.WriteLine("╚═╝     ╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚══════╝    ╚══════╝   ╚═╝   ╚══════╝   ╚═╝   ╚══════╝╚═╝     ╚═╝");
Console.WriteLine("                                                                                                                    ");
Console.WriteLine("           ▄████▄   ▄▄▄       ██▓     ▄████▄   █    ██  ██▓    ▄▄▄     ▄▄▄█████▓ ▒█████   ██▀███                  ");
Console.WriteLine("          ▒██▀ ▀█  ▒████▄    ▓██▒    ▒██▀ ▀█   ██  ▓██▒▓██▒   ▒████▄   ▓  ██▒ ▓▒▒██▒  ██▒▓██ ▒ ██▒                ");
Console.WriteLine("          ▒▓█    ▄ ▒██  ▀█▄  ▒██░    ▒▓█    ▄ ▓██  ▒██░▒██░   ▒██  ▀█▄ ▒ ▓██░ ▒░▒██░  ██▒▓██ ░▄█ ▒                ");
Console.WriteLine("          ▒▓▓▄ ▄██▒░██▄▄▄▄██ ▒██░    ▒▓▓▄ ▄██▒▓▓█  ░██░▒██░   ░██▄▄▄▄██░ ▓██▓ ░ ▒██   ██░▒██▀▀█▄                  ");
Console.WriteLine("          ▒ ▓███▀ ░ ▓█   ▓██▒░██████▒▒ ▓███▀ ░▒▒█████▓ ░██████▒▓█   ▓██▒ ▒██▒ ░ ░ ████▓▒░░██▓ ▒██▒                ");
Console.WriteLine("          ░ ░▒ ▒  ░ ▒▒   ▓▒█░░ ▒░▓  ░░ ░▒ ▒  ░░▒▓▒ ▒ ▒ ░ ▒░▓  ░▒▒   ▓▒█░ ▒ ░░   ░ ▒░▒░▒░ ░ ▒▓ ░▒▓░                ");
Console.WriteLine("            ░  ▒     ▒   ▒▒ ░░ ░ ▒  ░  ░  ▒   ░░▒░ ░ ░ ░ ░ ▒  ░ ▒   ▒▒ ░   ░      ░ ▒ ▒░   ░▒ ░ ▒░                ");
Console.WriteLine("          ░          ░   ▒     ░ ░   ░         ░░░ ░ ░   ░ ░    ░   ▒    ░      ░ ░ ░ ▒    ░░   ░                 ");
Console.WriteLine("          ░ ░            ░  ░    ░  ░░ ░         ░         ░  ░     ░  ░            ░ ░     ░                     ");
Console.WriteLine("          ░                         ░                                                                              ");
Console.ResetColor();

string currentDir = Directory.GetCurrentDirectory();
string projectDir = Path.GetFullPath(Path.Combine(currentDir, @"..\..\..\"));
string fakeDataDir = Path.Combine(projectDir, "FakeData");
if (!Directory.Exists(fakeDataDir))
{
    Directory.CreateDirectory(fakeDataDir);
}
string path = Path.Combine(fakeDataDir, "personnel.json");
if (!File.Exists(path))
{
    var fakePersonnelList = PersonnelGenerator.GeneratePersonnelList(100);
    PersonnelGenerator.SaveToJsonFile(fakePersonnelList, path);
    Console.WriteLine($"100 fake personnel records saved to {path}");
}
Console.WriteLine($"File already exists at {path}. Skipping creation.");

void DisplayMenu()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\n╔═════════════════════════════════════════════════════╗");
    Console.WriteLine("║                PAYROLL SYSTEM MENU                  ║");
    Console.WriteLine("╠═════════════════════════════════════════════════════╣");
    Console.WriteLine("║ 1. List All Personnel                               ║");
    Console.WriteLine("║ 2. Calculate Payroll for Current Month              ║");
    Console.WriteLine("║ 3. List All Payrolls                                ║");
    Console.WriteLine("║ 4. Exit                                             ║");
    Console.WriteLine("╚═════════════════════════════════════════════════════╝");
    Console.ResetColor();
}

bool exit = false;
FileHandler fileHandler = new FileHandler();
PaymentCalc paymentCalc = new PaymentCalc();
while (!exit)
{
    DisplayMenu();

    Console.Write("\nEnter your choice (1-3): ");
    ConsoleKeyInfo keyInfo = Console.ReadKey();
    string choice = keyInfo.KeyChar.ToString();
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            ListAllPersonnel(path);
            break;
        case "2":
            CalculatePayroll(path);
            break;
        case "3":
            ListAllPayrolls();
            break;
        case "4":
            exit = true;
            break;
        default:
            Console.WriteLine("\nInvalid choice. Please try again.");
            Thread.Sleep(1500);
            break;
    }
}

void ListAllPersonnel(string filePath)
{
    var readFile = fileHandler.ReadJson(filePath);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
    Console.WriteLine("║                                                    PERSONNEL LIST                                                         ║");
    Console.WriteLine("╠════════════════════════╦═══════════════════════════╦═════════════════╦════════════════════╦═════════════╦═════════════════╣");
    Console.WriteLine("║         Name           ║          Title            ║  Employment Date║    Birth Date      ║ Work Hours  ║   Hourly Rate   ║");
    Console.WriteLine("╠════════════════════════╬═══════════════════════════╬═════════════════╬════════════════════╬═════════════╬═════════════════╣");
    foreach (var person in readFile.administrators)
    {


        Console.WriteLine($"║ {person.FullName,-22} ║ {person.Title,-25} ║ {person.EmploymentDate.ToString("yyyy-MM-dd"),-15} ║ {person.Birthday.ToString("yyyy-MM-dd"),-18} ║ {person.WorkHours,-11} ║ ${person.PerHourRate,-14:F2} ║");


    }
    foreach (var person in readFile.officers)
    {


        Console.WriteLine($"║ {person.FullName,-22} ║ {person.Title,-25} ║ {person.EmploymentDate.ToString("yyyy-MM-dd"),-15} ║ {person.Birthday.ToString("yyyy-MM-dd"),-18} ║ {person.WorkHours,-11} ║ ${person.PerHourRate,-14:F2} ║");


    }
    Console.WriteLine("╚════════════════════════╩═══════════════════════════╩═════════════════╩════════════════════╩═══════════╩═══════════════════╝");
    Console.ResetColor();

    Console.WriteLine("\nPress any key to return to the main menu...");
    Console.ReadKey();
}

void CalculatePayroll(string filePath)
{
    var readFile = fileHandler.ReadJson(filePath);
    var result = paymentCalc.CalculatePayroll(readFile.officers, readFile.administrators);
    fileHandler.WriteJson(result.officers, result.administrators);
}

void ListAllPayrolls()
{
    string currentDir = Directory.GetCurrentDirectory();
    string projectDir = Path.GetFullPath(Path.Combine(currentDir, @"..\..\..\"));
    string payrollData = Path.Combine(projectDir, "PayrollData");

    // Eğer klasör varsa
    if (Directory.Exists(payrollData))
    {
        // Tüm .json uzantılı dosyaları buluyoruz
        string[] jsonFiles = Directory.GetFiles(payrollData, "*.json");

        if (jsonFiles.Length == 0)
        {
            Console.WriteLine("There are no payroll data as of now");
            Console.ReadLine();
            return;
        }

        List<string> fileNames = new List<string>();
        Console.WriteLine("Payroll Data:");

        for (int i = 0; i < jsonFiles.Length; i++)
        {
            string fileName = Path.GetFileName(jsonFiles[i]);
            fileNames.Add(fileName);
            Console.WriteLine($"{i + 1}. {fileName}");
        }

        Console.WriteLine("\nPlease select a file (1-{0}):", jsonFiles.Length);

        int selection;
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (char.IsDigit(keyInfo.KeyChar) &&
                int.TryParse(keyInfo.KeyChar.ToString(), out selection) &&
                selection >= 1 &&
                selection <= jsonFiles.Length)
            {
                Console.WriteLine($"\nPressed key: {keyInfo.KeyChar}");
                string selectedFile = jsonFiles[selection - 1];
                Console.WriteLine($"\nSeçilen dosya: {fileNames[selection - 1]}");
                string filePath = Path.Combine(payrollData, fileNames[selection - 1]);
                var result = fileHandler.ReadJson(filePath);
                DisplayPersonnelWithPayment(result.officers, result.administrators);
                break;
            }
            else
            {
                Console.WriteLine($"\nPlease enter a number between 1 and {jsonFiles.Length}:");
            }
        }
    }
    else
    {
        Console.WriteLine("PayrollData file does not exist.");
    }

    Console.WriteLine("\nPlease enter any key to exit...");
    Console.ReadKey();
}

static void DisplayPersonnelWithPayment(ICollection<Officer> officers,
            ICollection<Administrator> administrators)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
    Console.WriteLine("║                                                    PERSONNEL LIST                                                                         ║");
    Console.WriteLine("╠════════════════════════╦═══════════════════════════╦═════════════════╦════════════════════╦═════════════╦═════════════════╦═══════════════╣");
    Console.WriteLine("║         Name           ║          Title            ║  Employment Date║    Birth Date      ║ Work Hours  ║   Hourly Rate   ║    Payment    ║");
    Console.WriteLine("╠════════════════════════╬═══════════════════════════╬═════════════════╬════════════════════╬═════════════╬═════════════════╬═══════════════╣");

    // Administrators için ödeme bilgisi gösterme
    foreach (var person in administrators)
    {
        // JSON'da zaten olan Payment değeri alınıyor
        Console.WriteLine($"║ {person.FullName,-22} ║ {person.Title,-25} ║ {person.EmploymentDate.ToString("yyyy-MM-dd"),-15} ║ {person.Birthday.ToString("yyyy-MM-dd"),-18} ║ {person.WorkHours,-11} ║ ${person.PerHourRate,-14:F2} ║ ${person.Payment,-12:F2} ║");
    }

    // Officers için ödeme bilgisi gösterme
    foreach (var person in officers)
    {
        // JSON'da zaten olan Payment değeri alınıyor
        Console.WriteLine($"║ {person.FullName,-22} ║ {person.Title,-25} ║ {person.EmploymentDate.ToString("yyyy-MM-dd"),-15} ║ {person.Birthday.ToString("yyyy-MM-dd"),-18} ║ {person.WorkHours,-11} ║ ${person.PerHourRate,-14:F2} ║ ${person.Payment,-12:F2} ║");
    }

    Console.WriteLine("╚════════════════════════╩═══════════════════════════╩═════════════════╩════════════════════╩═════════════╩═════════════════╩═══════════════╝");
    Console.ResetColor();
    Console.WriteLine("\nAna menüye dönmek için herhangi bir tuşa basın...");
    Console.ReadKey();
}

