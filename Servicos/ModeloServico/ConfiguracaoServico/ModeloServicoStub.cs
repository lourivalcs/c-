using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModeloServico.ConfiguracaoServico
{
    public partial class ModeloServicoStub : Form
    {
        private FactoryModeloServico factoryModeloServico;
        public ModeloServicoStub()
        {
            InitializeComponent();
            factoryModeloServico = new FactoryModeloServico();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            string propertyName = ((Button)sender).Tag.ToString();
            if (propertyName.Equals("Start"))
            {
                factoryModeloServico.InicializaTodasThreads();
                HabilitaDesabilitaBotoes(false);
            }
            else if (propertyName.Equals("Stop"))
            {
                factoryModeloServico.FinalizaThread();
                HabilitaDesabilitaBotoes(true);
            }
            else
            {
                ProcessosThreadModelo processosThreadModelo = new ProcessosThreadModelo();
                processosThreadModelo.GetType()
                                     .GetProperties()
                                     .FirstOrDefault(f => f.Name == propertyName)
                                     .SetValue(processosThreadModelo, true);

                factoryModeloServico.InicializaThread(processosThreadModelo);
                btnStart.Enabled = this.Controls.Cast<Button>().FirstOrDefault(f => f.Tag.ToString() == propertyName).Enabled = false;

                btnStop.Enabled = true;
            }
        }

        private void HabilitaDesabilitaBotoes(bool habilitar)
        {
            foreach(Button btn in this.Controls)
            {
                if (btn.Tag.Equals("Stop"))
                    btn.Enabled = !habilitar;
                else
                    btn.Enabled = habilitar;
            }
        }
    }
}
