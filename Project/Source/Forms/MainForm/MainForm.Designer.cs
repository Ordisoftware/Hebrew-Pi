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
      this.ActionStopBatch = new System.Windows.Forms.Button();
      this.ActionBatchRun = new System.Windows.Forms.Button();
      this.ActionDbConnect = new System.Windows.Forms.Button();
      this.ActionDbCreate = new System.Windows.Forms.Button();
      this.ActionFileLoad = new System.Windows.Forms.Button();
      this.ActionFileSaveFixed = new System.Windows.Forms.Button();
      this.ActionFileCheckRepeated = new System.Windows.Forms.Button();
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
      this.Grid.Location = new System.Drawing.Point(0, 75);
      this.Grid.Name = "Grid";
      this.Grid.RowHeadersWidth = 100;
      this.Grid.Size = new System.Drawing.Size(784, 364);
      this.Grid.TabIndex = 0;
      this.Grid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.Grid_RowPostPaint);
      this.Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
      // 
      // PanelTop
      // 
      this.PanelTop.Controls.Add(this.SelectFileName);
      this.PanelTop.Controls.Add(this.ActionBatchPause);
      this.PanelTop.Controls.Add(this.ActionStopBatch);
      this.PanelTop.Controls.Add(this.ActionBatchRun);
      this.PanelTop.Controls.Add(this.ActionDbConnect);
      this.PanelTop.Controls.Add(this.ActionDbCreate);
      this.PanelTop.Controls.Add(this.ActionFileLoad);
      this.PanelTop.Controls.Add(this.ActionFileSaveFixed);
      this.PanelTop.Controls.Add(this.ActionFileCheckRepeated);
      this.PanelTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.PanelTop.Location = new System.Drawing.Point(0, 0);
      this.PanelTop.Name = "PanelTop";
      this.PanelTop.Size = new System.Drawing.Size(784, 75);
      this.PanelTop.TabIndex = 1;
      // 
      // SelectFileName
      // 
      this.SelectFileName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.SelectFileName.FormattingEnabled = true;
      this.SelectFileName.Location = new System.Drawing.Point(12, 12);
      this.SelectFileName.Name = "SelectFileName";
      this.SelectFileName.Size = new System.Drawing.Size(121, 21);
      this.SelectFileName.TabIndex = 3;
      this.SelectFileName.SelectedIndexChanged += new System.EventHandler(this.SelectFileName_SelectedIndexChanged);
      // 
      // ActionBatchPause
      // 
      this.ActionBatchPause.Enabled = false;
      this.ActionBatchPause.Location = new System.Drawing.Point(442, 39);
      this.ActionBatchPause.Name = "ActionBatchPause";
      this.ActionBatchPause.Size = new System.Drawing.Size(95, 23);
      this.ActionBatchPause.TabIndex = 2;
      this.ActionBatchPause.Text = "Stop batch";
      this.ActionBatchPause.UseVisualStyleBackColor = true;
      this.ActionBatchPause.Click += new System.EventHandler(this.ActionBatchStop_Click);
      // 
      // ActionStopBatch
      // 
      this.ActionStopBatch.Enabled = false;
      this.ActionStopBatch.Location = new System.Drawing.Point(341, 39);
      this.ActionStopBatch.Name = "ActionStopBatch";
      this.ActionStopBatch.Size = new System.Drawing.Size(95, 23);
      this.ActionStopBatch.TabIndex = 2;
      this.ActionStopBatch.Text = "Stop batch";
      this.ActionStopBatch.UseVisualStyleBackColor = true;
      this.ActionStopBatch.Click += new System.EventHandler(this.ActionBatchStop_Click);
      // 
      // ActionBatchRun
      // 
      this.ActionBatchRun.Enabled = false;
      this.ActionBatchRun.Location = new System.Drawing.Point(240, 39);
      this.ActionBatchRun.Name = "ActionBatchRun";
      this.ActionBatchRun.Size = new System.Drawing.Size(95, 23);
      this.ActionBatchRun.TabIndex = 2;
      this.ActionBatchRun.Text = "Run batch";
      this.ActionBatchRun.UseVisualStyleBackColor = true;
      this.ActionBatchRun.Click += new System.EventHandler(this.ActionBatchRun_Click);
      // 
      // ActionDbConnect
      // 
      this.ActionDbConnect.Location = new System.Drawing.Point(38, 39);
      this.ActionDbConnect.Name = "ActionDbConnect";
      this.ActionDbConnect.Size = new System.Drawing.Size(95, 23);
      this.ActionDbConnect.TabIndex = 2;
      this.ActionDbConnect.Text = "Db connect";
      this.ActionDbConnect.UseVisualStyleBackColor = true;
      this.ActionDbConnect.Click += new System.EventHandler(this.ActionDbConnect_Click);
      // 
      // ActionDbCreate
      // 
      this.ActionDbCreate.Enabled = false;
      this.ActionDbCreate.Location = new System.Drawing.Point(139, 39);
      this.ActionDbCreate.Name = "ActionDbCreate";
      this.ActionDbCreate.Size = new System.Drawing.Size(95, 23);
      this.ActionDbCreate.TabIndex = 2;
      this.ActionDbCreate.Text = "Create tables";
      this.ActionDbCreate.UseVisualStyleBackColor = true;
      this.ActionDbCreate.Click += new System.EventHandler(this.ActionDbCreate_Click);
      // 
      // ActionFileLoad
      // 
      this.ActionFileLoad.Location = new System.Drawing.Point(139, 10);
      this.ActionFileLoad.Name = "ActionFileLoad";
      this.ActionFileLoad.Size = new System.Drawing.Size(95, 23);
      this.ActionFileLoad.TabIndex = 1;
      this.ActionFileLoad.Text = "Load File";
      this.ActionFileLoad.UseVisualStyleBackColor = true;
      this.ActionFileLoad.Click += new System.EventHandler(this.ActionFileLoad_Click);
      // 
      // ActionFileSaveFixed
      // 
      this.ActionFileSaveFixed.Enabled = false;
      this.ActionFileSaveFixed.Location = new System.Drawing.Point(341, 10);
      this.ActionFileSaveFixed.Name = "ActionFileSaveFixed";
      this.ActionFileSaveFixed.Size = new System.Drawing.Size(95, 23);
      this.ActionFileSaveFixed.TabIndex = 0;
      this.ActionFileSaveFixed.Text = "Save fix dup.";
      this.ActionFileSaveFixed.UseVisualStyleBackColor = true;
      this.ActionFileSaveFixed.Click += new System.EventHandler(this.ActionFileSaveFixedRepeating);
      // 
      // ActionFileCheckRepeated
      // 
      this.ActionFileCheckRepeated.Location = new System.Drawing.Point(240, 10);
      this.ActionFileCheckRepeated.Name = "ActionFileCheckRepeated";
      this.ActionFileCheckRepeated.Size = new System.Drawing.Size(95, 23);
      this.ActionFileCheckRepeated.TabIndex = 0;
      this.ActionFileCheckRepeated.Text = "Check dup.";
      this.ActionFileCheckRepeated.UseVisualStyleBackColor = true;
      this.ActionFileCheckRepeated.Click += new System.EventHandler(this.ActionFileCheckRepeated_Click);
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
    private Button ActionFileCheckRepeated;
    private Button ActionFileSaveFixed;
    private ComboBox SelectFileName;
    private Button ActionDbCreate;
    private Button ActionFileLoad;
    private StatusStrip StatusStrip;
    private Button ActionBatchRun;
    private Button ActionDbConnect;
    private ToolStripStatusLabel LabelStatusIteration;
    private ToolStripStatusLabel LabelStatusTime;
    private Button ActionStopBatch;
    private ToolStripStatusLabel LabelStatusInfo;
    private ToolStripStatusLabel LabelStatusSep1;
    private ToolStripStatusLabel LabelStatusSep2;
    private Button ActionBatchPause;
  }
}
