namespace Reading_OGE_Data;

public struct AccessItem
{
    public readonly string displayName;
    public readonly string firstName;
    public readonly string lastName;
    public readonly string workMail;
    public readonly string cloudLifecycleState;
    public readonly string identityID;
    public readonly bool isManager;
    public readonly string department;
    public readonly string jobTitle;
    public readonly string userID;
    public readonly string accessType;
    public readonly string accessSourceName;
    public readonly string accessDisplayName;
    public readonly string accessDescription;

    public AccessItem(string dN, string fN, string lN, string m, string cls, string id, bool isM, string dept, string jT, string uid, string aT, string aSN, string aDisN, string aDsc)
    {
        displayName = dN;
        firstName = fN;
        lastName = lN;
        workMail = m;
        cloudLifecycleState = cls;
        identityID = id;
        isManager = isM;
        department = dept;
        jobTitle = jT;
        userID = uid;
        accessType = aT;
        accessSourceName = aSN;
        accessDisplayName = aDisN;
        accessDescription = aDsc;
    }
}