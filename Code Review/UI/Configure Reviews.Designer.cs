namespace TFS.Policies.UI
{
  partial class ConfigureReviews
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
      this.btnSave = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.gvCodeReviews = new System.Windows.Forms.DataGridView();
      this.gvCodeReviews_Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.gvCodeReviews_Reviews = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.gvCodeReviews)).BeginInit();
      this.SuspendLayout();
      // 
      // btnSave
      // 
      this.btnSave.AutoSize = true;
      this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnSave.Location = new System.Drawing.Point(197, 178);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(87, 34);
      this.btnSave.TabIndex = 2;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      this.btnCancel.AutoSize = true;
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(306, 178);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 34);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // gvCodeReviews
      // 
      this.gvCodeReviews.AllowUserToAddRows = false;
      this.gvCodeReviews.AllowUserToDeleteRows = false;
      this.gvCodeReviews.AllowUserToResizeColumns = false;
      this.gvCodeReviews.AllowUserToResizeRows = false;
      this.gvCodeReviews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gvCodeReviews.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gvCodeReviews_Group,
            this.gvCodeReviews_Reviews});
      this.gvCodeReviews.Location = new System.Drawing.Point(12, 12);
      this.gvCodeReviews.Name = "gvCodeReviews";
      this.gvCodeReviews.RowTemplate.Height = 24;
      this.gvCodeReviews.Size = new System.Drawing.Size(369, 150);
      this.gvCodeReviews.TabIndex = 4;
      this.gvCodeReviews.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCodeReviews_CellValueChanged);
      // 
      // gvCodeReviews_Group
      // 
      this.gvCodeReviews_Group.HeaderText = "Group";
      this.gvCodeReviews_Group.Name = "gvCodeReviews_Group";
      this.gvCodeReviews_Group.ReadOnly = true;
      this.gvCodeReviews_Group.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.gvCodeReviews_Group.Width = 225;
      // 
      // gvCodeReviews_Reviews
      // 
      this.gvCodeReviews_Reviews.HeaderText = "Reviews";
      this.gvCodeReviews_Reviews.MaxInputLength = 2;
      this.gvCodeReviews_Reviews.Name = "gvCodeReviews_Reviews";
      this.gvCodeReviews_Reviews.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.gvCodeReviews_Reviews.Width = 75;
      // 
      // ConfigureReviews
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(393, 224);
      this.Controls.Add(this.gvCodeReviews);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnSave);
      this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ConfigureReviews";
      this.Text = "Configure Code Reviews";
      ((System.ComponentModel.ISupportInitialize)(this.gvCodeReviews)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.DataGridView gvCodeReviews;
    private System.Windows.Forms.DataGridViewTextBoxColumn gvCodeReviews_Group;
    private System.Windows.Forms.DataGridViewTextBoxColumn gvCodeReviews_Reviews;
  }
}