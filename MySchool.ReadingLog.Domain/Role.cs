using System;

namespace MySchool.ReadingLog.Domain
{
    [Flags]
    public enum Role
    {
        Admin = 1,
        Parent = 2
    }
}