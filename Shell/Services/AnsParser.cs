using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shell.Models;


namespace Shell.Services
{
    static class AnsParser
    {
        public static bool ParseFile(string filename, out Magnet magnet, out string errorMessage)
        {
            magnet = new Magnet()
            {
                Name = "fool",
                Filename = filename
            };
            errorMessage = string.Empty;
            return true;
        }
    }
}
