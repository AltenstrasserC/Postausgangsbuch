namespace POAusDesign
{
    partial class Statistik
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Sendung 1");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Sendung 2");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Sendung 3");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Sendung 4");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("");
            this.metroListView1 = new MetroFramework.Controls.MetroListView();
            this.Zustellungsdatum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Absender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Empfänger = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Typ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.metroTile3 = new MetroFramework.Controls.MetroTile();
            this.metroTile4 = new MetroFramework.Controls.MetroTile();
            this.metroTile5 = new MetroFramework.Controls.MetroTile();
            this.metroTile6 = new MetroFramework.Controls.MetroTile();
            this.metroTile7 = new MetroFramework.Controls.MetroTile();
            this.metroTile8 = new MetroFramework.Controls.MetroTile();
            this.metroTile9 = new MetroFramework.Controls.MetroTile();
            this.metroTile10 = new MetroFramework.Controls.MetroTile();
            this.metroTile11 = new MetroFramework.Controls.MetroTile();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.pabDBEntitiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pabDBEntitiesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // metroListView1
            // 
            this.metroListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Zustellungsdatum,
            this.Absender,
            this.Empfänger,
            this.Typ});
            this.metroListView1.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.pabDBEntitiesBindingSource, "Packets", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.metroListView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListView1.FullRowSelect = true;
            this.metroListView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9});
            this.metroListView1.Location = new System.Drawing.Point(23, 94);
            this.metroListView1.Name = "metroListView1";
            this.metroListView1.OwnerDraw = true;
            this.metroListView1.Size = new System.Drawing.Size(610, 284);
            this.metroListView1.TabIndex = 0;
            this.metroListView1.UseCompatibleStateImageBehavior = false;
            this.metroListView1.UseSelectable = true;
            this.metroListView1.UseStyleColors = true;
            this.metroListView1.View = System.Windows.Forms.View.Details;
            // 
            // Zustellungsdatum
            // 
            this.Zustellungsdatum.Text = "Zustellungsdatum";
            this.Zustellungsdatum.Width = 180;
            // 
            // Absender
            // 
            this.Absender.Text = "Absender";
            this.Absender.Width = 140;
            // 
            // Empfänger
            // 
            this.Empfänger.Text = "Empfänger";
            this.Empfänger.Width = 167;
            // 
            // Typ
            // 
            this.Typ.Text = "Typ";
            this.Typ.Width = 117;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(883, 34);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(32, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "RSb";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.White;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.metroLabel2.Location = new System.Drawing.Point(842, 34);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(34, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "RSa";
            this.metroLabel2.UseStyleColors = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(789, 34);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(47, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "E-Mail";
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(23, 384);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(50, 40);
            this.metroTile1.TabIndex = 6;
            this.metroTile1.Text = "Aug";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.UseSelectable = true;
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Location = new System.Drawing.Point(79, 384);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(50, 40);
            this.metroTile2.TabIndex = 7;
            this.metroTile2.Text = "Sep";
            this.metroTile2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile2.UseSelectable = true;
            // 
            // metroTile3
            // 
            this.metroTile3.ActiveControl = null;
            this.metroTile3.Location = new System.Drawing.Point(135, 384);
            this.metroTile3.Name = "metroTile3";
            this.metroTile3.Size = new System.Drawing.Size(50, 40);
            this.metroTile3.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroTile3.TabIndex = 8;
            this.metroTile3.Text = "Okt";
            this.metroTile3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile3.UseSelectable = true;
            // 
            // metroTile4
            // 
            this.metroTile4.ActiveControl = null;
            this.metroTile4.Location = new System.Drawing.Point(191, 384);
            this.metroTile4.Name = "metroTile4";
            this.metroTile4.Size = new System.Drawing.Size(50, 40);
            this.metroTile4.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroTile4.TabIndex = 9;
            this.metroTile4.Text = "Nov";
            this.metroTile4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile4.UseSelectable = true;
            // 
            // metroTile5
            // 
            this.metroTile5.ActiveControl = null;
            this.metroTile5.Location = new System.Drawing.Point(247, 384);
            this.metroTile5.Name = "metroTile5";
            this.metroTile5.Size = new System.Drawing.Size(50, 40);
            this.metroTile5.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroTile5.TabIndex = 10;
            this.metroTile5.Text = "Dez";
            this.metroTile5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile5.UseSelectable = true;
            // 
            // metroTile6
            // 
            this.metroTile6.ActiveControl = null;
            this.metroTile6.Location = new System.Drawing.Point(303, 384);
            this.metroTile6.Name = "metroTile6";
            this.metroTile6.Size = new System.Drawing.Size(50, 40);
            this.metroTile6.TabIndex = 11;
            this.metroTile6.Text = "Jan";
            this.metroTile6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile6.UseSelectable = true;
            // 
            // metroTile7
            // 
            this.metroTile7.ActiveControl = null;
            this.metroTile7.Location = new System.Drawing.Point(359, 384);
            this.metroTile7.Name = "metroTile7";
            this.metroTile7.Size = new System.Drawing.Size(50, 40);
            this.metroTile7.TabIndex = 12;
            this.metroTile7.Text = "Feb";
            this.metroTile7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile7.UseSelectable = true;
            // 
            // metroTile8
            // 
            this.metroTile8.ActiveControl = null;
            this.metroTile8.Location = new System.Drawing.Point(415, 384);
            this.metroTile8.Name = "metroTile8";
            this.metroTile8.Size = new System.Drawing.Size(50, 40);
            this.metroTile8.TabIndex = 13;
            this.metroTile8.Text = "Mär";
            this.metroTile8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile8.UseSelectable = true;
            // 
            // metroTile9
            // 
            this.metroTile9.ActiveControl = null;
            this.metroTile9.Location = new System.Drawing.Point(471, 384);
            this.metroTile9.Name = "metroTile9";
            this.metroTile9.Size = new System.Drawing.Size(50, 40);
            this.metroTile9.TabIndex = 14;
            this.metroTile9.Text = "Apr";
            this.metroTile9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile9.UseSelectable = true;
            // 
            // metroTile10
            // 
            this.metroTile10.ActiveControl = null;
            this.metroTile10.Location = new System.Drawing.Point(527, 384);
            this.metroTile10.Name = "metroTile10";
            this.metroTile10.Size = new System.Drawing.Size(50, 40);
            this.metroTile10.TabIndex = 15;
            this.metroTile10.Text = "Jun";
            this.metroTile10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile10.UseSelectable = true;
            // 
            // metroTile11
            // 
            this.metroTile11.ActiveControl = null;
            this.metroTile11.Location = new System.Drawing.Point(583, 384);
            this.metroTile11.Name = "metroTile11";
            this.metroTile11.Size = new System.Drawing.Size(50, 40);
            this.metroTile11.TabIndex = 16;
            this.metroTile11.Text = "Jul";
            this.metroTile11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile11.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(24, 431);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(48, 19);
            this.metroLabel4.TabIndex = 17;
            this.metroLabel4.Text = "| 2017";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(747, 34);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(36, 19);
            this.metroLabel5.TabIndex = 18;
            this.metroLabel5.Text = "Brief";
            // 
            // pabDBEntitiesBindingSource
            // 
            this.pabDBEntitiesBindingSource.DataSource = typeof(PabDbLib.PabDBContext);
            // 
            // Statistik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 470);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroTile11);
            this.Controls.Add(this.metroTile10);
            this.Controls.Add(this.metroTile9);
            this.Controls.Add(this.metroTile8);
            this.Controls.Add(this.metroTile7);
            this.Controls.Add(this.metroTile6);
            this.Controls.Add(this.metroTile5);
            this.Controls.Add(this.metroTile4);
            this.Controls.Add(this.metroTile3);
            this.Controls.Add(this.metroTile2);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroListView1);
            this.Name = "Statistik";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Statistik";
            this.Load += new System.EventHandler(this.Statistik_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pabDBEntitiesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroListView metroListView1;
        private System.Windows.Forms.ColumnHeader Zustellungsdatum;
        private System.Windows.Forms.ColumnHeader Absender;
        private System.Windows.Forms.ColumnHeader Empfänger;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroTile metroTile3;
        private MetroFramework.Controls.MetroTile metroTile4;
        private MetroFramework.Controls.MetroTile metroTile5;
        private MetroFramework.Controls.MetroTile metroTile6;
        private MetroFramework.Controls.MetroTile metroTile7;
        private MetroFramework.Controls.MetroTile metroTile8;
        private MetroFramework.Controls.MetroTile metroTile9;
        private MetroFramework.Controls.MetroTile metroTile10;
        private MetroFramework.Controls.MetroTile metroTile11;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.ColumnHeader Typ;
        private System.Windows.Forms.BindingSource pabDBEntitiesBindingSource;
    }
}