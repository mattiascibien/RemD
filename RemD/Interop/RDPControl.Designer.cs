namespace RemD.Interop
{
    partial class RDPControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RDPControl));
            this.ActiveX = new AxMSTSCLib.AxMsRdpClient9NotSafeForScripting();
            ((System.ComponentModel.ISupportInitialize)(this.ActiveX)).BeginInit();
            this.SuspendLayout();
            // 
            // ActiveX
            // 
            this.ActiveX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActiveX.Enabled = true;
            this.ActiveX.Location = new System.Drawing.Point(0, 0);
            this.ActiveX.Name = "ActiveX";
            this.ActiveX.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ActiveX.OcxState")));
            this.ActiveX.Size = new System.Drawing.Size(630, 461);
            this.ActiveX.TabIndex = 0;
            // 
            // RDPControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ActiveX);
            this.Name = "RDPControl";
            this.Size = new System.Drawing.Size(630, 461);
            ((System.ComponentModel.ISupportInitialize)(this.ActiveX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public AxMSTSCLib.AxMsRdpClient9NotSafeForScripting ActiveX;



    }
}
