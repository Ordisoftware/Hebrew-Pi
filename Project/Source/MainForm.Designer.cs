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
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.ActionCreateTable = new System.Windows.Forms.Button();
      this.ActionLoadFile = new System.Windows.Forms.Button();
      this.ActionSave = new System.Windows.Forms.Button();
      this.ActionCheck = new System.Windows.Forms.Button();
      this.StatusStrip = new System.Windows.Forms.StatusStrip();
      this.LabelStatusProgress = new System.Windows.Forms.ToolStripStatusLabel();
      this.LabelStatusTime = new System.Windows.Forms.ToolStripStatusLabel();
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
      this.Grid.Size = new System.Drawing.Size(800, 620);
      this.Grid.TabIndex = 0;
      this.Grid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.Grid_RowPostPaint);
      this.Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
      // 
      // Panel
      // 
      this.Panel.Controls.Add(this.comboBox1);
      this.Panel.Controls.Add(this.ActionCreateTable);
      this.Panel.Controls.Add(this.ActionLoadFile);
      this.Panel.Controls.Add(this.ActionSave);
      this.Panel.Controls.Add(this.ActionCheck);
      this.Panel.Dock = System.Windows.Forms.DockStyle.Top;
      this.Panel.Location = new System.Drawing.Point(0, 0);
      this.Panel.Name = "Panel";
      this.Panel.Size = new System.Drawing.Size(800, 75);
      this.Panel.TabIndex = 1;
      // 
      // comboBox1
      // 
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new System.Drawing.Point(12, 12);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(121, 21);
      this.comboBox1.TabIndex = 3;
      // 
      // ActionCreateTable
      // 
      this.ActionCreateTable.Location = new System.Drawing.Point(139, 39);
      this.ActionCreateTable.Name = "ActionCreateTable";
      this.ActionCreateTable.Size = new System.Drawing.Size(95, 23);
      this.ActionCreateTable.TabIndex = 2;
      this.ActionCreateTable.Text = "Create table";
      this.ActionCreateTable.UseVisualStyleBackColor = true;
      this.ActionCreateTable.Click += new System.EventHandler(this.ActionCreateTable_Click);
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
      // ActionSave
      // 
      this.ActionSave.Enabled = false;
      this.ActionSave.Location = new System.Drawing.Point(341, 10);
      this.ActionSave.Name = "ActionSave";
      this.ActionSave.Size = new System.Drawing.Size(95, 23);
      this.ActionSave.TabIndex = 0;
      this.ActionSave.Text = "Save fix dup.";
      this.ActionSave.UseVisualStyleBackColor = true;
      this.ActionSave.Click += new System.EventHandler(this.ActionSave_Click);
      // 
      // ActionCheck
      // 
      this.ActionCheck.Location = new System.Drawing.Point(240, 10);
      this.ActionCheck.Name = "ActionCheck";
      this.ActionCheck.Size = new System.Drawing.Size(95, 23);
      this.ActionCheck.TabIndex = 0;
      this.ActionCheck.Text = "Check dup.";
      this.ActionCheck.UseVisualStyleBackColor = true;
      this.ActionCheck.Click += new System.EventHandler(this.ActionCheck_Click);
      // 
      // StatusStrip
      // 
      this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelStatusProgress,
            this.LabelStatusTime});
      this.StatusStrip.Location = new System.Drawing.Point(0, 695);
      this.StatusStrip.Name = "StatusStrip";
      this.StatusStrip.Size = new System.Drawing.Size(800, 22);
      this.StatusStrip.TabIndex = 2;
      this.StatusStrip.Text = "statusStrip1";
      // 
      // LabelStatusProgress
      // 
      this.LabelStatusProgress.Name = "LabelStatusProgress";
      this.LabelStatusProgress.Size = new System.Drawing.Size(0, 17);
      // 
      // LabelStatusTime
      // 
      this.LabelStatusTime.Name = "LabelStatusTime";
      this.LabelStatusTime.Size = new System.Drawing.Size(0, 17);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 717);
      this.Controls.Add(this.Grid);
      this.Controls.Add(this.StatusStrip);
      this.Controls.Add(this.Panel);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Hebrew Pi";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
    private Button ActionCheck;
    private Button ActionSave;
    private ComboBox comboBox1;
    private Button ActionCreateTable;
    private Button ActionLoadFile;
    private StatusStrip StatusStrip;
    private ToolStripStatusLabel LabelStatusProgress;
    private ToolStripStatusLabel LabelStatusTime;
  }
}
