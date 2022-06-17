using System;

namespace MySchool.ReadingLog.Domain
{
    [Flags]
    public enum Role
    {
        None = 0,
        Admin = 1,
        Parent = 2
    }
}