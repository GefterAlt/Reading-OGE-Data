using System.Security.AccessControl;

namespace Reading_OGE_Data;

class Program
{
    static void Main(string[] args)
    {

    }

    public static List<AccessItem> read()
    {
        List<AccessItem> accesses = new List<AccessItem>();
        try
        {
            using StreamReader sr = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + "/ft_identities_basic.csv");
            string? line;
            string[] tempArr;
            bool tempBool;
            line = sr.ReadLine();
            line = sr.ReadLine();
            while (line != null)
            {
                tempArr = line.Split(",");
                if (tempArr[7] == "ACTIVE")
                {
                    tempBool = true;
                }
                else { tempBool = false; }
                AccessItem currentItem = new AccessItem(tempArr[0], tempArr[1], tempArr[2], tempArr[3], tempArr[4], tempArr[5], tempBool, tempArr[7], tempArr[8], tempArr[9], tempArr[10], tempArr[11], tempArr[12], tempArr[13]);
                accesses.Add(currentItem);
                line = sr.ReadLine();
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        return accesses;
    }
}
