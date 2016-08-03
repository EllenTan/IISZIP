<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ZipIIS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.StartZip = New System.Windows.Forms.Button()
        Me.StopAndClose = New System.Windows.Forms.Button()
        Me.txtIISSite = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtZipDirectory = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StartZip
        '
        Me.StartZip.Location = New System.Drawing.Point(402, 112)
        Me.StartZip.Name = "StartZip"
        Me.StartZip.Size = New System.Drawing.Size(75, 23)
        Me.StartZip.TabIndex = 0
        Me.StartZip.Text = "Start Zip"
        Me.StartZip.UseVisualStyleBackColor = True
        '
        'StopAndClose
        '
        Me.StopAndClose.Location = New System.Drawing.Point(389, 181)
        Me.StopAndClose.Name = "StopAndClose"
        Me.StopAndClose.Size = New System.Drawing.Size(119, 23)
        Me.StopAndClose.TabIndex = 1
        Me.StopAndClose.Text = "Stop and close"
        Me.StopAndClose.UseVisualStyleBackColor = True
        '
        'txtIISSite
        '
        Me.txtIISSite.Location = New System.Drawing.Point(131, 45)
        Me.txtIISSite.Name = "txtIISSite"
        Me.txtIISSite.Size = New System.Drawing.Size(346, 20)
        Me.txtIISSite.TabIndex = 2
        Me.txtIISSite.Text = "Default Web Site"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtZipDirectory)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtIISSite)
        Me.GroupBox1.Controls.Add(Me.StartZip)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(496, 152)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Setting"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Zip to directory :"
        '
        'txtZipDirectory
        '
        Me.txtZipDirectory.Location = New System.Drawing.Point(131, 80)
        Me.txtZipDirectory.Name = "txtZipDirectory"
        Me.txtZipDirectory.Size = New System.Drawing.Size(346, 20)
        Me.txtZipDirectory.TabIndex = 4
        Me.txtZipDirectory.Text = "D:\Projects\testzip"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "IIS site :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DarkRed
        Me.Label3.Location = New System.Drawing.Point(16, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(294, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Make sure that you have accessright to C:\inetpub\wwwroot"
        '
        'ZipIIS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(517, 222)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StopAndClose)
        Me.Name = "ZipIIS"
        Me.Text = "IIS ZIP"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents StartZip As System.Windows.Forms.Button
    Friend WithEvents StopAndClose As System.Windows.Forms.Button
    Friend WithEvents txtIISSite As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtZipDirectory As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
