using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;


// imports for compiling
using System.CodeDom.Compiler;
using System.IO;
using System.Diagnostics;
using ComponentFactory.Krypton.Ribbon;

namespace vs2009
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        string filepath;


        private void compile(string file)
        {
            
            try
            {
                if (filepath == "")
                {
                    MessageBox.Show("You Need To Save the file to compile");
                }
                string exename = "compiled_code.exe";
                CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
                CompilerParameters compars = new CompilerParameters();

                compars.GenerateExecutable = true;
                compars.OutputAssembly = exename;
                compars.GenerateInMemory = false;
                compars.TreatWarningsAsErrors = false;

                CompilerResults res = provider.CompileAssemblyFromFile(compars, file);
                if (res.Errors.Count > 0)
                {
                    foreach (CompilerError ce in res.Errors)
                    {
                        MessageBox.Show(ce.ToString(), "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Code Compiled.", "Success");
                    
                }
            }
            catch (System.ArgumentNullException e)
            {
                MessageBox.Show("Need to save the file. Expection:" + e.Message, "Visual C# Express 2009",MessageBoxButtons.OK,  MessageBoxIcon.Error);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "All Files|*.*";
            save.OverwritePrompt = true;
            save.CreatePrompt = true;

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Kayit = new StreamWriter(save.FileName);
                Kayit.WriteLine(fastColoredTextBox1.Text);
                Kayit.Close();
                filepath = save.FileName;
                this.Text = this.Text + " - " + filepath;
                button1.Enabled = true;
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open File";
            open.Filter = "All Files|*.*";

            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var loadedText = File.ReadAllText(open.FileName);
                fastColoredTextBox1.Text = loadedText;
                filepath = open.FileName;
                this.Text = this.Text + " - " + filepath;
                button1.Enabled = true;
            }
        }
        private void kryptonRibbonGroupButton1_Click(object sender, EventArgs e)
        {
            compile(filepath);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DemoApplication
{
 class Program
 { 
  static void Main(string[] args) 
  {
   string text = 
   Console.Write('Hello World');

   Console.ReadKey();
   }
}
";
            CheckFormat("needtosave.cs");
            
        }

        private void kryptonRibbonGroup1_DialogBoxLauncherClick(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "All Files|*.*";
            save.OverwritePrompt = true;
            save.CreatePrompt = true;

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Kayit = new StreamWriter(save.FileName);
                Kayit.WriteLine(fastColoredTextBox1.Text);
                Kayit.Close();
                filepath = save.FileName;
                this.Text = this.Text + " - " + filepath;
                button1.Enabled = true;
                CheckFormat(save.FileName);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open File";
            open.Filter = "All Files|*.*";

            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var loadedText = File.ReadAllText(open.FileName);
                fastColoredTextBox1.Text = loadedText;
                filepath = open.FileName;
                this.Text = this.Text + " - " + filepath;
                button1.Enabled = true;
                kryptonLabel1.Text = open.FileName;
                CheckFormat(open.FileName);

                
            }
        }

        private void kryptonLabel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CheckFormat(string file)
        {
            if (file.EndsWith(".cs"))
            {
                kryptonLabel1.Values.ExtraText = "- CSharp";
            }
            if (file.EndsWith("Designer.cs"))
            {
                kryptonLabel1.Values.ExtraText = "- Winforms Designer(C#)";
            }
            if (file.EndsWith(".config"))
            {
                kryptonLabel1.Values.ExtraText = "- Configuration";
            }
            else
            {
                kryptonLabel1.Values.ExtraText = "- Other";
            }
        }

        private void kryptonRibbon1_AppButtonMenuOpened(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void kryptonRibbonGroupButton1_Click_1(object sender, EventArgs e)
        {
            fastColoredTextBox1.Undo();
        }

        private void kryptonRibbonGroupButton2_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Redo();
        }

        private void kryptonRibbonGroupButton3_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Copy();
        }

        private void kryptonRibbonGroupButton4_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Paste();
        }

        private void kryptonRibbonGroupButton5_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Cut();
        }

        private void kryptonRibbonGroupButton6_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }
    }
}
