using System;
using System.Threading;

namespace ModeloServico.Processos
{
    public class ProcessoThread02 : ProcessoThread
    {
        public ProcessoThread02(int tempo) : base(tempo) { }
        public override void Processar()
        {
            System.Diagnostics.Debug.WriteLine($"Processo 02: {DateTime.Now.ToString()}");
            Thread.Sleep(2000);
        }
    }
}
