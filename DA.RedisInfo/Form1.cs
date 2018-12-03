namespace DA.RedisInfo
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    using Newtonsoft.Json;
    using ServiceStack.Redis;

    /// <summary>
    /// Defines the <see cref="Form1" />
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
        }

        /// <summary>
        /// The Form1_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            tbIP.Text = ConfigurationManager.AppSettings["RedisIp"];
            tbPort.Text = ConfigurationManager.AppSettings["RedisPort"];
            tbPassword.Text = ConfigurationManager.AppSettings["RedisPassword"];
        }

        /// <summary>
        /// Defines the timer
        /// </summary>
        internal System.Threading.Timer timer;

        /// <summary>
        /// Defines the client
        /// </summary>
        internal ServiceStack.Redis.RedisClient client;

        /// <summary>
        /// Defines the tmpList
        /// </summary>
        internal List<Dictionary<string, string>> tmpList = new List<Dictionary<string, string>>();

        /// <summary>
        /// The btnStartCollect_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
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

                    UpdatetbCount(tmpList.Count.ToString());
                }
                catch (ServiceStack.Redis.RedisException ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }, 0, 0, 10 * 1000);
        }

        /// <summary>
        /// The UpdatetbCount
        /// </summary>
        /// <param name="textInfo">The textInfo<see cref="string"/></param>
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

        /// <summary>
        /// The btnStopCollect_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
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

        /// <summary>
        /// The btnAnalysis_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
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

        /// <summary>
        /// The btnSave_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        /// <summary>
        /// The Save
        /// </summary>
        private void Save()
        {
            if (this.tmpList != null && this.tmpList.Count >= 2)
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

        /// <summary>
        /// The btnSelectFileAnalysis_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
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

            dialog.Dispose();
        }
    }
}
