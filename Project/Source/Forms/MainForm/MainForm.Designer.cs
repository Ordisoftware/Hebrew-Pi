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
      this.Panel = new System.Windows.Forms.Panel();
      this.SelectFileName = new System.Windows.Forms.ComboBox();
      this.ActionStopBatch = new System.Windows.Forms.Button();
      this.ActionRunBatch = new System.Windows.Forms.Button();
      this.ActionDbConnect = new System.Windows.Forms.Button();
      this.ActionCreateTables = new System.Windows.Forms.Button();
      this.ActionLoadFile = new System.Windows.Forms.Button();
      this.ActionSaveFixedDuplicatesToFile = new System.Windows.Forms.Button();
      this.ActionCheckDuplicates = new System.Windows.Forms.Button();
      this.StatusStrip = new System.Windows.Forms.StatusStrip();
      this.LabelStatusTime = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.LabelStatusIteration = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
      this.LabelStatusInfo = new System.Windows.Forms.ToolStripStatusLabel();
      ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
      this.Panel.SuspendLayout();
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
      // Panel
      // 
      this.Panel.Controls.Add(this.SelectFileName);
      this.Panel.Controls.Add(this.ActionStopBatch);
      this.Panel.Controls.Add(this.ActionRunBatch);
      this.Panel.Controls.Add(this.ActionDbConnect);
      this.Panel.Controls.Add(this.ActionCreateTables);
      this.Panel.Controls.Add(this.ActionLoadFile);
      this.Panel.Controls.Add(this.ActionSaveFixedDuplicatesToFile);
      this.Panel.Controls.Add(this.ActionCheckDuplicates);
      this.Panel.Dock = System.Windows.Forms.DockStyle.Top;
      this.Panel.Location = new System.Drawing.Point(0, 0);
      this.Panel.Name = "Panel";
      this.Panel.Size = new System.Drawing.Size(784, 75);
      this.Panel.TabIndex = 1;
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
      // ActionStopBatch
      // 
      this.ActionStopBatch.Enabled = false;
      this.ActionStopBatch.Location = new System.Drawing.Point(341, 39);
      this.ActionStopBatch.Name = "ActionStopBatch";
      this.ActionStopBatch.Size = new System.Drawing.Size(95, 23);
      this.ActionStopBatch.TabIndex = 2;
      this.ActionStopBatch.Text = "Stop batch";
      this.ActionStopBatch.UseVisualStyleBackColor = true;
      this.ActionStopBatch.Click += new System.EventHandler(this.ActionStopBatch_Click);
      // 
      // ActionRunBatch
      // 
      this.ActionRunBatch.Enabled = false;
      this.ActionRunBatch.Location = new System.Drawing.Point(240, 39);
      this.ActionRunBatch.Name = "ActionRunBatch";
      this.ActionRunBatch.Size = new System.Drawing.Size(95, 23);
      this.ActionRunBatch.TabIndex = 2;
      this.ActionRunBatch.Text = "Run batch";
      this.ActionRunBatch.UseVisualStyleBackColor = true;
      this.ActionRunBatch.Click += new System.EventHandler(this.ActionRunBatch_Click);
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
      // ActionCreateTables
      // 
      this.ActionCreateTables.Enabled = false;
      this.ActionCreateTables.Location = new System.Drawing.Point(139, 39);
      this.ActionCreateTables.Name = "ActionCreateTables";
      this.ActionCreateTables.Size = new System.Drawing.Size(95, 23);
      this.ActionCreateTables.TabIndex = 2;
      this.ActionCreateTables.Text = "Create tables";
      this.ActionCreateTables.UseVisualStyleBackColor = true;
      this.ActionCreateTables.Click += new System.EventHandler(this.ActionCreateTables_Click);
      // 
      // ActionLoadFile
      // 
      this.ActionLoadFile.Location = new System.Drawing.Point(139, 10);
      this.ActionLoadFile.Name = "ActionLoadFile";
      this.ActionLoadFile.Size = new System.Drawing.Size(95, 23);
      this.ActionLoadFile.TabIndex = 1;
      this.ActionLoadFile.Text = "Load File";
      this.ActionLoadFile.UseVisualStyleBackColor = true;
      this.ActionLoadFile.Click += new System.EventHandler(this.ActionLoadFile_Click);
      // 
      // ActionSaveFixedDuplicatesToFile
      // 
      this.ActionSaveFixedDuplicatesToFile.Enabled = false;
      this.ActionSaveFixedDuplicatesToFile.Location = new System.Drawing.Point(341, 10);
      this.ActionSaveFixedDuplicatesToFile.Name = "ActionSaveFixedDuplicatesToFile";
      this.ActionSaveFixedDuplicatesToFile.Size = new System.Drawing.Size(95, 23);
      this.ActionSaveFixedDuplicatesToFile.TabIndex = 0;
      this.ActionSaveFixedDuplicatesToFile.Text = "Save fix dup.";
      this.ActionSaveFixedDuplicatesToFile.UseVisualStyleBackColor = true;
      this.ActionSaveFixedDuplicatesToFile.Click += new System.EventHandler(this.ActionSaveFixedRepeatedToFile_Click);
      // 
      // ActionCheckDuplicates
      // 
      this.ActionCheckDuplicates.Location = new System.Drawing.Point(240, 10);
      this.ActionCheckDuplicates.Name = "ActionCheckDuplicates";
      this.ActionCheckDuplicates.Size = new System.Drawing.Size(95, 23);
      this.ActionCheckDuplicates.TabIndex = 0;
      this.ActionCheckDuplicates.Text = "Check dup.";
      this.ActionCheckDuplicates.UseVisualStyleBackColor = true;
      this.ActionCheckDuplicates.Click += new System.EventHandler(this.ActionCheckRepeated_Click);
      // 
      // StatusStrip
      // 
      this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelStatusTime,
            this.toolStripStatusLabel1,
            this.LabelStatusIteration,
            this.toolStripStatusLabel2,
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
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
      this.toolStripStatusLabel1.Text = "|";
      // 
      // LabelStatusIteration
      // 
      this.LabelStatusIteration.Name = "LabelStatusIteration";
      this.LabelStatusIteration.Size = new System.Drawing.Size(51, 17);
      this.LabelStatusIteration.Text = "Iteration";
      // 
      // toolStripStatusLabel2
      // 
      this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
      this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
      this.toolStripStatusLabel2.Text = "|";
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
      this.Controls.Add(this.Panel);
      this.Controls.Add(this.StatusStrip);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Hebrew Pi";
      ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
      this.Panel.ResumeLayout(false);
      this.StatusStrip.ResumeLayout(false);
      this.StatusStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DataGridView Grid;
    private Panel Panel;
    private Button ActionCheckDuplicates;
    private Button ActionSaveFixedDuplicatesToFile;
    private ComboBox SelectFileName;
    private Button ActionCreateTables;
    private Button ActionLoadFile;
    private StatusStrip StatusStrip;
    private Button ActionRunBatch;
    private Button ActionDbConnect;
    private ToolStripStatusLabel LabelStatusIteration;
    private ToolStripStatusLabel LabelStatusTime;
    private Button ActionStopBatch;
    private ToolStripStatusLabel LabelStatusInfo;
    private ToolStripStatusLabel toolStripStatusLabel1;
    private ToolStripStatusLabel toolStripStatusLabel2;
  }
}
