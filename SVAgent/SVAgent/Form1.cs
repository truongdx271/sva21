using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Diagnostics;
using System.IO;
using SVAgent.Model;
using Newtonsoft.Json;
namespace SVAgent
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        public string proPath = "";

        private void Scan_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("SVAgent.exe","-u C:");
            ProcessStartInfo info = new ProcessStartInfo();
            Process process = new Process();
            info.UseShellExecute = false;
            info.RedirectStandardOutput = true;
            info.CreateNoWindow = true;
            info.FileName = Directory.GetCurrentDirectory() + @"\SVACLI.exe";
            //info.WorkingDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), info.FileName);
            /* application name : cmd.exe*/
            /* Copy command arguments*/
            info.Arguments = @"-u " + proPath + @" -c " + code.Text + @" -n " + name.Text + @" -p " + po.Text + @" -m duyb" + @" -t 420420";
            /* Following setting will hide the command line window.*/
            info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //MessageBox.Show(info.FileName);
            //Process process..WorkingDirectory = Path.GetDirectoryName(application.Filename);
            process = Process.Start(info);
            //string result = process.StandardOutput.ToString();
            //MessageBox.Show(result);
            String resultjson = "";
            while (!process.StandardOutput.EndOfStream)
            {
                string line = process.StandardOutput.ReadLine();
                resultjson = resultjson + line;

                //Console.WriteLine(line);
                //MessageBox.Show(line);
            }
            //MessageBox.Show(resultjson);
            //Console.WriteLine(resultjson);
            projObject resultObject = JsonConvert.DeserializeObject<projObject>(resultjson);
            List<ResultItem> itemObject = resultObject.scans[0].resultItems;
            var list = new BindingList<ResultItem>(itemObject);
            resultGrid.DataSource = list;
            //MessageBox.Show(resultObject.scans.ToString());
            //Console.WriteLine(resultjson.scans);
            //MessageBox.Show(proPath);
            process.Close();
        }
        private void Browse_Click(object sender, EventArgs e)
        {
            //int size = -1;
            //DialogResult result = .ShowDialog(); // Show the dialog.
            string path = "";
            var fbd = new System.Windows.Forms.FolderBrowserDialog();
            var result = fbd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                path = fbd.SelectedPath;
                //MessageBox.Show(path);

                //path = path.Substring(path.LastIndexOf('\\') + 1, path.Length - path.LastIndexOf('\\') - 1);
            }

            proPath = path.Replace(@"\\",@"\");


            //MessageBox.Show(path);

            /*if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                }
            }*/
        }


        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void resultGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private static void printSimplifiedResult(List<ResultItem> simplifiedResult)
        {
            foreach (var item in simplifiedResult)
            {
                Console.WriteLine(item.identify + " | " + item.displayTxt + " | " + item.pathFile + " | " + item.lineNumber + " | " + item.result);
            }

            Console.WriteLine("Total vuln: " + simplifiedResult.Count);
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
