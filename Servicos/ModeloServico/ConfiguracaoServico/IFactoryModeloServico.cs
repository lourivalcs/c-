using ModeloServico.ConfiguracaoServico;
using System.Collections.Generic;

namespace ModeloServico
{
    public interface IFactoryModeloServico
    {
        List<ProcessoThread> listaThreads { get; set; }
        void InicializaTodasThreads();
        void InicializaThread(ProcessosThreadModelo processosThreadModelo);
        void FinalizaThread();
    }
}
