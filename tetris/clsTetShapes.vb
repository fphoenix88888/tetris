'Creates Shapes, Adds Movements etc.
Public Class clsTetShapes

    Public rctShape() As Rectangle 'Shape

    Public blnMoving As Boolean 'Is The Shape Moving
    Private blnIsNextShape As Boolean = False 'Image In The Next Shape Window

    Private intStartX As Integer 'Starting Horz Loc
    Private intCurrShape As Integer = 1 'Current Shape
    Private intCurrShapePos As Integer = 1 'Shape Location
    Private intBlockX(4) As Integer 'Each Part Of Tetri, Horz
    Private intBlockY(4) As Integer 'Each part Of Tetri, Vert
    Private intXPos(4) As Integer 'Starting Horz Loc
    Private intPanelWidth As Integer 'Panel Width
    Private intPanelHeight As Integer 'Panel height

    ''' <summary>
    ''' Initialises Shape(s)
    ''' </summary>
    ''' <param name="intShapeType">Current Shape</param>
    ''' <param name="intScreenW">Screen Width</param>
    ''' <param name="intScreenH">Screen Height</param>
    ''' <param name="blnNextShape">Image In The Next Shape Window</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal intShapeType As Integer, ByVal intScreenW As Integer, ByVal intScreenH As Integer, ByVal blnNextShape As Boolean)

        intStartX = CInt((intScreenW - 1) / 2) 'Start In Center Of X Axis

        intPanelWidth = intScreenW 'Canvas Width
        intPanelHeight = intScreenH 'Canvas Height

        blnIsNextShape = blnNextShape ' Is The Next Shape Shown

        intCurrShape = intShapeType 'Set Current Shape

        ShapeStart() 'Call To ShapeStart Gives Initial values To All Blocks Of All Shapes

    End Sub

    ''' <summary>
    ''' Create The 4 Blocks Of Shape
    ''' </summary>
    ''' <param name="intShapeType">Which Shape Are We Busy With</param>
    ''' <remarks></remarks>
    Private Sub Build(ByVal intShapeType As Integer)

        rctShape = New Rectangle(4) {} 'Each Block Of Shape

        'Create 4 Blocks 10 x 10
        rctShape(0) = New Rectangle(intBlockX(0), intBlockY(0), 10, 10)
        rctShape(1) = New Rectangle(intBlockX(1), intBlockY(1), 10, 10)
        rctShape(2) = New Rectangle(intBlockX(2), intBlockY(2), 10, 10)
        rctShape(3) = New Rectangle(intBlockX(3), intBlockY(3), 10, 10)

    End Sub

    ''' <summary>
    ''' Moves Current Shape Downwards
    ''' </summary>
    ''' <param name="intMovePixels"></param>
    ''' <param name="rctGameGrid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MoveDown(ByVal intMovePixels As Integer, ByVal rctGameGrid()() As Rectangle) As Rectangle()
        Dim blnMovable As Boolean = True 'Is The Shape Movable?

        Dim j As Integer 'Loop Counter

        ' Check To See If Any X Positions Will Go Over The Edges
        For j = 0 To 3
            If intBlockY(j) + 10 + intMovePixels > intPanelHeight - 1 Then
                blnMovable = False
                blnMoving = False
                Exit For
            End If
        Next j

        If blnMovable Then

            ' Shape Hasn't Reached The Bottom Yet, See If It Will Hit A
            ' Stationary Block 
            Dim k As Integer
            For k = 0 To 3
                If [Decimal].Remainder(intBlockY(k), 10) = 0 And intBlockY(k) >= 0 Then
                    If Not rctGameGrid(CInt((intBlockY(k) / 10 + 1)))(CInt((intBlockX(k) / 10))).IsEmpty Then

                        ' Shape Is About To Enter A Blocked Area
                        blnMovable = False
                        blnMoving = False
                        Exit For
                    End If
                End If
            Next k
        End If

        If blnMovable Then
            Dim i As Integer
            For i = 0 To 3
                intBlockY(i) += intMovePixels
            Next i
        End If
        Build(intCurrShape)
        Return rctShape
    End Function

    ''' <summary>
    ''' Move Shape Left
    ''' </summary>
    ''' <param name="intMovePixels"></param>
    ''' <param name="rctGameGrid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MoveLeft(ByVal intMovePixels As Integer, ByVal rctGameGrid()() As Rectangle) As Rectangle()
        Dim blnMovable As Boolean = True
        Dim intYPos(4) As Integer

        ' Set X Pos To Be Out Of The Range In Our Panel
        Dim intFurthestX As Integer = intPanelWidth

        Dim j As Integer

        ' Check To See If Any X Positions Will Go Over The Edge Or Try And Enter A 
        ' Blocked Area We Need The Leftmost Block(s) To Test Could Be 1,2,3, or 4
        For j = 0 To 3
            If intBlockX(j) <= intFurthestX Then
                intFurthestX = intBlockX(j)
                intYPos(j) = intBlockY(j)
                If [Decimal].Remainder(intBlockY(j), 10) <> 0 Then
                    intYPos(j) += 5
                End If
            End If
            If intBlockX(j) - intMovePixels < 0 Then
                blnMovable = False
                Exit For
            End If
        Next j

        If blnMovable Then
            Dim i As Integer
            For i = 0 To 3
                If intYPos(i) >= 0 Then
                    If Not rctGameGrid(CInt((intYPos(i) / 10)))(CInt(((intFurthestX - 10) / 10))).IsEmpty Then
                        ' Shape Is About To Enter A Blocked Area
                        blnMovable = False
                        Exit For
                    End If
                End If
            Next i
        End If

        If blnMovable Then
            Dim i As Integer
            For i = 0 To 3
                intBlockX(i) -= intMovePixels
            Next i
        End If
        Build(intCurrShape)
        Return rctShape
    End Function

    ''' <summary>
    ''' Move Shape Right
    ''' </summary>
    ''' <param name="intMovePixels"></param>
    ''' <param name="rctGameGrid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MoveRight(ByVal intMovePixels As Integer, ByVal rctGameGrid()() As Rectangle) As Rectangle()
        Dim blnMovable As Boolean = True

        Dim intYPos(4) As Integer

        ' Set X Pos To Be Out Of The Range In Our Panel
        Dim intFurthestX As Integer = 0

        ' Check To See If Any X Positions Will Go Over The Edge
        Dim j As Integer

        For j = 0 To 3
            If intBlockX(j) >= intFurthestX Then
                intFurthestX = intBlockX(j)
                intYPos(j) = intBlockY(j)
                If [Decimal].Remainder(intBlockY(j), 10) <> 0 Then
                    intYPos(j) += 5
                End If
            End If

            If intBlockX(j) + intMovePixels + 10 >= intPanelWidth Then
                blnMovable = False
                Exit For
            End If

        Next j

        If blnMovable Then
            Dim i As Integer

            For i = 0 To 3
                If intYPos(i) >= 0 Then
                    If Not rctGameGrid(CInt(intYPos(i) / 10))(CInt(((intFurthestX + 10) / 10))).IsEmpty Then

                        ' Shape Is About To Enter A Blocked Area
                        blnMovable = False
                        Exit For
                    End If
                End If
            Next i
        End If

        If blnMovable Then
            Dim i As Integer
            For i = 0 To 3
                intBlockX(i) += intMovePixels
            Next i
        End If

        Build(intCurrShape)

        Return rctShape

    End Function

    ''' <summary>
    ''' Flip Shape
    ''' </summary>
    ''' <param name="strDirection"></param>
    ''' <param name="rctGameGrid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Flip(ByVal strDirection As String, ByVal rctGameGrid()() As Rectangle) As Rectangle()

        Dim blnMovable As Boolean = True

        If strDirection = "right" Then
            intCurrShapePos += 1
            If intCurrShapePos > 4 Then
                intCurrShapePos = 1
            End If
        End If

        If strDirection = "left" Then
            intCurrShapePos -= 1
            If intCurrShapePos < 1 Then
                intCurrShapePos = 4 'Was 4
            End If
        End If

        SetShapePos()
        Build(intCurrShape)

        ' Before Returning The Shape, See If It Is Within The Bounds Of The Panel
        Dim recGameArea As New Rectangle(0, 0, intPanelWidth, intPanelHeight)

        Dim intYPositions(4) As Integer
        Dim i As Integer

        For i = 0 To 3
            If Not recGameArea.Contains(rctShape(i)) Then
                blnMovable = False
                Exit For
            End If

            ' See If The Shape Is Going To Collide With Any Other
            ' Stationary Objects

            intYPositions(i) = intBlockY(i)
            If [Decimal].Remainder(intBlockY(i), 10) <> 0 Then
                intYPositions(i) += 5
            End If

            If Not rctGameGrid(CInt((intYPositions(i) / 10)))(CInt((intBlockX(i) / 10))).IsEmpty Then

                ' Shape Is About To Enter A Blocked Area
                blnMovable = False
                Exit For
            End If
        Next i

        If Not blnMovable Then
            ' Rollback
            If strDirection = "right" Then
                intCurrShapePos -= 1
                If intCurrShapePos < 1 Then
                    intCurrShapePos = 4
                End If

                SetShapePos()
                Build(intCurrShape)
            End If

            If strDirection = "left" Then
                intCurrShapePos += 1
                If intCurrShapePos > 4 Then
                    intCurrShapePos = 1
                End If

                SetShapePos()
                Build(intCurrShape)
            End If
        End If

        Return rctShape

    End Function

    ''' <summary>
    ''' Set Shape Start Positions
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShapeStart()

        If Not blnIsNextShape Then 'If Shape Shown In Main Game Window
            Select Case intCurrShape

                Case 1 'T Shape - Blue
                    intBlockX(0) = intStartX
                    intBlockY(0) = -10
                    intBlockX(1) = intStartX - 10
                    intBlockY(1) = -10
                    intBlockX(2) = intStartX + 10
                    intBlockY(2) = -10
                    intBlockX(3) = intStartX
                    intBlockY(3) = -20

                Case 2 'L Shape - Red
                    intBlockX(0) = intStartX
                    intBlockY(0) = -10
                    intBlockX(1) = intStartX - 10
                    intBlockY(1) = -10
                    intBlockX(2) = intStartX + 10
                    intBlockY(2) = -10
                    intBlockX(3) = intStartX + 10
                    intBlockY(3) = -20

                Case 3 'J Shape - Green
                    intBlockX(0) = intStartX
                    intBlockY(0) = -10
                    intBlockX(1) = intStartX - 10
                    intBlockY(1) = -10
                    intBlockX(2) = intStartX + 10
                    intBlockY(2) = -10
                    intBlockX(3) = intStartX - 10
                    intBlockY(3) = -20

                Case 4 'O Shape - Yellow
                    intBlockX(0) = intStartX
                    intBlockY(0) = -10
                    intBlockX(1) = intStartX + 10
                    intBlockY(1) = -10
                    intBlockX(2) = intStartX
                    intBlockY(2) = -20
                    intBlockX(3) = intStartX + 10
                    intBlockY(3) = -20

                Case 5 'I Shape - Brown
                    intBlockX(0) = intStartX
                    intBlockY(0) = -10
                    intBlockX(1) = intStartX
                    intBlockY(1) = -20
                    intBlockX(2) = intStartX
                    intBlockY(2) = -30
                    intBlockX(3) = intStartX
                    intBlockY(3) = -40

                Case 6 'S Shape - Orange
                    intBlockX(0) = intStartX - 10
                    intBlockY(0) = -10
                    intBlockX(1) = intStartX
                    intBlockY(1) = -10
                    intBlockX(2) = intStartX
                    intBlockY(2) = -20
                    intBlockX(3) = intStartX + 10
                    intBlockY(3) = -20

                Case 7 'Z Shape - Purple
                    intBlockX(0) = intStartX + 10
                    intBlockY(0) = -10
                    intBlockX(1) = intStartX
                    intBlockY(1) = -10
                    intBlockX(2) = intStartX
                    intBlockY(2) = -20
                    intBlockX(3) = intStartX - 10
                    intBlockY(3) = -20

                Case Else
            End Select

        Else

            Select Case intCurrShape 'If Shape Shown In preview Window

                Case 1 'T
                    intBlockX(0) = intStartX - 5
                    intBlockY(0) = 35
                    intBlockX(1) = intStartX - 15
                    intBlockY(1) = 35
                    intBlockX(2) = intStartX + 5
                    intBlockY(2) = 35
                    intBlockX(3) = intStartX - 5
                    intBlockY(3) = 25

                Case 2 'L
                    intBlockX(0) = intStartX - 5
                    intBlockY(0) = 35
                    intBlockX(1) = intStartX - 15
                    intBlockY(1) = 35
                    intBlockX(2) = intStartX + 5
                    intBlockY(2) = 35
                    intBlockX(3) = intStartX + 5
                    intBlockY(3) = 25

                Case 3 'J
                    intBlockX(0) = intStartX - 5
                    intBlockY(0) = 35
                    intBlockX(1) = intStartX - 15
                    intBlockY(1) = 35
                    intBlockX(2) = intStartX + 5
                    intBlockY(2) = 35
                    intBlockX(3) = intStartX - 15
                    intBlockY(3) = 25

                Case 4 'O
                    intBlockX(0) = intStartX - 10
                    intBlockY(0) = 35
                    intBlockX(1) = intStartX
                    intBlockY(1) = 35
                    intBlockX(2) = intStartX - 10
                    intBlockY(2) = 25
                    intBlockX(3) = intStartX
                    intBlockY(3) = 25

                Case 5 'I
                    intBlockX(0) = intStartX - 5
                    intBlockY(0) = 45
                    intBlockX(1) = intStartX - 5
                    intBlockY(1) = 35
                    intBlockX(2) = intStartX - 5
                    intBlockY(2) = 25
                    intBlockX(3) = intStartX - 5
                    intBlockY(3) = 15

                Case 6 'S
                    intBlockX(0) = intStartX - 10
                    intBlockY(0) = 45
                    intBlockX(1) = intStartX
                    intBlockY(1) = 45
                    intBlockX(2) = intStartX
                    intBlockY(2) = 35
                    intBlockX(3) = intStartX + 10
                    intBlockY(3) = 35

                Case 7 'Z
                    intBlockX(0) = intStartX + 10
                    intBlockY(0) = 45
                    intBlockX(1) = intStartX
                    intBlockY(1) = 45
                    intBlockX(2) = intStartX
                    intBlockY(2) = 35
                    intBlockX(3) = intStartX - 10
                    intBlockY(3) = 35

                Case Else
            End Select

            Build(intCurrShape)

        End If
    End Sub

    ''' <summary>
    ''' Get next Shape
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetShape() As Rectangle()
        Return rctShape ' Return Next Shape
    End Function

    ''' <summary>
    ''' Set Each variation Of Each Shape's Positions
    ''' Controlled By A And K Keys
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetShapePos()
        Select Case intCurrShape
            Case 1 'T

                Select Case intCurrShapePos

                    Case 1
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0) - 10
                        intBlockY(1) = intBlockY(0)
                        intBlockX(2) = intBlockX(0) + 10
                        intBlockY(2) = intBlockY(0)
                        intBlockX(3) = intBlockX(0)
                        intBlockY(3) = intBlockY(0) - 10

                    Case 2
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0)
                        intBlockY(1) = intBlockY(0) - 10
                        intBlockX(2) = intBlockX(0)
                        intBlockY(2) = intBlockY(0) + 10
                        intBlockX(3) = intBlockX(0) + 10
                        intBlockY(3) = intBlockY(0)

                    Case 3
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0) + 10
                        intBlockY(1) = intBlockY(0)
                        intBlockX(2) = intBlockX(0) - 10
                        intBlockY(2) = intBlockY(0)
                        intBlockX(3) = intBlockX(0)
                        intBlockY(3) = intBlockY(0) + 10

                    Case 4
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0)
                        intBlockY(1) = intBlockY(0) + 10
                        intBlockX(2) = intBlockX(0)
                        intBlockY(2) = intBlockY(0) - 10
                        intBlockX(3) = intBlockX(0) - 10
                        intBlockY(3) = intBlockY(0)

                    Case Else
                End Select

            Case 2 'L
                Select Case intCurrShapePos

                    Case 1
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0) - 10
                        intBlockY(1) = intBlockY(0)
                        intBlockX(2) = intBlockX(0) + 10
                        intBlockY(2) = intBlockY(0)
                        intBlockX(3) = intBlockX(0) + 10
                        intBlockY(3) = intBlockY(0) - 10

                    Case 2
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0)
                        intBlockY(1) = intBlockY(0) - 10
                        intBlockX(2) = intBlockX(0)
                        intBlockY(2) = intBlockY(0) + 10
                        intBlockX(3) = intBlockX(0) + 10
                        intBlockY(3) = intBlockY(0) + 10

                    Case 3
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0) + 10
                        intBlockY(1) = intBlockY(0)
                        intBlockX(2) = intBlockX(0) - 10
                        intBlockY(2) = intBlockY(0)
                        intBlockX(3) = intBlockX(0) - 10
                        intBlockY(3) = intBlockY(0) + 10

                    Case 4
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0)
                        intBlockY(1) = intBlockY(0) + 10
                        intBlockX(2) = intBlockX(0)
                        intBlockY(2) = intBlockY(0) - 10
                        intBlockX(3) = intBlockX(0) - 10
                        intBlockY(3) = intBlockY(0) - 10
                    Case Else
                End Select

            Case 3 'J
                Select Case intCurrShapePos

                    Case 1
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0) - 10
                        intBlockY(1) = intBlockY(0)
                        intBlockX(2) = intBlockX(0) + 10
                        intBlockY(2) = intBlockY(0)
                        intBlockX(3) = intBlockX(0) - 10
                        intBlockY(3) = intBlockY(0) - 10

                    Case 2
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0)
                        intBlockY(1) = intBlockY(0) - 10
                        intBlockX(2) = intBlockX(0)
                        intBlockY(2) = intBlockY(0) + 10
                        intBlockX(3) = intBlockX(0) + 10
                        intBlockY(3) = intBlockY(0) - 10

                    Case 3
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0) + 10
                        intBlockY(1) = intBlockY(0)
                        intBlockX(2) = intBlockX(0) - 10
                        intBlockY(2) = intBlockY(0)
                        intBlockX(3) = intBlockX(0) + 10
                        intBlockY(3) = intBlockY(0) + 10

                    Case 4
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0)
                        intBlockY(1) = intBlockY(0) + 10
                        intBlockX(2) = intBlockX(0)
                        intBlockY(2) = intBlockY(0) - 10
                        intBlockX(3) = intBlockX(0) - 10
                        intBlockY(3) = intBlockY(0) + 10

                    Case Else
                End Select

                '4 Is O Shape - Already Square Won't See Anything

            Case 5  'I
                Select Case intCurrShapePos

                    Case 1
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0) + 10
                        intBlockY(1) = intBlockY(0)
                        intBlockX(2) = intBlockX(0) + 20
                        intBlockY(2) = intBlockY(0)
                        intBlockX(3) = intBlockX(0) + 30
                        intBlockY(3) = intBlockY(0)

                    Case 2
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0)
                        intBlockY(1) = intBlockY(0) - 10
                        intBlockX(2) = intBlockX(0)
                        intBlockY(2) = intBlockY(0) - 20
                        intBlockX(3) = intBlockX(0)
                        intBlockY(3) = intBlockY(0) - 30

                    Case 3
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0) + 10
                        intBlockY(1) = intBlockY(0)
                        intBlockX(2) = intBlockX(0) + 20
                        intBlockY(2) = intBlockY(0)
                        intBlockX(3) = intBlockX(0) + 30
                        intBlockY(3) = intBlockY(0)

                    Case 4
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0)
                        intBlockY(1) = intBlockY(0) - 10
                        intBlockX(2) = intBlockX(0)
                        intBlockY(2) = intBlockY(0) - 20
                        intBlockX(3) = intBlockX(0)
                        intBlockY(3) = intBlockY(0) - 30

                    Case Else
                End Select

            Case 6 'S
                Select Case intCurrShapePos

                    Case 1
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0)
                        intBlockY(1) = intBlockY(0) + 10
                        intBlockX(2) = intBlockX(0) + 10
                        intBlockY(2) = intBlockY(0) + 10
                        intBlockX(3) = intBlockX(0) + 10
                        intBlockY(3) = intBlockY(0) + 20

                    Case 2
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0) - 10
                        intBlockY(1) = intBlockY(0)
                        intBlockX(2) = intBlockX(0)
                        intBlockY(2) = intBlockY(0) - 10
                        intBlockX(3) = intBlockX(0) + 10
                        intBlockY(3) = intBlockY(0) - 10

                    Case 3
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0)
                        intBlockY(1) = intBlockY(0) + 10
                        intBlockX(2) = intBlockX(0) + 10
                        intBlockY(2) = intBlockY(0) + 10
                        intBlockX(3) = intBlockX(0) + 10
                        intBlockY(3) = intBlockY(0) + 20

                    Case 4
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0) - 10
                        intBlockY(1) = intBlockY(0)
                        intBlockX(2) = intBlockX(0)
                        intBlockY(2) = intBlockY(0) - 10
                        intBlockX(3) = intBlockX(0) + 10
                        intBlockY(3) = intBlockY(0) - 10

                    Case Else
                End Select

            Case 7 'Z
                Select Case intCurrShapePos

                    Case 1
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0)
                        intBlockY(1) = intBlockY(0) - 10
                        intBlockX(2) = intBlockX(0) - 10
                        intBlockY(2) = intBlockY(0) - 10
                        intBlockX(3) = intBlockX(0) - 10
                        intBlockY(3) = intBlockY(0) - 20

                    Case 2
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0) + 10
                        intBlockY(1) = intBlockY(0)
                        intBlockX(2) = intBlockX(0)
                        intBlockY(2) = intBlockY(0) + 10
                        intBlockX(3) = intBlockX(0) - 10
                        intBlockY(3) = intBlockY(0) + 10

                    Case 3
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0)
                        intBlockY(1) = intBlockY(0) - 10
                        intBlockX(2) = intBlockX(0) - 10
                        intBlockY(2) = intBlockY(0) - 10
                        intBlockX(3) = intBlockX(0) - 10
                        intBlockY(3) = intBlockY(0) - 20

                    Case 4
                        intBlockX(0) = intBlockX(0)
                        intBlockY(0) = intBlockY(0)
                        intBlockX(1) = intBlockX(0) + 10
                        intBlockY(1) = intBlockY(0)
                        intBlockX(2) = intBlockX(0)
                        intBlockY(2) = intBlockY(0) + 10
                        intBlockX(3) = intBlockX(0) - 10
                        intBlockY(3) = intBlockY(0) + 10

                    Case Else
                End Select

            Case Else
        End Select

    End Sub
End Class
