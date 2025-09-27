
/* * 
 * 
 *  Realmforge Role Play Launcher
 *  powered by ncode.ge (N.Shanidze)
 *  2024
 *  
* */

using Microsoft.Win32;
using System;
 
using System.ComponentModel;
 
using System.Diagnostics;
using System.Drawing;
using System.IO;
 
using System.Windows.Forms;
using System.Net;
 
using System.IO.Compression;
 

namespace pc_samp
{

    public partial class RealmForge : Form
    {

        public RealmForge()
        {

            // MessageBox.Show(Environment.UserName); windows reg username  

            string dir = @"C:\Realmforge_RolePlay\";

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }


            if (Registry.CurrentUser.OpenSubKey(@"Software\SAMP") == null)//როცა სამპი არარი დანაინსტალირები
            {
                var regKey = Registry.CurrentUser.OpenSubKey("Software", true);
                regKey.CreateSubKey("SAMP");

                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\SAMP", true);

                //create a new key 
                key.CreateSubKey("PlayerName");
                key.SetValue("PlayerName", "Realmforge_Player");
                key.CreateSubKey("gta_sa_exe");
                key.SetValue("gta_sa_exe", @"C:\Realmforge_RolePlay\RFRP\RFRP\gta_sa.exe");

            }

            string userName = Registry.CurrentUser.OpenSubKey(@"Software\SAMP", true).GetValue("PlayerName").ToString();
            InitializeComponent();

            if (userName == "" || userName == " " || userName.Length < 4)// თუ ცარიელია სახელი არ აწერია, ან სფეისია გამოყენებული, ან 4 სიმბოლოზე ნაკლებია მიცეს
            {
                Registry.CurrentUser.OpenSubKey(@"Software\SAMP", true).SetValue("PlayerName", "Realmforge_Player");
                // base.Close();
                MessageBox.Show("თქვენ არ გაწერიათ სახელი, ავტომატურად დაგეწერათ : Realmforge_Player, სახელის შესაცვლელად საჭიროა შეცვალოთ მითითებულ ველში სახელი, და ჩართოთ თამაში", "Realmforge Role Play");
            }
            else
            {
                //ჩატვირთოს ბოლოს დამახსოვრებული სახელი
                Player_User.Text = Registry.CurrentUser.OpenSubKey(@"Software\SAMP", true).GetValue("PlayerName").ToString();

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {



            string dirf = @"C:\Realmforge_RolePlay\RFRP";
            if (!Directory.Exists(dirf))
            {
                pictureBox6.Hide();

                Downlading_progress.Hide();

                progressBar1.Value = 0;
                label6.ForeColor = Color.White;
                label6.Text = + progressBar1.Value + "% / 100%";
                label6.Show();

                //label6.Hide();
                MessageBox.Show("თქენს მოწყობილობაში არ არის დაყენებული ფაილები, დააკლიკეთ 'თამაშის ჩაწერა'-ს, ჩაწერის სიჩქარე დამოკიდებულია თქვენს მოწყობილობაზე და ინტერნეტის სიჩქარეზე, თუ სრულად ჩაწერა არ მოხდება იქამდე სანამ შეტყიბინებას არ ამოგიგდებთ რომ დასრულდა, არ გათიშოთ ლაუნჩერი წინააღმდეგ შემთხვევაში თავიდან დაიწყება ჩაწერა!!", "#RFRP - წაიკითხეთ შეტყობინება სრულად!");
            }
            else
            {
                label6.ForeColor = Color.LimeGreen;
                label6.Text = "თამაში დაყენებულია.";
 

                label6.Show();
                label10.Text = "თამაში ჩაწერილია, დააჭირეთ ღილაკს სათამაშოდ!";
                Downlading_progress.Hide();
                progressBar1.Hide();
                Gta_Download.Hide();
                // label6.Hide();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            Process.Start("https://www.facebook.com/groups/realmforge");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/groups/realmforge");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/groups/realmforge");
        }

        /* private void pictureBox2_Click_2(object sender, EventArgs e)
         {
             Settings settings = new Settings();
             settings.Show();
         }*/

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            string serverIP = "91.134.166.72:7777";//სერვერის აიპი
                                                   // string Password = ""; //სერვერის პაროლი (არ ადევს)

            Registry.CurrentUser.OpenSubKey(@"Software\SAMP", true).SetValue("PlayerName", Player_User.Text);
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\SAMP", true);



            key.SetValue("gta_sa_exe", @"C:\Realmforge_RolePlay\RFRP\RFRP\gta_sa.exe"); //sets 'someData' in 'someValue' 


            string password = "30"; // Replace with actual password
            string exePath = @"C:\Realmforge_RolePlay\RFRP\RFRP\samp.exe";

            var processInfo = new ProcessStartInfo
            {
                FileName = exePath,
                Arguments = $"{serverIP} {password}",
                UseShellExecute = true // Set to false if you want to redirect input/output
            };

            try
            {
                Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                // Handle the error (e.g., log it or display a message)
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

 
 

        private void pictureBox8_Click_3(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
 
        private void Player_User_TextChanged(object sender, EventArgs e)
        {
            RegistryKey kesy = Registry.CurrentUser.OpenSubKey(@"Software\SAMP", true);//ლაივრეჟიმში თან ჩაიმახსოვროს სახელი ყოველიასოს შეცვლისას
            kesy.SetValue("PlayerName", Player_User.Text);//ლაივრეჟიმში თან ჩაიმახსოვროს სახელი ყოველიასოს შეცვლისას

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

            /* string myRegistryKey = Registry.CurrentUser.OpenSubKey(@"Software\\SAMP").GetValue("gta_sa_exe").ToString();
             myRegistryKey = myRegistryKey.Substring(0, myRegistryKey.LastIndexOf(@"\") + 1);
             saxeli.Text = Registry.CurrentUser.OpenSubKey(@"Software\SAMP", true).GetValue("PlayerName").ToString();
             if(saxeli.Text == "" || saxeli.Text == " " || saxeli.MaxLength < 4)// თუ ცარიელია სახელი არ აწერია, ან სფეისია გამოყენებული, ან 4 სიმბოლოზე ნაკლებია მიცეს
             {

             }
             if (!File.Exists(myRegistryKey + "gta_sa.exe"))
             {
                 MessageBox.Show("შეცდომა #11", "Realmforge Role Play", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                 base.Close();
                 Application.Exit();
             }
             else if (!File.Exists(myRegistryKey + "samp.exe"))
             {
                 MessageBox.Show("შეცდომა #12", "Realmforge Role Play", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                 base.Close();
                 Application.Exit();
             }*/
        }
 

        private void label9_Click(object sender, EventArgs e)
        {

        }
 


        private void Gta_Download_Click(object sender, EventArgs e)
        {



            MessageBox.Show("თქვენს მოწყობილებაში წარმატებით დაიწყო ფაილების ჩატვირთვა, ჩაწერის კონტროლი შეგიძლიათ ლაუნჩერზე ნაჩვენებ Progressbar-ით რომელიც შევსებას დაიწყებს რამდენიმე წამში!", "#RFRP - გილოცავთ!");

            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://drive.usercontent.google.com/download?id=17kEYC-NNyAfHCTJ7aiODLkwYKn0CQWFa&export=download&authuser=0&confirm=t&uuid=79a7a6ef-5b74-4202-9281-4e4e8902f387&at=AENtkXbCKcEYYjed5ru5QHtvEVpF%3A1731010637662"), @"C:\Realmforge_RolePlay\RFRP.zip");

            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += ProgressChanged;

                wc.DownloadFileAsync(
                    new System.Uri("https://drive.usercontent.google.com/download?id=17kEYC-NNyAfHCTJ7aiODLkwYKn0CQWFa&export=download&authuser=0&confirm=t&uuid=79a7a6ef-5b74-4202-9281-4e4e8902f387&at=AENtkXbCKcEYYjed5ru5QHtvEVpF%3A1731010637662"),
                    "C:\\Realmforge RolePlay\\RFRP.zip"
                );
                Gta_Download.Hide();
                Downlading_progress.Show();
            }

        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            if (progressBar1.Value >= 100)
            {
                //label6.ForeColor = Color.Green;
                label6.Text = "მიმდინარეობს ამოარქივება";
                label6.Show();
            }
            else
            {
                label6.ForeColor = Color.MediumOrchid;
                label6.Text = "იწერება.. " + progressBar1.Value + "% / 100%";
                label6.Show();
            }
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {

            pictureBox6.Show();

            progressBar1.Hide();
            Gta_Download.Hide();



            string targetFolder = @"C:\Realmforge_RolePlay\RFRP";
            string sourceZipFile = @"C:\Realmforge_RolePlay\RFRP.zip";
            ZipFile.ExtractToDirectory(sourceZipFile, targetFolder);

            Downlading_progress.Hide();

            label6.Text = "იწერება.. " + progressBar1.Value + "% / 100%";

            MessageBox.Show("ინსტალაცია დასრულებულია. შეგიძლიათ შეცვალოთ სახელი და დააკლიკოთ 'თამაშის დაწყება'-ს, სასიამოვნო გართობას გისრუვებთ ( #Realmforge RolePlay Administration)");


            string file = @"C:\Realmforge_RolePlay\RFRP.zip";

            if (Directory.Exists(Path.GetDirectoryName(file)))
            {
                File.Delete(file);
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }
 

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Downlading_progress_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_3(object sender, EventArgs e)
        {

        }
    }
}