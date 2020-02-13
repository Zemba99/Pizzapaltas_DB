using MsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLib;

namespace Admin_Login_Application
{
    
    public class RepositoryFactory
    {
        private static eBackend Backend { get; set; }
        public static void SelectBackend(eBackend backend)
        {
            Backend = backend;
        }
        public static IRepository Create()
        {
            IRepository repo;
            if (Backend == eBackend.MsSQL)
            {
                repo = new Repository();
            }
            else
            {
                repo = new PgsRepository();
            }
            return repo;
        }
    }
}
