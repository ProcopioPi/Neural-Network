namespace Test
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.PNL_MAIN = new System.Windows.Forms.Panel();
            this.LBL_LOWEST = new System.Windows.Forms.Label();
            this.LBL_ERROR = new System.Windows.Forms.Label();
            this.LBL_IT = new System.Windows.Forms.Label();
            this.BTN_LEARN = new System.Windows.Forms.Button();
            this.PCT_CANVAS = new System.Windows.Forms.PictureBox();
            this.PNL_MAIN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).BeginInit();
            this.SuspendLayout();
            // 
            // PNL_MAIN
            // 
            this.PNL_MAIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.PNL_MAIN.Controls.Add(this.LBL_LOWEST);
            this.PNL_MAIN.Controls.Add(this.LBL_ERROR);
            this.PNL_MAIN.Controls.Add(this.LBL_IT);
            this.PNL_MAIN.Controls.Add(this.BTN_LEARN);
            this.PNL_MAIN.Controls.Add(this.PCT_CANVAS);
            this.PNL_MAIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNL_MAIN.Location = new System.Drawing.Point(0, 0);
            this.PNL_MAIN.Name = "PNL_MAIN";
            this.PNL_MAIN.Size = new System.Drawing.Size(1151, 716);
            this.PNL_MAIN.TabIndex = 0;
            // 
            // LBL_LOWEST
            // 
            this.LBL_LOWEST.AutoSize = true;
            this.LBL_LOWEST.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_LOWEST.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.LBL_LOWEST.Location = new System.Drawing.Point(12, 365);
            this.LBL_LOWEST.Name = "LBL_LOWEST";
            this.LBL_LOWEST.Size = new System.Drawing.Size(56, 23);
            this.LBL_LOWEST.TabIndex = 4;
            this.LBL_LOWEST.Text = "label1";
            // 
            // LBL_ERROR
            // 
            this.LBL_ERROR.AutoSize = true;
            this.LBL_ERROR.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_ERROR.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.LBL_ERROR.Location = new System.Drawing.Point(12, 342);
            this.LBL_ERROR.Name = "LBL_ERROR";
            this.LBL_ERROR.Size = new System.Drawing.Size(56, 23);
            this.LBL_ERROR.TabIndex = 3;
            this.LBL_ERROR.Text = "label1";
            // 
            // LBL_IT
            // 
            this.LBL_IT.AutoSize = true;
            this.LBL_IT.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_IT.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.LBL_IT.Location = new System.Drawing.Point(12, 184);
            this.LBL_IT.Name = "LBL_IT";
            this.LBL_IT.Size = new System.Drawing.Size(56, 23);
            this.LBL_IT.TabIndex = 2;
            this.LBL_IT.Text = "label1";
            // 
            // BTN_LEARN
            // 
            this.BTN_LEARN.Location = new System.Drawing.Point(23, 104);
            this.BTN_LEARN.Name = "BTN_LEARN";
            this.BTN_LEARN.Size = new System.Drawing.Size(98, 44);
            this.BTN_LEARN.TabIndex = 1;
            this.BTN_LEARN.Text = "XOR - LEARN";
            this.BTN_LEARN.UseVisualStyleBackColor = true;
            this.BTN_LEARN.Click += new System.EventHandler(this.BTN_LEARN_Click);
            // 
            // PCT_CANVAS
            // 
            this.PCT_CANVAS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PCT_CANVAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCT_CANVAS.Location = new System.Drawing.Point(229, 3);
            this.PCT_CANVAS.Name = "PCT_CANVAS";
            this.PCT_CANVAS.Size = new System.Drawing.Size(700, 700);
            this.PCT_CANVAS.TabIndex = 0;
            this.PCT_CANVAS.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 716);
            this.Controls.Add(this.PNL_MAIN);
            this.Name = "Form1";
            this.Text = "Form1";
            this.PNL_MAIN.ResumeLayout(false);
            this.PNL_MAIN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PNL_MAIN;
        private System.Windows.Forms.PictureBox PCT_CANVAS;
        private System.Windows.Forms.Button BTN_LEARN;
        private System.Windows.Forms.Label LBL_LOWEST;
        private System.Windows.Forms.Label LBL_ERROR;
        private System.Windows.Forms.Label LBL_IT;
    }
}

