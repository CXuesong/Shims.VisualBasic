Public Class Clock

    Public ReadOnly Property GmtTime As DateTime
        Get
            Return DateTime.UtcNow
        End Get
    End Property

    Public ReadOnly Property LocalTime As DateTime
        Get
            Return DateTime.Now
        End Get
    End Property

    Public ReadOnly Property TickCount As Integer
        Get
            Return Environment.TickCount
        End Get
    End Property

End Class
