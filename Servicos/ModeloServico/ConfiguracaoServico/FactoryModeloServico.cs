using ModeloServico.ConfiguracaoServico;
using ModeloServico.Processos;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace ModeloServico
{
    public class FactoryModeloServico : IFactoryModeloServico
    {
        public List<ProcessoThread> listaThreads { get; set; }

        public FactoryModeloServico()
        {
            listaThreads = new List<ProcessoThread>();
        }

        public void InicializaTodasThreads()
        {
            ProcessosThreadModelo processosThreadModelo = new ProcessosThreadModelo();
            List<PropertyInfo> propertyInfo = processosThreadModelo
                                              .GetType()
                                              .GetProperties()
                                              .ToList();

            propertyInfo?.ForEach(p => { p.SetValue(processosThreadModelo, true); });

            InicializaThread(processosThreadModelo);
        }

        public void InicializaThread(ProcessosThreadModelo processosThreadModelo)
        {
            List<ProcessoThread> processoThreads = this.CarregaConfiguracao(processosThreadModelo);

            processoThreads.ForEach(t => { t.IniciaThread(); });

            this.listaThreads.AddRange(processoThreads);
        }

        public void FinalizaThread()
        {
            listaThreads.ForEach(t => t.ShutDown.Cancel(true));
            listaThreads.Clear();
        }

        private List<ProcessoThread> CarregaConfiguracao(ProcessosThreadModelo processosThreadModelo)
        {
            List<ProcessoThread> processoThreads = new List<ProcessoThread>();
            NameValueCollection config;
            int intervalo;

            if (processosThreadModelo.Thread01)
            {
                config = BuscaSecao("thread01");

                if (config != null && config["tempoThread01"] != null)
                {
                    intervalo = int.Parse(config["tempoThread01"]) * 1000;
                    if (intervalo > 0)
                        processoThreads.Add(new ProcessoThread01(intervalo));
                }
            }

            if (processosThreadModelo.Thread02)
            {
                config = BuscaSecao("thread02");

                if (config != null && config["tempoThread02"] != null)
                {
                    intervalo = int.Parse(config["tempoThread02"]) * 1000;
                    if (intervalo > 0)
                        processoThreads.Add(new ProcessoThread02(intervalo));
                }
            }

            return processoThreads;
        }
        private NameValueCollection BuscaSecao(string nomeSecao)
        {
            return (NameValueCollection)ConfigurationManager.GetSection(nomeSecao);
        }
    }
}
