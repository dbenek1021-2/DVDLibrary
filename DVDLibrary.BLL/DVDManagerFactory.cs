using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DVDLibrary.Data;
using DVDLibrary.Data.Repositories;

namespace DVDLibrary.BLL
{
    public static class DVDManagerFactory
    {
        public static DVDManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString(); //where DI is

            switch (mode)
            {
                case "Mock":
                    return new DVDManager(new DVDRepoMock());
                case "ADO":
                    return new DVDManager(new DVDRepoADO());
              //case "EF":
              //    return new DVDManager(new DVDRepoEF());
            }

            throw new Exception("Mode value in app config is not valid!");
        }
    }
}
