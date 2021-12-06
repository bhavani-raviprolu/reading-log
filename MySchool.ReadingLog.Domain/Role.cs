using System;

namespace MySchool.ReadingLog.Domain
{
    [Flags]
    public enum Role
    {
        Admin = 0,
        Parent = 1
    }
}