namespace TFS.Policies.UI
{
  partial class ConfigureCoverage
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
      this.nudCoverage = new System.Windows.Forms.NumericUpDown();
      this.lblCoverage = new System.Windows.Forms.Label();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.lblPercent = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.nudCoverage)).BeginInit();
      this.SuspendLayout();
      // 
      // nudCoverage
      // 
      this.nudCoverage.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.nudCoverage.Location = new System.Drawing.Point(242, 8);
      this.nudCoverage.Name = "nudCoverage";
      this.nudCoverage.Size = new System.Drawing.Size(61, 32);
      this.nudCoverage.TabIndex = 0;
      this.nudCoverage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.nudCoverage.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      // 
      // lblCoverage
      // 
      this.lblCoverage.AutoSize = true;
      this.lblCoverage.Location = new System.Drawing.Point(10, 10);
      this.lblCoverage.Name = "lblCoverage";
      this.lblCoverage.Size = new System.Drawing.Size(226, 24);
      this.lblCoverage.TabIndex = 1;
      this.lblCoverage.Text = "Minimum Code Coverage:";
      // 
      // btnSave
      // 
      this.btnSave.AutoSize = true;
      this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnSave.Location = new System.Drawing.Point(149, 84);
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
      this.btnCancel.Location = new System.Drawing.Point(258, 84);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 34);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // lblPercent
      // 
      this.lblPercent.AutoSize = true;
      this.lblPercent.Location = new System.Drawing.Point(309, 10);
      this.lblPercent.Name = "lblPercent";
      this.lblPercent.Size = new System.Drawing.Size(24, 24);
      this.lblPercent.TabIndex = 4;
      this.lblPercent.Text = "%";
      // 
      // ConfigurePolicy
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(345, 129);
      this.Controls.Add(this.lblPercent);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnSave);
      this.Controls.Add(this.lblCoverage);
      this.Controls.Add(this.nudCoverage);
      this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ConfigurePolicy";
      this.Text = "Configure Code Coverage";
      ((System.ComponentModel.ISupportInitialize)(this.nudCoverage)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.NumericUpDown nudCoverage;
    private System.Windows.Forms.Label lblCoverage;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label lblPercent;
  }
}