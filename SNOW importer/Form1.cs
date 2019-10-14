using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SNOW_importer
{
    public partial class Main : Form
    {
        public int site_index = 0;
        public JJob[] jobs = new JJob[2];


        public Main()
        {
            InitializeComponent();
            lbl_step.Visible = lbl_step_stat.Visible = lbl_date.Visible = lbl_date_stat.Visible = lbl_parent.Visible = tbx_parent.Visible = btn_export_status.Visible = btn_export.Visible = btn_back.Visible = lbl_count.Visible = lbl_buid.Visible = lbl_site.Visible = btn_a_post.Visible = btn_f_post.Visible = btn_n_post.Visible = false;
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

                    string id = job.Remove(0, 13).Remove(5);
                    string job_c = job.Remove(0, 13);
                    string buid = job_c.Remove(job_c.IndexOf('-', 8) + 8);
                    string step = job.Split(' ')[job.Split(' ').Length -1];
                    string bu_d = job.Remove(0, job.IndexOf('/') - 2).Remove(9);
                    int idx = step.LastIndexOfAny(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
                    if(idx > 0) { step = step.Remove(0, idx + 1); }

                    jj.buid = buid;
                    jj.site_id = id;
                    jj.bu_date = bu_d;
                    jj.step = step;
                    job_arr[i] = jj;
                    i++;
                }
           
            }

            lbl_import_prompt.Visible = rtb_import.Visible = btn_import.Visible = false;
            lbl_step.Visible = lbl_step_stat.Visible = lbl_date.Visible = lbl_date_stat.Visible = btn_export.Visible = lbl_parent.Visible = tbx_parent.Visible = lbl_count.Visible = lbl_buid.Visible = lbl_site.Visible = btn_a_post.Visible = btn_f_post.Visible = btn_n_post.Visible = true;

            jobs = job_arr;
            load_next();
        }

        private void load_next()
        {
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
                btn_export_status.Visible = btn_export.Visible = true;
            } 
        }

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

        private void btn_back_Click(object sender, EventArgs e)
        {
            //not working
            if (site_index > 1) { site_index--; }
            load_next();
        }

        private void export_jobs(string parent)
        {
            string export_path = System.Reflection.Assembly.GetEntryAssembly().Location.Remove(System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf("\\") + 1);
            string[] out_arr_jobs = new string[jobs.Length + 1];
            int i = 1;
            out_arr_jobs[0] = "site,inherit from,notes";

            foreach(JJob job in jobs)
            {
                out_arr_jobs[i] = $"{job.site_id},{parent},BU_Date:{job.bu_date} | Step:{job.step}";
                i++;
            }
            
            File.WriteAllLines((export_path + "jobs_out.csv"), out_arr_jobs);
        }

        private void btn_export_status_Click(object sender, EventArgs e)
        {
            string export_path = System.Reflection.Assembly.GetEntryAssembly().Location.Remove(System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf("\\") + 1);
            string[] out_arr_status = new string[jobs.Length + 1];
            int i = 1;
            out_arr_status[0] = "BUID - STATUS";

            foreach (JJob job in jobs)
            {
                out_arr_status[i] = job.buid + " - " + job.status;
                i++;
            }

            File.WriteAllLines((export_path + "status_out.txt"), out_arr_status);
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if(tbx_parent.Text.Length == 10)
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