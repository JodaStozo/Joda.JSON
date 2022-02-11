using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joda.JSON.Testador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Arvore minhArvore;
        private void buttonProcessar_Click(object sender, EventArgs e)
        {
            Joda.JSON.ParObj meuPar = new Joda.JSON.ParObj();
            meuPar.Nome = "Json";
            meuPar.Deserealizar(this.textBox1.Text);
            this.textBox2.Text = string.Empty;
            this.treeView1.Nodes.Clear();
            foreach (JSON.ParBase valorLido in meuPar.Valor)
            {
                this.textBox2.Text += "\r\n";
                this.textBox2.Text += string.Format("{0} = {1}", valorLido.Nome, valorLido.Valor);

                TreeNode meuNo = new TreeNode();
                meuNo.Text = valorLido.Nome;
                meuNo.Tag = valorLido;
                this.treeView1.Nodes.Add(meuNo);
                povoar(meuNo);
            }
            minhArvore = new JSON.Arvore(this.textBox1.Text);

            this.textBox2.Text += "Arvore de dados povoada com sucesso";
            this.textBox3.Enabled = true;
            this.buttonPesquisar.Enabled = true;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Joda.JSON.ParBase meuTag = (Joda.JSON.ParBase)e.Node.Tag;
            this.textBox2.Text = meuTag.Valor.ToString();
        }
        private void povoar(TreeNode meuNo)
        {
            Joda.JSON.ParBase meuTag = (Joda.JSON.ParBase)meuNo.Tag;
            String s = meuTag.Valor.ToString().Trim();
            if (s.StartsWith("{"))
            {
                Joda.JSON.ParObj meuPar = new Joda.JSON.ParObj();
                meuPar.Nome = meuTag.Nome;
                meuPar.Deserealizar(s);
                meuNo.Nodes.Clear();
                foreach (JSON.ParBase valorLido in meuPar.Valor)
                {
                    TreeNode novoNo = new TreeNode();
                    novoNo.Text = valorLido.Nome;
                    novoNo.Tag = valorLido;
                    meuNo.Nodes.Add(novoNo);
                }
            }
            if (s.StartsWith("["))
            {
                Joda.JSON.ParArr meuPar = new Joda.JSON.ParArr();
                meuPar.Nome = meuTag.Nome;
                meuPar.Deserealizar(s);
                meuNo.Nodes.Clear();
                foreach (Joda.JSON.ParBase valorLido in meuPar.Valor)
                {
                    TreeNode novoNo = new TreeNode();
                    novoNo.Text = valorLido.Nome;
                    novoNo.Tag = valorLido;
                    meuNo.Nodes.Add(novoNo);
                }
            }
            if (s.StartsWith("\""))
            {
                Joda.JSON.ParStr meuPar = new Joda.JSON.ParStr();
                meuPar.Nome = meuTag.Nome;
                meuPar.Deserealizar(s);
                meuNo.Tag = meuPar;
            }
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            foreach(TreeNode noLindo in e.Node.Nodes)
            {
                povoar(noLindo);
            }
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            JSON.ParBase achei = minhArvore.Pesquisar(textBox3.Text);
            if (achei != null)
            {
                this.textBox2.Text = achei.Valor.ToString();
            } else
            {
                this.textBox2.Text = "Caminho não localizado!";
            }
        }
    }
}
