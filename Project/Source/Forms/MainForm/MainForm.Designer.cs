namespace Ordisoftware.Hebrew.Pi
{
  partial class MainForm
  {
    /// <summary>
    /// Variable nécessaire au concepteur.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Nettoyage des ressources utilisées.
    /// </summary>
    /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
    protected override void Dispose(bool disposing)
    {
      if ( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Code généré par le Concepteur Windows Form

    /// <summary>
    /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
    /// le contenu de cette méthode avec l'éditeur de code.
    /// </summary>
    private void InitializeComponent()
    {
      this.Grid = new System.Windows.Forms.DataGridView();
      this.PanelTop = new System.Windows.Forms.Panel();
      this.SelectFileName = new System.Windows.Forms.ComboBox();
      this.ActionBatchPause = new System.Windows.Forms.Button();
      this.ActionBatchStop = new System.Windows.Forms.Button();
      this.ActionBatchRun = new System.Windows.Forms.Button();
      this.ActionDbClose = new System.Windows.Forms.Button();
      this.ActionDbOpen = new System.Windows.Forms.Button();
      this.ActionDbCreateData = new System.Windows.Forms.Button();
      this.StatusStrip = new System.Windows.Forms.StatusStrip();
      this.LabelStatusTime = new System.Windows.Forms.ToolStripStatusLabel();
      this.LabelStatusSep1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.LabelStatusIteration = new System.Windows.Forms.ToolStripStatusLabel();
      this.LabelStatusSep2 = new System.Windows.Forms.ToolStripStatusLabel();
      this.LabelStatusInfo = new System.Windows.Forms.ToolStripStatusLabel();
      ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
      this.PanelTop.SuspendLayout();
      this.StatusStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // Grid
      // 
      this.Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Grid.Location = new System.Drawing.Point(0, 50);
      this.Grid.Name = "Grid";
      this.Grid.RowHeadersWidth = 100;
      this.Grid.Size = new System.Drawing.Size(784, 389);
      this.Grid.TabIndex = 0;
      this.Grid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.Grid_RowPostPaint);
      this.Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
      // 
      // PanelTop
      // 
      this.PanelTop.Controls.Add(this.SelectFileName);
      this.PanelTop.Controls.Add(this.ActionBatchPause);
      this.PanelTop.Controls.Add(this.ActionBatchStop);
      this.PanelTop.Controls.Add(this.ActionBatchRun);
      this.PanelTop.Controls.Add(this.ActionDbClose);
      this.PanelTop.Controls.Add(this.ActionDbOpen);
      this.PanelTop.Controls.Add(this.ActionDbCreateData);
      this.PanelTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.PanelTop.Location = new System.Drawing.Point(0, 0);
      this.PanelTop.Name = "PanelTop";
      this.PanelTop.Size = new System.Drawing.Size(784, 50);
      this.PanelTop.TabIndex = 1;
      // 
      // SelectFileName
      // 
      this.SelectFileName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.SelectFileName.FormattingEnabled = true;
      this.SelectFileName.Location = new System.Drawing.Point(12, 15);
      this.SelectFileName.Name = "SelectFileName";
      this.SelectFileName.Size = new System.Drawing.Size(121, 21);
      this.SelectFileName.TabIndex = 3;
      this.SelectFileName.SelectedIndexChanged += new System.EventHandler(this.SelectFileName_SelectedIndexChanged);
      // 
      // ActionBatchPause
      // 
      this.ActionBatchPause.Enabled = false;
      this.ActionBatchPause.Location = new System.Drawing.Point(569, 14);
      this.ActionBatchPause.Name = "ActionBatchPause";
      this.ActionBatchPause.Size = new System.Drawing.Size(95, 23);
      this.ActionBatchPause.TabIndex = 2;
      this.ActionBatchPause.Text = "Pause batch";
      this.ActionBatchPause.UseVisualStyleBackColor = true;
      this.ActionBatchPause.Click += new System.EventHandler(this.ActionBatchPause_Click);
      // 
      // ActionBatchStop
      // 
      this.ActionBatchStop.Enabled = false;
      this.ActionBatchStop.Location = new System.Drawing.Point(468, 14);
      this.ActionBatchStop.Name = "ActionBatchStop";
      this.ActionBatchStop.Size = new System.Drawing.Size(95, 23);
      this.ActionBatchStop.TabIndex = 2;
      this.ActionBatchStop.Text = "Stop batch";
      this.ActionBatchStop.UseVisualStyleBackColor = true;
      this.ActionBatchStop.Click += new System.EventHandler(this.ActionBatchStop_Click);
      // 
      // ActionBatchRun
      // 
      this.ActionBatchRun.Enabled = false;
      this.ActionBatchRun.Location = new System.Drawing.Point(367, 14);
      this.ActionBatchRun.Name = "ActionBatchRun";
      this.ActionBatchRun.Size = new System.Drawing.Size(95, 23);
      this.ActionBatchRun.TabIndex = 2;
      this.ActionBatchRun.Text = "Run batch";
      this.ActionBatchRun.UseVisualStyleBackColor = true;
      this.ActionBatchRun.Click += new System.EventHandler(this.ActionBatchRun_Click);
      // 
      // ActionDbClose
      // 
      this.ActionDbClose.Enabled = false;
      this.ActionDbClose.Location = new System.Drawing.Point(203, 14);
      this.ActionDbClose.Name = "ActionDbClose";
      this.ActionDbClose.Size = new System.Drawing.Size(58, 23);
      this.ActionDbClose.TabIndex = 2;
      this.ActionDbClose.Text = "Close";
      this.ActionDbClose.UseVisualStyleBackColor = true;
      this.ActionDbClose.Click += new System.EventHandler(this.ActionDbClose_Click);
      // 
      // ActionDbOpen
      // 
      this.ActionDbOpen.Enabled = false;
      this.ActionDbOpen.Location = new System.Drawing.Point(139, 14);
      this.ActionDbOpen.Name = "ActionDbOpen";
      this.ActionDbOpen.Size = new System.Drawing.Size(58, 23);
      this.ActionDbOpen.TabIndex = 2;
      this.ActionDbOpen.Text = "Open";
      this.ActionDbOpen.UseVisualStyleBackColor = true;
      this.ActionDbOpen.Click += new System.EventHandler(this.ActionDbOpen_Click);
      // 
      // ActionDbCreateData
      // 
      this.ActionDbCreateData.Enabled = false;
      this.ActionDbCreateData.Location = new System.Drawing.Point(266, 14);
      this.ActionDbCreateData.Name = "ActionDbCreateData";
      this.ActionDbCreateData.Size = new System.Drawing.Size(95, 23);
      this.ActionDbCreateData.TabIndex = 2;
      this.ActionDbCreateData.Text = "Create data";
      this.ActionDbCreateData.UseVisualStyleBackColor = true;
      this.ActionDbCreateData.Click += new System.EventHandler(this.ActionDbCreateData_Click);
      // 
      // StatusStrip
      // 
      this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelStatusTime,
            this.LabelStatusSep1,
            this.LabelStatusIteration,
            this.LabelStatusSep2,
            this.LabelStatusInfo});
      this.StatusStrip.Location = new System.Drawing.Point(0, 439);
      this.StatusStrip.Name = "StatusStrip";
      this.StatusStrip.Size = new System.Drawing.Size(784, 22);
      this.StatusStrip.TabIndex = 2;
      this.StatusStrip.Text = "statusStrip1";
      // 
      // LabelStatusTime
      // 
      this.LabelStatusTime.Name = "LabelStatusTime";
      this.LabelStatusTime.Size = new System.Drawing.Size(33, 17);
      this.LabelStatusTime.Text = "Time";
      // 
      // LabelStatusSep1
      // 
      this.LabelStatusSep1.Name = "LabelStatusSep1";
      this.LabelStatusSep1.Size = new System.Drawing.Size(10, 17);
      this.LabelStatusSep1.Text = "|";
      // 
      // LabelStatusIteration
      // 
      this.LabelStatusIteration.Name = "LabelStatusIteration";
      this.LabelStatusIteration.Size = new System.Drawing.Size(51, 17);
      this.LabelStatusIteration.Text = "Iteration";
      // 
      // LabelStatusSep2
      // 
      this.LabelStatusSep2.Name = "LabelStatusSep2";
      this.LabelStatusSep2.Size = new System.Drawing.Size(10, 17);
      this.LabelStatusSep2.Text = "|";
      // 
      // LabelStatusInfo
      // 
      this.LabelStatusInfo.Name = "LabelStatusInfo";
      this.LabelStatusInfo.Size = new System.Drawing.Size(28, 17);
      this.LabelStatusInfo.Text = "Info";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(784, 461);
      this.Controls.Add(this.Grid);
      this.Controls.Add(this.PanelTop);
      this.Controls.Add(this.StatusStrip);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Hebrew Pi";
      ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
      this.PanelTop.ResumeLayout(false);
      this.StatusStrip.ResumeLayout(false);
      this.StatusStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DataGridView Grid;
    private Panel PanelTop;
    private ComboBox SelectFileName;
    private Button ActionDbCreateData;
    private StatusStrip StatusStrip;
    private Button ActionBatchRun;
    private Button ActionDbOpen;
    private ToolStripStatusLabel LabelStatusIteration;
    private ToolStripStatusLabel LabelStatusTime;
    private Button ActionBatchStop;
    private ToolStripStatusLabel LabelStatusInfo;
    private ToolStripStatusLabel LabelStatusSep1;
    private ToolStripStatusLabel LabelStatusSep2;
    private Button ActionBatchPause;
    private Button ActionDbClose;
  }
}
