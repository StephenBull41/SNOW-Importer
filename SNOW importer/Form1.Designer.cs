namespace SNOW_importer
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtb_import = new System.Windows.Forms.RichTextBox();
            this.btn_import = new System.Windows.Forms.Button();
            this.lbl_import_prompt = new System.Windows.Forms.Label();
            this.btn_a_post = new System.Windows.Forms.Button();
            this.btn_n_post = new System.Windows.Forms.Button();
            this.btn_f_post = new System.Windows.Forms.Button();
            this.lbl_site = new System.Windows.Forms.Label();
            this.lbl_buid = new System.Windows.Forms.Label();
            this.lbl_count = new System.Windows.Forms.Label();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_export_status = new System.Windows.Forms.Button();
            this.lbl_parent = new System.Windows.Forms.Label();
            this.tbx_parent = new System.Windows.Forms.TextBox();
            this.lbl_step = new System.Windows.Forms.Label();
            this.lbl_step_stat = new System.Windows.Forms.Label();
            this.lbl_date = new System.Windows.Forms.Label();
            this.lbl_date_stat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtb_import
            // 
            this.rtb_import.BackColor = System.Drawing.Color.White;
            this.rtb_import.DetectUrls = false;
            this.rtb_import.ForeColor = System.Drawing.Color.Black;
            this.rtb_import.Location = new System.Drawing.Point(0, 95);
            this.rtb_import.Name = "rtb_import";
            this.rtb_import.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rtb_import.Size = new System.Drawing.Size(656, 356);
            this.rtb_import.TabIndex = 0;
            this.rtb_import.Text = "";
            this.rtb_import.WordWrap = false;
            // 
            // btn_import
            // 
            this.btn_import.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btn_import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_import.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_import.Location = new System.Drawing.Point(12, 12);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(609, 54);
            this.btn_import.TabIndex = 1;
            this.btn_import.Text = "Import";
            this.btn_import.UseVisualStyleBackColor = false;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // lbl_import_prompt
            // 
            this.lbl_import_prompt.AutoSize = true;
            this.lbl_import_prompt.Location = new System.Drawing.Point(12, 79);
            this.lbl_import_prompt.Name = "lbl_import_prompt";
            this.lbl_import_prompt.Size = new System.Drawing.Size(133, 13);
            this.lbl_import_prompt.TabIndex = 2;
            this.lbl_import_prompt.Text = "Paste text here then import";
            // 
            // btn_a_post
            // 
            this.btn_a_post.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btn_a_post.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_a_post.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_a_post.Location = new System.Drawing.Point(12, 310);
            this.btn_a_post.Name = "btn_a_post";
            this.btn_a_post.Size = new System.Drawing.Size(200, 117);
            this.btn_a_post.TabIndex = 3;
            this.btn_a_post.Text = "Already posted";
            this.btn_a_post.UseVisualStyleBackColor = false;
            this.btn_a_post.Click += new System.EventHandler(this.btn_a_post_Click);
            // 
            // btn_n_post
            // 
            this.btn_n_post.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btn_n_post.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_n_post.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_n_post.Location = new System.Drawing.Point(421, 310);
            this.btn_n_post.Name = "btn_n_post";
            this.btn_n_post.Size = new System.Drawing.Size(200, 117);
            this.btn_n_post.TabIndex = 4;
            this.btn_n_post.Text = "Post failed or pending";
            this.btn_n_post.UseVisualStyleBackColor = false;
            this.btn_n_post.Click += new System.EventHandler(this.btn_n_post_Click);
            // 
            // btn_f_post
            // 
            this.btn_f_post.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btn_f_post.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_f_post.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_f_post.Location = new System.Drawing.Point(216, 310);
            this.btn_f_post.Name = "btn_f_post";
            this.btn_f_post.Size = new System.Drawing.Size(200, 117);
            this.btn_f_post.TabIndex = 5;
            this.btn_f_post.Text = "Force posted";
            this.btn_f_post.UseVisualStyleBackColor = false;
            this.btn_f_post.Click += new System.EventHandler(this.btn_f_post_Click);
            // 
            // lbl_site
            // 
            this.lbl_site.AutoSize = true;
            this.lbl_site.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_site.Location = new System.Drawing.Point(25, 156);
            this.lbl_site.Name = "lbl_site";
            this.lbl_site.Size = new System.Drawing.Size(98, 24);
            this.lbl_site.TabIndex = 6;
            this.lbl_site.Text = "Site BU ID:";
            // 
            // lbl_buid
            // 
            this.lbl_buid.AutoSize = true;
            this.lbl_buid.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_buid.Location = new System.Drawing.Point(129, 156);
            this.lbl_buid.Name = "lbl_buid";
            this.lbl_buid.Size = new System.Drawing.Size(57, 24);
            this.lbl_buid.TabIndex = 7;
            this.lbl_buid.Text = " BUID";
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_count.Location = new System.Drawing.Point(531, 156);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(57, 24);
            this.lbl_count.TabIndex = 8;
            this.lbl_count.Text = "count";
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.Location = new System.Drawing.Point(488, 156);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(42, 24);
            this.btn_back.TabIndex = 9;
            this.btn_back.Text = "<";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // btn_export
            // 
            this.btn_export.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_export.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.Location = new System.Drawing.Point(12, 12);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(301, 54);
            this.btn_export.TabIndex = 10;
            this.btn_export.Text = "Export SNOW import list";
            this.btn_export.UseVisualStyleBackColor = false;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_export_status
            // 
            this.btn_export_status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btn_export_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_export_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export_status.Location = new System.Drawing.Point(321, 12);
            this.btn_export_status.Name = "btn_export_status";
            this.btn_export_status.Size = new System.Drawing.Size(301, 54);
            this.btn_export_status.TabIndex = 11;
            this.btn_export_status.Text = "Export job staus";
            this.btn_export_status.UseVisualStyleBackColor = false;
            this.btn_export_status.Click += new System.EventHandler(this.btn_export_status_Click);
            // 
            // lbl_parent
            // 
            this.lbl_parent.AutoSize = true;
            this.lbl_parent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_parent.Location = new System.Drawing.Point(25, 132);
            this.lbl_parent.Name = "lbl_parent";
            this.lbl_parent.Size = new System.Drawing.Size(69, 24);
            this.lbl_parent.TabIndex = 12;
            this.lbl_parent.Text = "Parent:";
            // 
            // tbx_parent
            // 
            this.tbx_parent.BackColor = System.Drawing.Color.White;
            this.tbx_parent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_parent.Location = new System.Drawing.Point(129, 132);
            this.tbx_parent.Name = "tbx_parent";
            this.tbx_parent.Size = new System.Drawing.Size(83, 23);
            this.tbx_parent.TabIndex = 13;
            this.tbx_parent.TextChanged += new System.EventHandler(this.tbx_parent_TextChanged);
            // 
            // lbl_step
            // 
            this.lbl_step.AutoSize = true;
            this.lbl_step.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_step.Location = new System.Drawing.Point(129, 204);
            this.lbl_step.Name = "lbl_step";
            this.lbl_step.Size = new System.Drawing.Size(45, 24);
            this.lbl_step.TabIndex = 15;
            this.lbl_step.Text = "step";
            // 
            // lbl_step_stat
            // 
            this.lbl_step_stat.AutoSize = true;
            this.lbl_step_stat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_step_stat.Location = new System.Drawing.Point(25, 204);
            this.lbl_step_stat.Name = "lbl_step_stat";
            this.lbl_step_stat.Size = new System.Drawing.Size(53, 24);
            this.lbl_step_stat.TabIndex = 14;
            this.lbl_step_stat.Text = "Step:";
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_date.Location = new System.Drawing.Point(129, 180);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(46, 24);
            this.lbl_date.TabIndex = 17;
            this.lbl_date.Text = "date";
            // 
            // lbl_date_stat
            // 
            this.lbl_date_stat.AutoSize = true;
            this.lbl_date_stat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_date_stat.Location = new System.Drawing.Point(25, 180);
            this.lbl_date_stat.Name = "lbl_date_stat";
            this.lbl_date_stat.Size = new System.Drawing.Size(53, 24);
            this.lbl_date_stat.TabIndex = 16;
            this.lbl_date_stat.Text = "Date:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(634, 431);
            this.Controls.Add(this.lbl_date);
            this.Controls.Add(this.lbl_date_stat);
            this.Controls.Add(this.lbl_step);
            this.Controls.Add(this.lbl_step_stat);
            this.Controls.Add(this.tbx_parent);
            this.Controls.Add(this.lbl_parent);
            this.Controls.Add(this.btn_export_status);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.lbl_count);
            this.Controls.Add(this.lbl_buid);
            this.Controls.Add(this.lbl_site);
            this.Controls.Add(this.btn_f_post);
            this.Controls.Add(this.btn_n_post);
            this.Controls.Add(this.btn_a_post);
            this.Controls.Add(this.lbl_import_prompt);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.rtb_import);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(650, 470);
            this.MinimumSize = new System.Drawing.Size(650, 470);
            this.Name = "Main";
            this.Text = "StevesSuperSnowImporter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_import;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Label lbl_import_prompt;
        private System.Windows.Forms.Button btn_a_post;
        private System.Windows.Forms.Button btn_n_post;
        private System.Windows.Forms.Button btn_f_post;
        private System.Windows.Forms.Label lbl_site;
        private System.Windows.Forms.Label lbl_buid;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_export_status;
        private System.Windows.Forms.Label lbl_parent;
        private System.Windows.Forms.TextBox tbx_parent;
        private System.Windows.Forms.Label lbl_step;
        private System.Windows.Forms.Label lbl_step_stat;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.Label lbl_date_stat;
    }
}

