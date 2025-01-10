namespace Ordisoftware.Hebrew.PiDecoder
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
      this.ActionSave = new System.Windows.Forms.Button();
      this.ActionCheck = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
      this.Panel.SuspendLayout();
      this.SuspendLayout();
      // 
      // Grid
      // 
      this.Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Grid.Location = new System.Drawing.Point(0, 50);
      this.Grid.Name = "Grid";
      this.Grid.Size = new System.Drawing.Size(800, 667);
      this.Grid.TabIndex = 0;
      this.Grid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.Grid_RowPostPaint);
      this.Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
      // 
      // Panel
      // 
      this.Panel.Controls.Add(this.ActionSave);
      this.Panel.Controls.Add(this.ActionCheck);
      this.Panel.Dock = System.Windows.Forms.DockStyle.Top;
      this.Panel.Location = new System.Drawing.Point(0, 0);
      this.Panel.Name = "Panel";
      this.Panel.Size = new System.Drawing.Size(800, 50);
      this.Panel.TabIndex = 1;
      // 
      // ActionSave
      // 
      this.ActionSave.Enabled = false;
      this.ActionSave.Location = new System.Drawing.Point(93, 12);
      this.ActionSave.Name = "ActionSave";
      this.ActionSave.Size = new System.Drawing.Size(75, 23);
      this.ActionSave.TabIndex = 0;
      this.ActionSave.Text = "Corriger";
      this.ActionSave.UseVisualStyleBackColor = true;
      this.ActionSave.Click += new System.EventHandler(this.ActionSave_Click);
      // 
      // ActionCheck
      // 
      this.ActionCheck.Location = new System.Drawing.Point(12, 12);
      this.ActionCheck.Name = "ActionCheck";
      this.ActionCheck.Size = new System.Drawing.Size(75, 23);
      this.ActionCheck.TabIndex = 0;
      this.ActionCheck.Text = "Vérifier";
      this.ActionCheck.UseVisualStyleBackColor = true;
      this.ActionCheck.Click += new System.EventHandler(this.ActionCheck_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 717);
      this.Controls.Add(this.Grid);
      this.Controls.Add(this.Panel);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Hebrew PiDecoder";
      this.Load += new System.EventHandler(this.MainForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
      this.Panel.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DataGridView Grid;
    private Panel Panel;
    private Button ActionCheck;
    private Button ActionSave;
  }
}
