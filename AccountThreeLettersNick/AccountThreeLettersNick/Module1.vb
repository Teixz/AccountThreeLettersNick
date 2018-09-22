Imports System.Linq
Imports System.Collections.Generic
Imports System.Net
Imports System.Windows.Forms
Imports System.IO
Module Module1

    Sub Main()
        ' Coded By Teix#6391 / @Skr_0xt1
        ' Github -> https://github.com/Teixz
        Dim txtProxy As TextBox = New TextBox
        txtProxy.Multiline = True
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine("Precione qualquer tecla pra escolher o .txt da lista de proxy.")
        Console.ReadLine()
        Dim opf As OpenFileDialog = New OpenFileDialog()
        opf.ShowDialog()
        Dim filename As String = opf.FileName
        Dim a As String = File.ReadAllText(filename)
        txtProxy.Text = a
        Console.WriteLine("Arquivo -> " & filename)
        Console.WriteLine("")
        Console.WriteLine("Testando...")
        Dim chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
        Dim random = New Random()
        Dim tamanho As Integer = 3
        Dim gerados As New Dictionary(Of String, Integer)
        Dim valor As Random = New Random()
        Dim wbc As New WebClient
        For i As Integer = 0 To 1000000
            Try
                Dim resultado As String = "0"
                Try
                    For Each line As String In txtProxy.Lines
                        line = line.Replace(vbCr, "").Replace(vbLf, "")
                        Console.ForegroundColor = ConsoleColor.White
                        Dim b As String = valor.Next(1, 1000000000).ToString()
                        Dim result = New String(Enumerable.Repeat(chars, tamanho).[Select](Function(s) s(random.[Next](s.Length))).ToArray())
                        Try
                            Dim wp As New WebProxy(line)
                            wbc.Proxy = wp
                            resultado = wbc.DownloadString("https://api.mojang.com/users/profiles/minecraft/" & result)
                        Catch ex As Exception
                            Console.ForegroundColor = ConsoleColor.DarkRed
                            Console.WriteLine("[!] Erro na proxy -> " & line)
                        End Try
                        If resultado = "" Then
                            Console.ForegroundColor = ConsoleColor.Green
                            Console.WriteLine("[!] Disponivel : " & result & " [Proxy -> " & line & "]")
                            Try
                                If gerados.ContainsKey(result) Then

                                Else
                                    gerados.Add(result, b)
                                End If
                            Catch ex As Exception
                                Console.WriteLine(ex.ToString())
                            End Try
                        Else
                            Console.ForegroundColor = ConsoleColor.Red
                            Console.WriteLine("[!] Indisponivel : " & result & " [Proxy -> " & line & "]")
                            Try
                                If gerados.ContainsKey(result) Then

                                Else
                                    gerados.Add(result, b)
                                End If
                            Catch ex As Exception
                                Console.WriteLine(ex.ToString())
                            End Try
                        End If
                    Next

                    'Threading.Thread.Sleep(1000L)
                Catch ex As Exception
                    Console.WriteLine(ex.ToString())
                End Try
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            End Try
        Next
    End Sub

End Module
