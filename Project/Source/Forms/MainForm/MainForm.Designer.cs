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
      this.ActionCreateTable = new System.Windows.Forms.Button();
      this.ActionLoadFile = new System.Windows.Forms.Button();
      this.ActionSaveFixedDuplicatesToFile = new System.Windows.Forms.Button();
      this.ActionCheckDuplicates = new System.Windows.Forms.Button();
      this.StatusStrip = new System.Windows.Forms.StatusStrip();
      this.LabelStatusProgress = new System.Windows.Forms.ToolStripStatusLabel();
      this.LabelStatusTime = new System.Windows.Forms.ToolStripStatusLabel();
      this.ActionDbBatch = new System.Windows.Forms.Button();
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
      this.Grid.Size = new System.Drawing.Size(800, 620);
      this.Grid.TabIndex = 0;
      this.Grid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.Grid_RowPostPaint);
      this.Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
      // 
      // Panel
      // 
      this.Panel.Controls.Add(this.SelectFileName);
      this.Panel.Controls.Add(this.ActionDbBatch);
      this.Panel.Controls.Add(this.ActionCreateTable);
      this.Panel.Controls.Add(this.ActionLoadFile);
      this.Panel.Controls.Add(this.ActionSaveFixedDuplicatesToFile);
      this.Panel.Controls.Add(this.ActionCheckDuplicates);
      this.Panel.Dock = System.Windows.Forms.DockStyle.Top;
      this.Panel.Location = new System.Drawing.Point(0, 0);
      this.Panel.Name = "Panel";
      this.Panel.Size = new System.Drawing.Size(800, 75);
      this.Panel.TabIndex = 1;
      // 
      // SelectFileName
      // 
      this.SelectFileName.FormattingEnabled = true;
      this.SelectFileName.Location = new System.Drawing.Point(12, 12);
      this.SelectFileName.Name = "SelectFileName";
      this.SelectFileName.Size = new System.Drawing.Size(121, 21);
      this.SelectFileName.TabIndex = 3;
      this.SelectFileName.SelectedIndexChanged += new System.EventHandler(this.SelectFileName_SelectedIndexChanged);
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
      // ActionDbBatch
      // 
      this.ActionDbBatch.Location = new System.Drawing.Point(240, 39);
      this.ActionDbBatch.Name = "ActionDbBatch";
      this.ActionDbBatch.Size = new System.Drawing.Size(95, 23);
      this.ActionDbBatch.TabIndex = 2;
      this.ActionDbBatch.Text = "Batch";
      this.ActionDbBatch.UseVisualStyleBackColor = true;
      this.ActionDbBatch.Click += new System.EventHandler(this.ActionDbBatch_Click);
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
    private Button ActionCheckDuplicates;
    private Button ActionSaveFixedDuplicatesToFile;
    private ComboBox SelectFileName;
    private Button ActionCreateTable;
    private Button ActionLoadFile;
    private StatusStrip StatusStrip;
    private ToolStripStatusLabel LabelStatusProgress;
    private ToolStripStatusLabel LabelStatusTime;
    private Button ActionDbBatch;
  }
}
