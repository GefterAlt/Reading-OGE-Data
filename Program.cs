using System.Linq.Expressions;
using System.Security.AccessControl;

namespace Reading_OGE_Data;

class Program
{
    static void Main(string[] args)
    {
        List<AccessItem> items = new List<AccessItem>();
        IEnumerable<AccessItem> inactiveItems = from item in items
                                                where item.cloudLifecycleState.Equals("ACTIVE")
                                                select item;
        Console.WriteLine(inactiveItems.Count());
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
            bool tempBool2;
            line = sr.ReadLine();
            line = sr.ReadLine();
            while (line != null)
            {
                tempArr = line.Split(",");
                if (tempArr[6] == "TRUE")
                {
                    tempBool = true;
                }
                else { tempBool = false; }
                if (tempArr[4] == "ACTIVE")
                {
                    tempBool2 = true;
                }
                else { tempBool2 = false; }
                AccessItem currentItem = new AccessItem(tempArr[0], tempArr[1], tempArr[2], tempArr[3], tempBool2, tempArr[5], tempBool, tempArr[7], tempArr[8], tempArr[9], tempArr[10], tempArr[11], tempArr[12], tempArr[13]);
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
