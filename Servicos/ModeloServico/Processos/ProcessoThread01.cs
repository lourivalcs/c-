using System;
using System.Threading;

namespace ModeloServico.Processos
{
    public class ProcessoThread01 : ProcessoThread
    {
        public ProcessoThread01(int tempo) : base(tempo) { }        
        public override void Processar()
        {
            System.Diagnostics.Debug.WriteLine($"Processo 01: {DateTime.Now.ToString()}");
            Thread.Sleep(4000);
        }
    }
}
