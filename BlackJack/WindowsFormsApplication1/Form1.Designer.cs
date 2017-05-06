namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnGioca = new System.Windows.Forms.Button();
            this.lblBlackJack = new System.Windows.Forms.Label();
            this.btnStatistichePartite = new System.Windows.Forms.Button();
            this.cartaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cartaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGioca
            // 
            this.btnGioca.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGioca.Location = new System.Drawing.Point(269, 109);
            this.btnGioca.Name = "btnGioca";
            this.btnGioca.Size = new System.Drawing.Size(120, 31);
            this.btnGioca.TabIndex = 0;
            this.btnGioca.Text = "Nuova Partita";
            this.btnGioca.UseVisualStyleBackColor = false;
            // 
            // lblBlackJack
            // 
            this.lblBlackJack.AutoSize = true;
            this.lblBlackJack.BackColor = System.Drawing.Color.Transparent;
            this.lblBlackJack.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.lblBlackJack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblBlackJack.Location = new System.Drawing.Point(214, 9);
            this.lblBlackJack.Name = "lblBlackJack";
            this.lblBlackJack.Size = new System.Drawing.Size(240, 55);
            this.lblBlackJack.TabIndex = 1;
            this.lblBlackJack.Text = "BlackJack";
            // 
            // btnStatistichePartite
            // 
            this.btnStatistichePartite.Location = new System.Drawing.Point(269, 147);
            this.btnStatistichePartite.Name = "btnStatistichePartite";
            this.btnStatistichePartite.Size = new System.Drawing.Size(120, 31);
            this.btnStatistichePartite.TabIndex = 2;
            this.btnStatistichePartite.Text = "Statistiche partite";
            this.btnStatistichePartite.UseVisualStyleBackColor = true;
            this.btnStatistichePartite.Click += new System.EventHandler(this.btnStatistichePartite_Click);
            // 
            // cartaBindingSource
            // 
            this.cartaBindingSource.DataSource = typeof(WindowsFormsApplication1.Carta);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(698, 424);
            this.Controls.Add(this.btnStatistichePartite);
            this.Controls.Add(this.lblBlackJack);
            this.Controls.Add(this.btnGioca);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form1";
            this.Text = "BlackJack";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cartaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGioca;
        private System.Windows.Forms.BindingSource cartaBindingSource;
        private System.Windows.Forms.Label lblBlackJack;
        private System.Windows.Forms.Button btnStatistichePartite;
    }
}

