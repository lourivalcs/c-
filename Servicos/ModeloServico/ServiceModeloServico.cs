using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ModeloServico
{
    public partial class ServiceModeloServico : ServiceBase
    {

        private FactoryModeloServico factoryModeloServico;

        public ServiceModeloServico()
        {
            InitializeComponent();
            factoryModeloServico = new FactoryModeloServico();
        }

        protected override void OnStart(string[] args)
        {
            Task.Run(() =>
            {
                factoryModeloServico.InicializaTodasThreads();

            }).ContinueWith(t => TaskContinuationOptions.OnlyOnFaulted);
        }

        protected override void OnStop()
        {
            factoryModeloServico.FinalizaThread();
        }
    }
}
