﻿namespace ModeloServico
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstallerModeloServico = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstallerModeloServico = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstallerModeloServico
            // 
            this.serviceProcessInstallerModeloServico.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstallerModeloServico.Password = null;
            this.serviceProcessInstallerModeloServico.Username = null;
            // 
            // serviceInstallerModeloServico
            // 
            this.serviceInstallerModeloServico.Description = "Descrição do serviço";
            this.serviceInstallerModeloServico.DisplayName = "Modelo Servico";
            this.serviceInstallerModeloServico.ServiceName = "Modelo Servico";
            this.serviceInstallerModeloServico.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstallerModeloServico,
            this.serviceInstallerModeloServico});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstallerModeloServico;
        private System.ServiceProcess.ServiceInstaller serviceInstallerModeloServico;
    }
}