using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileService
{
    public partial class CSVFileService : ServiceBase
    {
        private CSVFileServer.CSVFileServer server;

        public CSVFileService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            server = new CSVFileServer.CSVFileServer();
        }

        protected override void OnStop()
        {
            server = null;
        }
    }
}
