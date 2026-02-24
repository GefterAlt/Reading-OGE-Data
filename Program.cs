using System.Linq.Expressions;
using System.Security.AccessControl;

namespace Reading_OGE_Data;

class Program
{
    static void Main(string[] args)
    {
        List<AccessItem> items = read();
        var inactiveItems = from item in items
                            where item.cloudLifecycleState == false
                            group item by item.displayName into userAccesses
                            orderby userAccesses.Key ascending
                            select userAccesses;
        Console.Write("inactive records: ");
        Console.WriteLine(inactiveItems.Count());
        IEnumerable<string> inactiveUsers = from item in items
                                            where item.cloudLifecycleState == false
                                            select item.displayName;
        Console.WriteLine("inactive users: ");
        foreach (string s in inactiveUsers.Distinct())
        {
            Console.WriteLine(s);
        }
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
                if (tempArr[4] == "active")
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
