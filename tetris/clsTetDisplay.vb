#Region "1 & 2"
'Displays All Shapes Inside Panels Where Necessary
Public Class clsTetDisplay

    Protected g As Graphics = Nothing 'Graphics Object To Draw With
    Protected InMemoryGraphics As Graphics = Nothing 'Temporary Graphics PlaceHolder

    Protected InMemoryImage As Image = Nothing 'Temporary Image PlaceHolder

    Public ScreenX As Integer = 0 'Starting X of Panel
    Public ScreenY As Integer = 0 'Starting Y Of Panel
    Public ScreenWidth As Integer = 0 'Width Of Panel
    Public ScreenHeight As Integer = 0 'Height Of Panel

    ''' <summary>
    ''' Initializes New Display Graphic
    ''' </summary>
    ''' <param name="p">Panel To Use</param>
    ''' <param name="r">Rectangle to Use</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal p As Panel, ByVal r As Rectangle)

        g = p.CreateGraphics() 'Start Drawing

        ScreenX = r.X 'Start Where r Starts, Horizontally
        ScreenY = r.Y 'Start Where r Starts, Vertically

        ScreenWidth = r.Width 'Same Width As r
        ScreenHeight = r.Height 'Same Height As r

        InMemoryImage = New Bitmap(ScreenWidth, ScreenHeight) 'Create Image Size
        InMemoryGraphics = Graphics.FromImage(InMemoryImage) 'Create Image

    End Sub

    ''' <summary>
    ''' Returns Temp Image
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetGraphics() As Graphics

        Return InMemoryGraphics 'Get In Memory Graphic

    End Function

    ''' <summary>
    ''' Determine Existance Of In Memory Graphic
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidGraphic() As Boolean

        If Not (g Is Nothing) And Not (InMemoryGraphics Is Nothing) Then
            Return True 'If There Is A Graphic In Memory 
        Else
            Return False 'If Not
        End If

    End Function

    ''' <summary>
    ''' Erase Game Screen
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearScreen()

        'If No Valid Graphic, Do Nothing
        If Not ValidGraphic() Then
            Return
        End If

        'Create A Solid Black Brush
        Dim ClearBrush As New SolidBrush(Color.Black)

        'Fill The Rectangle With The Black Colour, Causing The Clearance of The Images
        InMemoryGraphics.FillRectangle(ClearBrush, 0, 0, ScreenWidth, ScreenHeight)

    End Sub

    ''' <summary>
    '''Ensures Smooth Animation, As Image Is Already Buffered 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub BufferImage()

        g.DrawImage(InMemoryImage, ScreenX, ScreenY)

    End Sub

End Class

#End Region
