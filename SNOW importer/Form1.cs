using System;
using System.IO;
using System.Windows.Forms;

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

                    string id = job.Remove(0, 13).Remove(5); //site ID is always at the same index(start of buid)
                    string job_c = job.Remove(0, 13);
                    string buid = job_c.Remove(job_c.IndexOf('-', 8) + 8);//get the whole buid, needed for sb copy & paste
                    string step = job.Split(' ')[job.Split(' ').Length -1];//wf step is always the last string, split by spaces & take the last
                    string bu_d = job.Remove(0, job.IndexOf('/') - 2).Remove(9);
                    //sometimes the exec ID doesn't split from the step, remove everything up to the last numeric char
                    int idx = step.LastIndexOfAny(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
                    if(idx > 0) { step = step.Remove(0, idx + 1); }

                    //add job info to array & loop
                    jj.buid = buid;
                    jj.site_id = id;
                    jj.bu_date = bu_d;
                    jj.step = step;
                    job_arr[i] = jj;
                    i++;
                }
           
            }

            //hide import fields & show job info & export controls
            lbl_import_prompt.Visible = rtb_import.Visible = btn_import.Visible = false;
            btn_back.Visible = lbl_step.Visible = lbl_step_stat.Visible = lbl_date.Visible = lbl_date_stat.Visible = btn_export.Visible = lbl_parent.Visible = tbx_parent.Visible = lbl_count.Visible = lbl_buid.Visible = lbl_site.Visible = btn_a_post.Visible = btn_f_post.Visible = btn_n_post.Visible = true;

            //write job list to a public var & call first site 
            jobs = job_arr;
            load_next();
        }

        private void load_next()
        {
            //cyles through all jobs, copies BUID to clipboard & gives info on what job failed in sb
            if(site_index < jobs.Length)
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
                btn_export_status.Visible = true;
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
            string[] out_arr_jobs = new string[jobs.Length + 1];
            int i = 1;
            //only parent & site is needed, everything else is inherited in SNOW from the parent
            out_arr_jobs[0] = "Parent Ticket,Site ID";

            foreach(JJob job in jobs)
            {
                out_arr_jobs[i] = $"{parent},{job.site_id}";
                i++;
            }
            
            File.WriteAllLines((export_path + "jobs_out.csv"), out_arr_jobs);
        }

        private void btn_export_status_Click(object sender, EventArgs e)
        {
            //export of what jobs were marked as, to be put in parent ticket notes manually & used for the operator to know what sites still need action
            string export_path = System.Reflection.Assembly.GetEntryAssembly().Location.Remove(System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf("\\") + 1);
            string[] out_arr_status = new string[jobs.Length + 1];
            int i = 0;

            foreach (JJob job in jobs)
            {
                out_arr_status[i] = job.buid + " | " + job.status;
                i++;
            }

            File.WriteAllLines((export_path + "status_out.txt"), out_arr_status);
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
    }   
}

public class JJob
{
    public string site_id = string.Empty;
    public string buid = string.Empty;
    public string status = string.Empty;
    public string bu_date = string.Empty;
    public string step = string.Empty;
}