'Creates The Blocks ( Grid ) To Put All Shapes On
Public Class clsTetGrid

#Region "Part 1 & 2"
    Private arrGrids As Rectangle()() 'Each Block

    Private arrGridBrushes As SolidBrush()() 'Each Shape's grid
    Private arrColours() As SolidBrush 'Each Shape's Colour

    ''' <summary>
    ''' Initialises The Grid
    ''' </summary>
    ''' <param name="intGridRows">Each Row</param>
    ''' <param name="intGridCols">Each Column</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal intGridRows As Integer, ByVal intGridCols As Integer)

        arrGrids = New Rectangle(intGridRows)() {} 'Create Row(s)
        arrGridBrushes = New SolidBrush(intGridRows)() {} 'Create Grid For Each Row
        arrColours = New SolidBrush(7) {} 'Colours Of Shapes

        Dim i As Integer 'Counter For Loop

        For i = 0 To intGridRows - 1 'Loop Through Each Row

            arrGrids(i) = New Rectangle(intGridCols) {} 'Create Each Column Block
            arrGridBrushes(i) = New SolidBrush(intGridCols) {} 'Create Each Column Border

        Next i

        'Colours For Shapes
        arrColours(0) = New SolidBrush(Color.Blue)
        arrColours(1) = New SolidBrush(Color.Red)
        arrColours(2) = New SolidBrush(Color.Green)
        arrColours(3) = New SolidBrush(Color.Yellow)
        arrColours(4) = New SolidBrush(Color.Brown)

        arrColours(5) = New SolidBrush(Color.Orange)
        arrColours(6) = New SolidBrush(Color.Purple)


    End Sub

    ''' <summary>
    ''' Get Whole Grid Object Array
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetGrid() As Rectangle()()
        Return arrGrids
    End Function

    Public Function GetGridBrushes() As SolidBrush()()
        Return arrGridBrushes
    End Function

    ''' <summary>
    ''' Get All Colours Associated With Grid Object Array
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetColours() As SolidBrush()
        Return arrColours
    End Function

    ''' <summary>
    ''' Determine If Next Row Is Unoccupied
    ''' </summary>
    ''' <param name="intRowNo">Specify Row</param>
    ''' <param name="intColNo">Specify Column</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsLocEmpty(ByVal intRowNo As Integer, ByVal intColNo As Integer) As Boolean
        'CHANGE HERE IN PART 3 - TRY BLOCKS
        Try
            If arrGrids(intRowNo)(intColNo).IsEmpty Then
                Return True 'If Location is Empty
            Else
                Return False 'If Not
            End If
        Catch ex As Exception
        End Try

    End Function

    ''' <summary>
    ''' Get The Top Row Of The Main Game Panel Grid
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FirstRow()

        'Top Row Is Equal To The UpperBound Of arrGrids
        arrGrids(0) = New Rectangle(arrGrids(1).Length) {}

    End Sub


    ''' <summary>
    ''' Make Sure Gridlines And Colours Follow Shapes
    ''' </summary>
    ''' <param name="intRowNo">Current Row</param>
    ''' <param name="intColNo">Current Column</param>
    ''' <param name="rctCell">Intersection Of Current Row And Current Column</param>
    ''' <param name="intShapeType">Shape Index</param>
    ''' <remarks></remarks>
    Public Sub SetLoc(ByVal intRowNo As Integer, ByVal intColNo As Integer, ByVal rctCell As Rectangle, ByVal intShapeType As Integer)

        arrGrids(intRowNo)(intColNo) = rctCell 'Identify Current Cell ( Block )

        SetColourLoc(intRowNo, intColNo, intShapeType) 'Move Colour To Specified Cell

    End Sub

    ''' <summary>
    ''' Move Colour To Associated Row & Col
    ''' </summary>
    ''' <param name="intRowNo">Current Row</param>
    ''' <param name="intColNo">Current Col</param>
    ''' <param name="intShapeType">Shape Index</param>
    ''' <remarks></remarks>
    Public Sub SetColourLoc(ByVal intRowNo As Integer, ByVal intColNo As Integer, ByVal intShapeType As Integer)

        'Set Colour Index To Grid Index
        arrGridBrushes(intRowNo)(intColNo) = arrColours((intShapeType - 1))

    End Sub
#End Region

    ''' <summary>
    ''' When The Shape Moves Down, Row By Row
    ''' </summary>
    ''' <param name="intRowNo">Specify Row</param>
    ''' <param name="intColNo">Specify Column</param>
    ''' <remarks></remarks>
    Public Sub DropDown(ByVal intRowNo As Integer, ByVal intColNo As Integer)

        'CHANGED HERE IN PART 3 - ADDED OR NOT INTROWNO <= 0
        If Not IsLocEmpty(intRowNo - 1, intColNo) Or Not intRowNo <= 0 Then 'Check If Next Row Is Empty

            'Set Current Location Equal To The Same Location Horizontally, But
            'Next Row ( Vertically )
            'Size Is 10
            arrGrids(intRowNo)(intColNo) = New Rectangle(arrGrids((intRowNo - 1))(intColNo).X, arrGrids((intRowNo - 1))(intColNo).Y + 10, 10, 10)

            'Make Sure Gridlines Move Too
            arrGridBrushes(intRowNo)(intColNo) = arrGridBrushes((intRowNo - 1))(intColNo)

        Else 'Next Row Is Not Empty
            arrGrids(intRowNo)(intColNo) = arrGrids((intRowNo - 1))(intColNo)
        End If

    End Sub
End Class


