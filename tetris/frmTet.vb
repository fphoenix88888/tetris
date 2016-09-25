Public Class frmTet
#Region "Part 1 & 2"
    Private grdGame As clsTetGrid 'Grid Instance
    Private arrGridBrushes()() As SolidBrush 'Colours
    Private arrColours() As SolidBrush 'Colours

    Private scrGame As clsTetDisplay 'Declare Physical Game Object
    Private scrSplash As clsTetDisplay 'Declare Object To Be Shown On Preview Block
    Private scrPreview As clsTetDisplay 'Declare "HTG" Display Object

    Private rctScreen As Rectangle 'Screen To Draw Onto

    Private intGameSpeed As Integer 'How Fast Is The Game?
    Private intDropRate As Integer 'How Fast Should It Drop?
    Private intLevel As Integer 'User's Level
    Private intLevelRows As Integer 'Number Of Rows - Current Level
    Private intTotalRows As Integer 'Total Rows
    Private GameWidth As Integer 'Width Of Game Screen
    Private GameHeight As Integer 'Height Of Game Screen
    Private intNoOfRows As Integer 'Number Of Rows
    Private intNoOfCols As Integer 'Number Of Columns

    Private lngScore As Long 'User's Score

    Private blnDropped As Boolean = False 'Has There Been An Object Dropped?
    Private blnGameOver As Boolean 'Is The Game Over?
#End Region

    Private shpShape As clsTetShapes 'Current Shape
    Private shpNextShape As clsTetShapes 'Next Shape

    Private rndShapeType As New Random 'Random Shape

    Private rctGame()() As Rectangle 'Game Rectangle
    Private rctShape As Rectangle() 'Shape Rectangle

    Private blnGamePaused As Boolean 'Game Paused?
    Private blnRowFull As Boolean 'Row Full?

    Private intNextShapeType As Integer 'Next Shape Type
    Private intShapeType As Integer 'Current Shape Type

#Region "Part 1 & 2"
    ''' <summary>
    ''' Displays The Letters HTG When Loaded
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Splash()
        Dim gStart As Graphics = scrSplash.GetGraphics() 'Enable Drawing
        scrSplash.ClearScreen() 'Clear If There Was Something
        'Create H Shape
        gStart.FillRectangle(New SolidBrush(Color.Red), 25, 100, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 25, 100, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Red), 25, 105, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 25, 105, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Red), 25, 110, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 25, 110, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Red), 25, 115, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 25, 115, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Red), 25, 120, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 25, 120, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Red), 30, 110, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 30, 110, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Red), 35, 110, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 35, 110, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Red), 40, 100, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 40, 100, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Red), 40, 105, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 40, 105, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Red), 40, 110, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 40, 110, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Red), 40, 115, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 40, 115, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Red), 40, 120, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 40, 120, 5, 5)

        'Create T Shape
        gStart.FillRectangle(New SolidBrush(Color.Green), 55, 100, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 55, 100, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Green), 60, 100, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 60, 100, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Green), 65, 100, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 65, 100, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Green), 60, 105, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 60, 105, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Green), 60, 110, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 60, 110, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Green), 60, 115, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 60, 115, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Green), 60, 120, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 60, 120, 5, 5)

        'Create G Shape
        gStart.FillRectangle(New SolidBrush(Color.Blue), 85, 100, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 85, 100, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Blue), 90, 100, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 90, 100, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Blue), 80, 105, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 80, 105, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Blue), 80, 110, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 80, 110, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Blue), 80, 115, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 80, 115, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Blue), 85, 120, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 85, 120, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Blue), 90, 120, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 90, 120, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Blue), 95, 115, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 95, 115, 5, 5)

        gStart.FillRectangle(New SolidBrush(Color.Blue), 100, 115, 5, 5)
        gStart.DrawRectangle(New Pen(Color.White, 1), 100, 115, 5, 5)

        scrSplash.BufferImage()
    End Sub

    ''' <summary>
    ''' Set Up Of Game And Default Values
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetUp()

        intGameSpeed = 100 'Game Speed = 100 Milliseconds
        intDropRate = 5 'Dropping Speed = 5 Milliseconds
        lngScore = 0 'Initialise Score
        intLevel = 1 'Initialise Level
        intLevelRows = 0 'Initialise Level Rows
        intTotalRows = 0 'Initialise Total Rows
        blnGameOver = True 'Initialise Game Over State
        blnDropped = False 'Initialise Dropped State

        lblTetScore.Text = lngScore.ToString() 'Show Score In Appropriate Label
        lblTetLevel.Text = intLevel.ToString() 'Show Level In Appropriate Label
        lblTetRows.Text = intTotalRows.ToString() 'Show Total Rows In Appropriate Label


        rctScreen = New Rectangle(0, 0, pnlTetGame.Width, pnlTetGame.Height) ' Create Main Game Window


        GameWidth = rctScreen.Width 'Set Width
        GameHeight = rctScreen.Height 'Set Height

        scrGame = New clsTetDisplay(pnlTetGame, rctScreen) 'Initialise Game Object

        rctScreen = New Rectangle(0, 0, pnlTetPreview.Width, pnlTetPreview.Height) 'Initialise & Size Preview Window
        scrPreview = New clsTetDisplay(pnlTetPreview, rctScreen)

        rctScreen = New Rectangle(0, 0, pnlTetGame.Width, pnlTetGame.Height) 'Start Splash Screen Window
        scrSplash = New clsTetDisplay(pnlTetGame, rctScreen)


        intNoOfRows = (pnlTetGame.Height - 1) / 10 'Create Game Grid & Creating 10 x 10 Sized Blocks
        intNoOfCols = (pnlTetGame.Width - 1) / 10

        grdGame = New clsTetGrid(intNoOfRows, intNoOfCols) 'Create Grid
    End Sub

#End Region

    ''' <summary>
    ''' Controls Flow Of Game
    ''' Called From Timer
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MainGame()

        Dim g As Graphics = scrGame.GetGraphics() 'Allow Drawing

        arrGridBrushes = grdGame.GetGridBrushes() 'Get All Brush Colours

        arrColours = grdGame.GetColours() 'Get All Block Colours

        rctGame = grdGame.GetGrid() 'Set Up Grid

        scrGame.ClearScreen() 'Clear Current Screen - To Redraw

        ' Draw The Stationary Shapes First
        Dim i As Integer
        For i = 0 To intNoOfRows - 1
            Dim k As Integer

            For k = 0 To intNoOfCols - 1

                If Not grdGame.IsLocEmpty(i, k) Then 'Is Row Full?
                    g.FillRectangle(arrGridBrushes(i)(k), rctGame(i)(k))
                    g.DrawRectangle(New Pen(Color.White, 1), rctGame(i)(k))
                End If

            Next k

        Next i

        ' Draw Moving Shape
        Dim j As Integer

        For j = 0 To rctShape.Length - 1
            g.FillRectangle(arrColours((intShapeType - 1)), rctShape(j))
            g.DrawRectangle(New Pen(Color.White, 1), rctShape(j))
        Next j


        scrGame.BufferImage() 'Double Buffer

    End Sub

    ''' <summary>
    ''' Draw Next Shape In Preview
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub NextShape()

        Dim g As Graphics = scrPreview.GetGraphics() 'Allow Drawing In Preview

        Dim rctNextShape() As Rectangle 'Set Up Next Shape

        rctNextShape = shpNextShape.GetShape() 'Get Next Shape

        arrColours = grdGame.GetColours() 'Get Next Shape Colours

        scrPreview.ClearScreen() ' Clear Screen

        Dim j As Integer

        For j = 0 To 3 'Draw Shape
            g.FillRectangle(arrColours((intNextShapeType - 1)), rctNextShape(j))
            g.DrawRectangle(New Pen(Color.White, 1), rctNextShape(j))
        Next j

        scrPreview.BufferImage()

    End Sub

    ''' <summary>
    ''' Get Next Shape Type
    ''' Between The & Available Shapes
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetShapeType() As Integer
        Dim intShapeType As Integer 'Shape Type

        Do 'Randomly Pick Shape type
            intShapeType = rndShapeType.Next(8)
        Loop While intShapeType = 0

        Return intShapeType

    End Function

    ''' <summary>
    ''' Draws GAME OVER
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GameOver()

        Dim gOver As Graphics = scrSplash.GetGraphics() 'Make Use Of Splash Graphic Area

        scrSplash.ClearScreen() 'Clear Whatever Was Drawn

        'Draw GAME OVER
        gOver.DrawString("GAME OVER", New Font("Courier", 18), New SolidBrush(Color.Red), 5, 100)

        scrSplash.BufferImage()
    End Sub

    ''' <summary>
    ''' Updates Score
    ''' </summary>
    ''' <param name="intRowNum"></param>
    ''' <remarks></remarks>
    Private Sub UpdateScore(ByVal intRowNum As Integer)
        intLevelRows += 1 'Increment Level Rows
        intTotalRows += 1 'Increment Total Rows

        Dim intReverseRow As Integer = 30 - intRowNum 'Get "UnUsed Rows"

        'UnUsed Rows * Level Rows * Level * 10
        lngScore = lngScore + intReverseRow * intLevelRows * intLevel * 10

        lblTetScore.Text = lngScore.ToString() 'Update Score

        If intLevelRows = 10 Then 'If 10 Rows Done In Level, Increment Level
            UpdateLevel()
            intLevelRows = 0
        End If

        lblTetRows.Text = intTotalRows.ToString() 'Show How Many Rows "Won" So Far

    End Sub

    ''' <summary>
    ''' Update Level
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateLevel()
        intLevel += 1 'Increment Level

        If intGameSpeed > 10 Then 'Increase Game Speed
            intGameSpeed -= 10
        End If

        lblTetLevel.Text = intLevel.ToString() 'Show Current Level

    End Sub


    ''' <summary>
    ''' Controls Key Presses
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmTet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Dim strKeyPress As String = Nothing
        strKeyPress = e.KeyCode.ToString() 'Gets Key Pressed

        If Not blnGameOver Then 'Still Playing?
            Select Case strKeyPress.ToUpper()

                Case "Z" 'Move Left
                    If shpShape.blnMoving Then
                        rctShape = shpShape.MoveLeft(10, grdGame.GetGrid())
                    End If

                Case "M" 'Move Right
                    If shpShape.blnMoving Then
                        rctShape = shpShape.MoveRight(10, grdGame.GetGrid())
                    End If

                Case "K" 'Flip Right
                    If shpShape.blnMoving Then
                        rctShape = shpShape.Flip("right", grdGame.GetGrid())
                    End If

                Case "A" 'Flip Left
                    If shpShape.blnMoving Then
                        rctShape = shpShape.Flip("left", grdGame.GetGrid())
                    End If

                Case "Q" 'Stop, Reset Everything
                    tmrTet.Stop()
                    SetUp()
                    Splash()

                Case "P" 'Pause
                    If Not blnGamePaused Then
                        tmrTet.Stop()
                        blnGamePaused = True
                    Else
                        tmrTet.Start()
                        blnGamePaused = False
                    End If

                Case "SPACE" 'Drop Shape
                    If shpShape.blnMoving Then
                        tmrTet.Interval = intDropRate
                        blnDropped = True
                    End If
                Case Else

            End Select

        Else

            Select Case strKeyPress.ToUpper()

                Case "RETURN" 'Start When Enter Pressed

                    ' Setup Game And Set Default Properties
                    SetUp()
                    intShapeType = GetShapeType()

                    shpShape = New clsTetShapes(intShapeType, scrGame.ScreenWidth, scrGame.ScreenHeight, False)

                    intNextShapeType = GetShapeType()

                    shpNextShape = New clsTetShapes(intNextShapeType, scrPreview.ScreenWidth, scrPreview.ScreenHeight, True)

                    shpShape.blnMoving = True
                    blnGameOver = False

                    tmrTet.Interval = intGameSpeed

                    tmrTet.Enabled = True
                    tmrTet.Start()
                    NextShape()

                Case Else
            End Select
        End If
    End Sub

    ''' <summary>
    ''' Controls Flow Of Game
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tmrTet_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrTet.Tick

        If shpShape.blnMoving Then 'IF Shape Is Still Moving, Move Down
            rctShape = shpShape.MoveDown(intDropRate, grdGame.GetGrid())
            MainGame()
        Else

            'Current Shape Stopped Moving
            Dim intXCoordinate As Integer
            Dim intYCoordinate As Integer
            Dim i As Integer

            'Is Shape Within Game Area? If Not, Game Is Over
            For i = 0 To 3
                If Not rctScreen.Contains(rctShape(i)) Then
                    blnGameOver = True
                    Exit For
                End If
            Next i

            If Not blnGameOver Then

                Dim intYCoordinates(4) As Integer
                'Paint Shape's Final Position

                For i = 0 To 3 'Gets Coordinates
                    intXCoordinate = rctShape(i).X
                    intYCoordinate = rctShape(i).Y
                    intYCoordinates(i) = intYCoordinate / 10

                    'Copy Shape's Position Into Game Grid
                    grdGame.SetLoc(intYCoordinate / 10, intXCoordinate / 10, rctShape(i), intShapeType)
                Next i

                'Sort Array Of Y Coordinates So That We Can Go From Small To Large
                'Enures That We Drop Rows Sequentially
                Array.Sort(intYCoordinates)

                For i = 0 To 3
                    blnRowFull = True

                    'Check If Shape Causes An Entire Row To Fill
                    'If It Does Then We Need To Eliminate The Row And Drop The Rest Down
                    Dim j As Integer

                    For j = 0 To intNoOfCols - 1
                        If grdGame.IsLocEmpty(intYCoordinates(i), j) Then
                            blnRowFull = False
                            Exit For
                        Else
                            blnRowFull = True
                        End If
                    Next j

                    If blnRowFull Then
                        'Drop Row And Fill From Next Row Down

                        Dim k As Integer
                        For k = intYCoordinates(i) To -1 Step -1
                            'Update All Coordinates Of Our Shapes

                            Dim l As Integer
                            For l = 0 To intNoOfCols - 1

                                'Set Value Into Row Below
                                grdGame.DropDown(k, l)
                            Next l
                        Next k

                        'Do Row 0
                        grdGame.FirstRow()

                        'Update Score
                        UpdateScore(intYCoordinates(i))
                    End If
                Next i

                intShapeType = intNextShapeType
                shpShape = New clsTetShapes(intShapeType, scrGame.ScreenWidth, scrGame.ScreenHeight, False)
                intNextShapeType = GetShapeType()
                shpNextShape = New clsTetShapes(intNextShapeType, scrPreview.ScreenWidth, scrPreview.ScreenHeight, True)
                shpShape.blnMoving = True
                NextShape()

                'Reset Game Speed
                tmrTet.Interval = intGameSpeed
                blnDropped = False
            Else
                tmrTet.Stop()
                GameOver()
            End If
        End If
    End Sub

#Region "Part 1 & 2"
    Private Sub frmTet_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Splash()
    End Sub
#End Region


End Class
