
namespace Joda.JSON.Testador
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonProcessar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.buttonPesquisar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonProcessar
            // 
            this.buttonProcessar.Location = new System.Drawing.Point(313, 12);
            this.buttonProcessar.Name = "buttonProcessar";
            this.buttonProcessar.Size = new System.Drawing.Size(75, 23);
            this.buttonProcessar.TabIndex = 0;
            this.buttonProcessar.Text = ">>";
            this.buttonProcessar.UseVisualStyleBackColor = true;
            this.buttonProcessar.Click += new System.EventHandler(this.buttonProcessar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(307, 426);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(394, 297);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(307, 103);
            this.textBox2.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(394, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(307, 279);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(394, 418);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(262, 20);
            this.textBox3.TabIndex = 3;
            // 
            // buttonPesquisar
            // 
            this.buttonPesquisar.Location = new System.Drawing.Point(662, 416);
            this.buttonPesquisar.Name = "buttonPesquisar";
            this.buttonPesquisar.Size = new System.Drawing.Size(39, 23);
            this.buttonPesquisar.TabIndex = 4;
            this.buttonPesquisar.Text = "Pesq";
            this.buttonPesquisar.UseVisualStyleBackColor = true;
            this.buttonPesquisar.Click += new System.EventHandler(this.buttonPesquisar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonPesquisar);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonProcessar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonProcessar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button buttonPesquisar;
    }
}

