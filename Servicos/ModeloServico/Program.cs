using ModeloServico.ConfiguracaoServico;
using System.Diagnostics;
using System.ServiceProcess;

namespace ModeloServico
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            if (Debugger.IsAttached)
            {
                System.Windows.Forms.Application.Run(new ModeloServicoStub());
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new ServiceModeloServico()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
