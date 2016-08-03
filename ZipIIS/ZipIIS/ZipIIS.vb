Imports System.DirectoryServices
Imports Microsoft.Web.Administration
Imports System
Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Threading
Imports ICSharpCode.SharpZipLib.Checksums
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.GZip
Public Class ZipIIS

    Private Sub StartZip_Click(sender As Object, e As EventArgs) Handles StartZip.Click
        Dim defaultSite As Site = New ServerManager().Sites(txtIISSite.Text)
        If (Not System.IO.Directory.Exists(txtZipDirectory.Text)) Then
            System.IO.Directory.CreateDirectory(txtZipDirectory.Text)
        End If
        Dim filestream As New FileStream(txtZipDirectory.Text + "\log_ " + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", FileMode.Create)
        Dim streamwriter = New StreamWriter(filestream)
        Dim writeFile As System.IO.TextWriter = New StreamWriter(filestream)
        'streamwriter.AutoFlush = True
        For Each app As Application In defaultSite.Applications
            writeFile.WriteLine("{0} Found application with the following path: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), app.Path)
            writeFile.WriteLine("Virtual Directories:")
            If app.VirtualDirectories.Count > 0 Then
                For Each vdir As VirtualDirectory In app.VirtualDirectories
                    writeFile.WriteLine("Virtual Directory: {0}", vdir.Path)
                    writeFile.WriteLine("   |-PhysicalPath = {0}", vdir.PhysicalPath)
                    writeFile.WriteLine("   |-LogonMethod  = {0}", vdir.LogonMethod)
                    writeFile.WriteLine("   +-UserName     = {0}\r\n", vdir.UserName)
                    If app.Path.Trim.Replace("/", "") <> String.Empty Then
                        Zipfolder(vdir.PhysicalPath, app.Path.Replace("/", ""), writeFile)
                    End If
                Next
            End If
        Next
        Console.SetOut(writeFile)
        Console.SetOut(streamwriter)
        writeFile.Dispose()
    End Sub

    Sub Zipfolder(ByVal dir As String, ByVal dirname As String, ByVal writeFile As System.IO.TextWriter)
        Dim strfilesaveto As String = txtZipDirectory.Text + "\" + dirname
        Dim sTemp As String() = strfilesaveto.Split("\")
        Dim sZipFileName As String = sTemp(sTemp.Length - 1).ToString()

        ' check to see if zipped file already exists
        Dim fi As FileInfo =
        New FileInfo(txtZipDirectory.Text + "\" + dirname + ".zip")
        If fi.Exists Then
            Try
                Dim sb As StringBuilder = New StringBuilder()
                sb.Append("The directory " + dirname + " already exists. ")
                sb.Append("Please delete the directory.")
                MessageBox.Show(sb.ToString(), "Existing File Name")
                writeFile.WriteLine("Existing File Name: {0}", sb.ToString())
                Exit Sub
            Catch ex As Exception
                MessageBox.Show(ex.Message, "File Error")
                writeFile.WriteLine("File Error: {0}", ex.ToString())
                Exit Sub
            End Try
        End If
        fi = Nothing


        ' Check for the existence of the target folder and
        ' create it if it does not exist
        If (Not System.IO.Directory.Exists(strfilesaveto + "\TempZipFile\")) Then
            System.IO.Directory.CreateDirectory(strfilesaveto + "\TempZipFile\")
        End If

        ' Set up a string to hold the path to the temp folder
        Dim sTargetFolderPath As String = (strfilesaveto + "\TempZipFile\")
        ' zip up the files
        Try

            Dim filenames As String() = Directory.GetFiles(dir)
            ' Zip up the files - From SharpZipLib Demo Code
            Dim s As ZipOutputStream = New ZipOutputStream(File.Create(txtZipDirectory.Text + "\" + dirname + ".zip"))
            s.SetLevel(9) ' 0-9, 9 being the highest level of compression
            Dim buffer() As Byte
            ReDim buffer(4096)
            Dim f As String
            For Each f In filenames
                Dim entry As ZipEntry = New ZipEntry(Path.GetFileName(f))
                entry.DateTime = DateTime.Now
                s.PutNextEntry(entry)
                Dim fs As FileStream = File.OpenRead(f)
                Dim sourceBytes As Integer = 1

                Do Until (sourceBytes <= 0)
                    sourceBytes = fs.Read(buffer, 0, buffer.Length)
                    s.Write(buffer, 0, sourceBytes)
                Loop
                fs.Close()
            Next
            s.Finish()
            s.Close()
            MessageBox.Show("Zip file " + strfilesaveto + " created.")
            writeFile.WriteLine("Zip file: {0} created", strfilesaveto)
            ' clean up files by deleting the temp folder and its content
            System.IO.Directory.Delete(strfilesaveto + "\TempZipFile\", True)

        Catch ex As Exception
            System.IO.Directory.Delete(strfilesaveto + "\TempZipFile\", True)
            MessageBox.Show(ex.Message.ToString(), "Zip Operation Error")
            writeFile.WriteLine("Zip Operation Error: {0}", ex.ToString())
        End Try
    End Sub

    Private Sub StopAndClose_Click(sender As Object, e As EventArgs) Handles StopAndClose.Click
        Me.Close()
    End Sub


End Class
