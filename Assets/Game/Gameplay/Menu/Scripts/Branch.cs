using System;

[Serializable]
public class Branch
{
    public string id = string.Empty;
    public string nombre = string.Empty;
}

[Serializable]
public class BranchList
{
    public Branch[] branchs;
}