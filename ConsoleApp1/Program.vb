Imports System.IO

Module Program
    Sub Main()
        Dim tasks As New List(Of String)

        Console.WriteLine("Aplikasi Manajer Tugas!")

        ' Membaca daftar tugas dari file
        BacaDaftarTugas(tasks)

        Dim pilihan As Integer

        Do
            Console.WriteLine()
            Console.WriteLine("Silakan pilih menu:")
            Console.WriteLine("1. Daftar Tugas")
            Console.WriteLine("2. Tambah Tugas Baru")
            Console.WriteLine("3. Tandai Tugas Selesai")
            Console.WriteLine("4. Hapus Tugas")
            Console.WriteLine("5. Keluar")
            Console.Write("Masukkan pilihan Anda: ")

            Integer.TryParse(Console.ReadLine(), pilihan)

            Select Case pilihan
                Case 1
                    TampilkanDaftarTugas(tasks)
                Case 2
                    TambahTugas(tasks)
                Case 3
                    TandaiTugasSelesai(tasks)
                Case 4
                    HapusTugas(tasks)
                Case 5
                    Console.WriteLine("Menyimpan perubahan dan keluar...")
                    SimpanDaftarTugas(tasks)
                Case Else
                    Console.WriteLine("Pilihan tidak valid.")
            End Select

        Loop While pilihan <> 5
    End Sub

    Sub BacaDaftarTugas(ByRef tasks As List(Of String))
        Dim fileName As String = "daftar_tugas.txt"

        If File.Exists(fileName) Then
            tasks = File.ReadAllLines(fileName).ToList()
            Console.WriteLine("Daftar tugas berhasil dibaca dari file.")
        Else
            Console.WriteLine("File tidak ditemukan. Membuat file baru.")
            File.Create(fileName).Close()
        End If
    End Sub

    Sub TampilkanDaftarTugas(ByVal tasks As List(Of String))
        Console.WriteLine("Daftar Tugas:")
        For Each task As String In tasks
            Console.WriteLine("- " & task)
        Next
    End Sub

    Sub TambahTugas(ByRef tasks As List(Of String))
        Console.Write("Masukkan nama tugas baru: ")
        Dim newTask As String = Console.ReadLine()
        tasks.Add(newTask)
        Console.WriteLine("Tugas baru berhasil ditambahkan.")
    End Sub

    Sub TandaiTugasSelesai(ByRef tasks As List(Of String))
        Console.WriteLine("Tugas mana yang akan di tandai selesai? (masukkan nomor)")
        TampilkanDaftarTugas(tasks)
        Dim index As Integer
        Integer.TryParse(Console.ReadLine(), index)
        If index > 0 AndAlso index <= tasks.Count Then
            tasks.RemoveAt(index - 1)
            Console.WriteLine("Tugas berhasil ditandai selesai.")
        Else
            Console.WriteLine("Nomor tugas tidak valid.")
        End If
    End Sub

    Sub HapusTugas(ByRef tasks As List(Of String))
        Console.WriteLine("Tugas mana yang ingin di hapus? (masukkan nomor)")
        TampilkanDaftarTugas(tasks)
        Dim index As Integer
        Integer.TryParse(Console.ReadLine(), index)
        If index > 0 AndAlso index <= tasks.Count Then
            tasks.RemoveAt(index - 1)
            Console.WriteLine("Tugas berhasil dihapus.")
        Else
            Console.WriteLine("Nomor tugas tidak valid.")
        End If
    End Sub

    Sub SimpanDaftarTugas(ByVal tasks As List(Of String))
        Dim fileName As String = "daftar_tugas.txt"
        File.WriteAllLines(fileName, tasks)
        Console.WriteLine("Perubahan pada daftar tugas berhasil disimpan.")
    End Sub
End Module
