using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using ServiceStack.Redis;

namespace DA.RedisInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbIP.Text = ConfigurationManager.AppSettings["RedisIp"];
            tbPort.Text = ConfigurationManager.AppSettings["RedisPort"];
            tbPassword.Text = ConfigurationManager.AppSettings["RedisPassword"];
        }

        System.Threading.Timer timer;
        ServiceStack.Redis.RedisClient client;

        List<Dictionary<string, string>> tmpList = new List<Dictionary<string, string>>();

        private void btnStartCollect_Click(object sender, EventArgs e)
        {
            if (timer != null)
            {
                return;
            }

            Save();
            tmpList = new List<Dictionary<string, string>>();

            ServiceStack.Redis.RedisClient client = new RedisClient(tbIP.Text, int.Parse(tbPort.Text), tbPassword.Text);

            timer = new System.Threading.Timer((obj) =>
            {
                try
                {
                    Dictionary<string, string> infos = client.Info;
                    infos["Current_Time"] = DateTime.Now.ToString();

                    tmpList.Add(infos);

                    var ss = client.Exists("MyCat");

                    UpdatetbCount(tmpList.Count.ToString());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }, 0, 0, 10 * 1000);
        }

        private void UpdatetbCount(string textInfo)
        {
            if (tbCount.InvokeRequired)
            {
                tbCount.Invoke(new Action(() => UpdatetbCount(textInfo)));
            }
            else
            {
                tbCount.Text = textInfo;
            }
        }

        private void btnStopCollect_Click(object sender, EventArgs e)
        {
            if (timer != null)
            {
                timer.Dispose();

                timer = null;
            }

            if (client != null)
            {
                client.Dispose();
                client = null;
            }
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            if (this.tmpList != null && this.tmpList.Count < 2)
            {
                MessageBox.Show("没有足够的数据");
                return;
            }
            var result = RedisAnalysis.GetQPS(this.tmpList);

            this.dataGridView1.DataSource = result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (this.tmpList!= null && this.tmpList.Count >= 2)
            {
                var jsonString = JsonConvert.SerializeObject(tmpList);

                var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid().ToString("N") + ".txt";

                string folderPath = Path.Combine(Application.StartupPath, "data");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string filePath = Path.Combine(Application.StartupPath, "data", fileName);

                File.WriteAllText(filePath, jsonString);
            }
        }

        private void btnSelectFileAnalysis_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var str = File.ReadAllText(dialog.FileName);

                var list = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(str);

                var result = RedisAnalysis.GetQPS(list);

                this.dataGridView1.DataSource = result;

            }


        }
    }
}
