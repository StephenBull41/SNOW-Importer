using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
// to do: sort status output
namespace SNOW_importer
{
    public partial class Main : Form
    {
        public int site_index = 0;
        // create an array of job objects to hold info on each job imported
        public JJob[] jobs = new JJob[2];//length doesn't matter, it will be overwritten


        public Main()
        {
            InitializeComponent();
            // hide everything not needed for importing
            lbl_step.Visible = lbl_step_stat.Visible = lbl_date.Visible = lbl_date_stat.Visible = lbl_parent.Visible = tbx_parent.Visible = btn_export_status.Visible = btn_export.Visible = btn_back.Visible = lbl_count.Visible = lbl_buid.Visible = lbl_site.Visible = btn_a_post.Visible = btn_f_post.Visible = btn_n_post.Visible = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Environment.Exit(0);
            base.OnFormClosing(e);
        }

        private void btn_import_Click(object sender, EventArgs e)
        {

            string[] import_arr = rtb_import.Lines;

            int i = 0;
            foreach(string j in import_arr)
            {
                if (j.Length > 1) { i++; }
            }
            JJob[] job_arr = new JJob[i];

            i = 0;
            rtb_import.Clear();
            foreach (string job in import_arr)
            {
                if (job.Length > 1)
                {
                    JJob jj = new JJob();
                    string[] sjob = job.Split('\t'); //split by tabs(table fields)

                    jj.buid = sjob[2];
                    jj.site_id = sjob[2].Remove(5);
                    jj.bu_date = sjob[3];
                    jj.step = sjob[7];
                    job_arr[i] = jj;
                    i++;
                }
           
            }

            //hide import fields & show job info & export controls
            lbl_import_prompt.Visible = rtb_import.Visible = btn_import.Visible = false;
            btn_add_jobs.Visible = btn_back.Visible = lbl_step.Visible = lbl_step_stat.Visible = lbl_date.Visible = lbl_date_stat.Visible = btn_export.Visible = lbl_parent.Visible = tbx_parent.Visible = lbl_count.Visible = lbl_buid.Visible = lbl_site.Visible = btn_a_post.Visible = btn_f_post.Visible = btn_n_post.Visible = true;

            //write job list to a public var & call first site 
            jobs = job_arr;
            load_next();
            
        }

        private void load_next()
        {
            //cyles through all jobs, copies BUID to clipboard & gives info on what job failed in sb

            if (site_index < jobs.Length)
            {
                if (jobs[site_index].check == true)
                {
                    lbl_buid.Text = jobs[site_index].buid;
                    lbl_count.Text = (site_index + 1) + "/" + jobs.Length;
                    lbl_date.Text = jobs[site_index].bu_date;
                    lbl_step.Text = jobs[site_index].step;
                    Clipboard.SetText(jobs[site_index].buid);
                    site_index++;
                }
                else
                {
                    site_index++;
                    load_next();
                    return;
                }

            }
            else
            {
                btn_export_status.Visible = true;
                lbl_buid.Text = "";
                lbl_count.Text = "";
                lbl_date.Text = "";
                lbl_step.Text = "";
                btn_a_post.Visible = false;
                btn_f_post.Visible = false;
                btn_n_post.Visible = false;
            }
        }

        // buttons mark a job as posted, not posted, or failed post & call next site
        private void btn_a_post_Click(object sender, EventArgs e)
        {
            if(site_index <= jobs.Length) { jobs[site_index - 1].status = "Already posted"; }  
            load_next();
        }

        private void btn_f_post_Click(object sender, EventArgs e)
        {
            if (site_index <= jobs.Length) { jobs[site_index - 1].status = "Force posted"; } 
            load_next();
        }

        private void btn_n_post_Click(object sender, EventArgs e)
        {
            if (site_index <= jobs.Length) { jobs[site_index - 1].status = "Not posted"; } 
            load_next();
        }

        // go back one site
        private void btn_back_Click(object sender, EventArgs e)
        {
            if (site_index > 1) { site_index = site_index - 2; }
            load_next();
        }

        //export list to be imported to SNOW
        private void export_jobs(string parent)
        {
            string export_path = System.Reflection.Assembly.GetEntryAssembly().Location.Remove(System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf("\\") + 1);

            List<string> ex_lst = new List<string>();
            foreach(JJob j in jobs)
            {
                if(j.check == true)
                {
                    ex_lst.Add(parent + "," + j.site_id);
                }
            }
            string[] temp_arr = ex_lst.ToArray();
            string[] out_arr_jobs = new string[temp_arr.Length + 1];
            out_arr_jobs[0] = "Parent,SiteID";
            int i = 1;
            foreach(string line in temp_arr)
            {
                out_arr_jobs[i] = line;
                i++;
            }
            
            File.WriteAllLines((export_path + $"jobs_out_{DateTime.Today.ToString("yyyy-MM-dd") + "_" + DateTime.Now.Hour + "." + DateTime.Now.Minute}.csv"), out_arr_jobs);
        }

        private void btn_export_status_Click(object sender, EventArgs e)
        {
            //export of what jobs were marked as, to be put in parent ticket notes manually & used for the operator to know what sites still need action
            string export_path = System.Reflection.Assembly.GetEntryAssembly().Location.Remove(System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf("\\") + 1);
            
            List<string> ex_lst = new List<string>();

            //put jobs that require attention at the top of the notes 
            foreach (JJob job in jobs)
            {
                if (job.status == "Not posted" && job.check == true)
                { 
                    ex_lst.Add(job.status + "," + job.buid + "," + job.bu_date);
                }
            }
            foreach (JJob job in jobs)
            {
                if (job.status != "Not posted" && job.check == true)
                {
                    ex_lst.Add(job.status + "," + job.buid + "," + job.bu_date);
                }
            }
            File.WriteAllLines((export_path + $"status_out_{DateTime.Today.ToString("yyyy - MM - dd") + "_" + DateTime.Now.Hour + "." + DateTime.Now.Minute}.txt"), ex_lst.ToArray());
            btn_export_status.Visible = false;
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            //Validate the parent incident number, assumed 'INC1234567'
            bool valid = true;
            if (tbx_parent.Text.Length != 10) { valid = false; }
            
            try
            {
                if (tbx_parent.Text.Remove(3).ToUpper() != "INC") { valid = false; }
                Convert.ToInt32(tbx_parent.Text.Remove(0, 3));
            }
            catch
            {
                valid = false;
            }

            if(valid)
            {
                export_jobs(tbx_parent.Text.ToUpper());
                btn_export.Visible = false;
            }
            else
            {
                btn_export.Text = "Enter a valid parent incident";
            }            
        }

        private void tbx_parent_TextChanged(object sender, EventArgs e)
        {
            if (tbx_parent.Text.Length == 10)
            {
                btn_export.Text = "Export SNOW import list";
            }
        }

        private void btn_add_jobs_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = System.Reflection.Assembly.GetEntryAssembly().Location.Remove(System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf("\\") + 1);
            ofd.Filter = "text files (*.txt)|*.txt";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                int i = 0;
                string[] done_jobs = File.ReadAllLines(ofd.FileName);
                foreach(JJob j in jobs)
                {
                    foreach(string dj in done_jobs)
                    {
                        if(dj.Contains(",") && j.buid == dj.Split(',')[1] && j.bu_date == dj.Split(',')[2])
                        {
                            jobs[i].check = false;
                        }
                    }
                    i++;
                }
                site_index = 0; //reset to first job
                load_next();
            }


        }
    }   

}

public class JJob
{
    public string site_id = string.Empty;
    public string buid = string.Empty;
    public string status = string.Empty;
    public string bu_date = string.Empty;
    public string step = string.Empty;
    public bool check = true;
}