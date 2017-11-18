using System;
using System.Collections.Generic;
using System.Text;

namespace CharityHub.Services.Interfaces
{
    public interface ICryptographyService
    {
        string GetHashString(string message);
    }
}
