using System;
using System.Threading;
using System.Threading.Tasks;

namespace ModeloServico
{
    public abstract class ProcessoThread
    {
        public int Tempo { get; set; }

        public CancellationTokenSource ShutDown { get; set; }

        public ProcessoThread(int tempo)
        {
            this.Tempo = tempo;
            this.ShutDown = new CancellationTokenSource();
        }
        public abstract void Processar();
        public async void IniciaThread()
        {
            while (!ShutDown.IsCancellationRequested)
            {
                try
                {
                    await Task.Run(() =>
                    {
                        Processar();
                        ShutDown.Token.ThrowIfCancellationRequested();
                    });

                    await Task.Delay(Tempo, ShutDown.Token);
                }
                catch (OperationCanceledException)
                {
                    //meter log aqui
                    System.Diagnostics.Debug.WriteLine("ERRO 01: " + DateTime.Now.ToString());
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("ERRO 02: " + DateTime.Now.ToString());
                    //meter log aqui também
                }
            }
        }

    }
}
