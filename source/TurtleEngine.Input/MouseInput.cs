/* ----------------------------------------------------------------------------
MIT License

Copyright (c) 2022 Christopher Whitley

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
---------------------------------------------------------------------------- */
namespace TurtleEngine.Input;

public sealed class MouseInput
{
    /// <summary>
    ///     Gets a <see cref="MouseState"/> value that defines the underlying
    ///     state of mouse input during the previous frame.
    /// </summary>
    public MouseState PreviousState { get; private set; } = new();

    /// <summary>
    ///     Gets a <see cref="MouseState"/> value that defines the underlying
    ///     state of mouse input during the previous frame.
    /// </summary>
    public MouseState CurrentState { get; private set; } = new();

    /// <summary>
    ///     Gets the cumulative scroll wheel value since the start of the game.
    /// </summary>
    public int ScrollWheel => CurrentState.ScrollWheelValue;

    /// <summary>
    ///     Gets the delta of the scroll wheel value betwen the previous frame
    ///     and the current frame.
    /// </summary>
    public int ScrollWheelDelta => CurrentState.ScrollWheelValue - PreviousState.ScrollWheelValue;

    /// <summary>
    ///     Get or Sets the xy-coordinate position of the mouse.
    /// </summary>
    public Point Position
    {
        get => CurrentState.Position;
        set => Mouse.SetPosition(value.X, value.Y);
    }

    /// <summary>
    ///     Gets or Sets the x-coordinate element of the mouse position.
    /// </summary>
    public int X
    {
        get => CurrentState.Position.X;
        set => Mouse.SetPosition(value, CurrentState.Position.Y);
    }

    /// <summary>
    ///     Gets or Sets the y-coordinate element of the mouse position.
    /// </summary>
    public int Y
    {
        get => CurrentState.Position.Y;
        set => Mouse.SetPosition(CurrentState.Position.X, value);
    }

    /// <summary>
    ///     Gets a value that indicates whether the mouse position has changed
    ///     between the previous and current frame.
    /// </summary>
    public bool WasMoved => CurrentState.Position != PreviousState.Position;

    /// <summary>
    ///     Creates a new <see cref="MouseInput"/> class instance.
    ///     Creates a new instance.
    /// </summary>
    public MouseInput() { }

    /// <summary>
    ///     Updates the underlying mouse state values for this instance.
    /// </summary>
    public void Update()
    {
        PreviousState = CurrentState;
        CurrentState = Mouse.GetState();
    }

    /// <summary>
    ///     Returns a value that indicates whether <paramref name="button"/> is
    ///     current down.
    /// </summary>
    /// <param name="button">
    ///     The mouse button to check.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if <paramref name="button"/> is currently
    ///     down; otherwise, <see langword="false"/>.
    /// </returns>
    public bool IsButtonDown(MouseButton button) => button switch
    {
        MouseButton.LeftButton => CurrentState.LeftButton.IsDown(),
        MouseButton.MiddleButton => CurrentState.MiddleButton.IsDown(),
        MouseButton.RightButton => CurrentState.RightButton.IsDown(),
        MouseButton.XButton1 => CurrentState.XButton1.IsDown(),
        MouseButton.XButton2 => CurrentState.XButton2.IsDown(),
        _ => false
    };

    /// <summary>
    ///     Returns a value that indicates whether <paramref name="buttonA"/> or
    ///     <paramref name="buttonB"/> is currently down.
    /// </summary>
    /// <param name="buttonA">
    ///     The first mouse button to check.
    /// </param>
    /// <param name="buttonB">
    ///     The second mouse button to check.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if either <paramref name="buttonA"/> or
    ///     <paramref name="buttonB"/> is currently down;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    public bool IsButtonDown(MouseButton buttonA, MouseButton buttonB) => IsButtonDown(buttonA) || IsButtonDown(buttonB);

    /// <summary>
    ///     Returns a value that indicates whether <paramref name="buttonA"/>,
    ///     <paramref name="buttonB"/>, or <paramref name="buttonC"/> is
    ///     currently down.
    /// </summary>
    /// <param name="buttonA">
    ///     The first mouse button to check.
    /// </param>
    /// <param name="buttonB">
    ///     The second mouse button to check.
    /// </param>
    /// <param name="buttonC">
    ///     The third mouse button to check.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if either <paramref name="buttonA"/>,
    ///     <paramref name="buttonB"/>, or <paramref name="buttonC"/> is
    ///     currently down; otherwise, <see langword="false"/>.
    /// </returns>
    public bool IsButtonDown(MouseButton buttonA, MouseButton buttonB, MouseButton buttonC) =>
     IsButtonDown(buttonA) || IsButtonDown(buttonB) || IsButtonDown(buttonC);

    /// <summary>
    ///     Returns a value that indicates whether any mouse button is currently
    ///     down.
    /// </summary>
    /// <returns>
    ///     <see langword="true"/> if any mouse button is currently down;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    public bool IsAnyButtonDown()
    {
        foreach (MouseButton button in (MouseButton[])Enum.GetValues<MouseButton>())
        {
            if (IsButtonDown(button))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    ///     Returns a value that indicates whether any mouse button is currently
    ///     down.
    /// </summary>
    /// <param name="buttons">
    ///     When this method returns, each element of the array contains a
    ///     <see cref="MouseButton"/> value for each mouse button that is
    ///     currently down. This is passed in uninitialized.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if any mouse button is currently down;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    public bool IsAnyButtonDown(out MouseButton[] buttons)
    {
        List<MouseButton> isDown = new();

        foreach (MouseButton button in (MouseButton[])Enum.GetValues<MouseButton>())
        {
            if (IsButtonDown(button))
            {
                isDown.Add(button);
            }
        }

        buttons = isDown.ToArray();
        return buttons.Length > 0;
    }

    /// <summary>
    ///     Returns a value that idnicates whether <paramref name="button"/> is
    ///     currently up.
    /// </summary>
    /// <param name="button">
    ///     The mouse button to check.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if <paramref name="button"/> is currently up;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    public bool IsButtonUp(MouseButton button) => button switch
    {
        MouseButton.LeftButton => CurrentState.LeftButton.IsUp(),
        MouseButton.MiddleButton => CurrentState.MiddleButton.IsUp(),
        MouseButton.RightButton => CurrentState.RightButton.IsUp(),
        MouseButton.XButton1 => CurrentState.XButton1.IsUp(),
        MouseButton.XButton2 => CurrentState.XButton2.IsUp(),
        _ => false
    };

    /// <summary>
    ///     Returns a value that indicates whether <paramref name="buttonA"/> or
    ///     <paramref name="buttonB"/> is currently up.
    /// </summary>
    /// <param name="buttonA">
    ///     The first mouse button to check.
    /// </param>
    /// <param name="buttonB">
    ///     The second mouse button to check.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if either <paramref name="buttonA"/> or
    ///     <paramref name="buttonB"/> is currently up; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public bool IsButtonUp(MouseButton buttonA, MouseButton buttonB) => IsButtonUp(buttonA) || IsButtonUp(buttonB);

    /// <summary>
    ///     Returns a value that indicates whether <paramref name="buttonA"/>,
    ///     <paramref name="buttonB"/>, or <paramref name="buttonC"/> is
    ///     currently up.
    /// </summary>
    /// <param name="buttonA">
    ///     The first mouse button to check.
    /// </param>
    /// <param name="buttonB">
    ///     The second mouse button to check.
    /// </param>
    /// <param name="buttonC">
    ///     The third mouse button to check.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if either <paramref name="buttonA"/>,
    ///     <paramref name="buttonB"/>, or <paramref name="buttonC"/> is
    ///     currently up; otherwise, <see langword="false"/>.
    /// </returns>
    public bool IsButtonUp(MouseButton buttonA, MouseButton buttonB, MouseButton buttonC) =>
        IsButtonUp(buttonA) || IsButtonUp(buttonB) || IsButtonUp(buttonC);

    /// <summary>
    ///     Returns a value that indicates whether <paramref name="button"/> was
    ///     just pressed.
    /// </summary>
    /// <remarks>
    ///     "Just Pressed" means that the mouse button was just pushed down on
    ///     the current frame and was up on the previous frame.  This means that
    ///     if they mouse button is down for two frames in a row it is not
    ///     considered as "Just Pressed".
    /// </remarks>
    /// <param name="button">
    ///     The mouse button to check
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if <paramref name="button"/> was just
    ///     pressed; otherwise, <see langword="false"/>.
    /// </returns>
    public bool WasButtonJustPressed(MouseButton button) => button switch
    {
        MouseButton.LeftButton => CurrentState.LeftButton.IsDown() && PreviousState.LeftButton.IsUp(),
        MouseButton.MiddleButton => CurrentState.MiddleButton.IsDown() && PreviousState.MiddleButton.IsUp(),
        MouseButton.RightButton => CurrentState.RightButton.IsDown() && PreviousState.RightButton.IsUp(),
        MouseButton.XButton1 => CurrentState.XButton1.IsDown() && PreviousState.XButton1.IsUp(),
        MouseButton.XButton2 => CurrentState.XButton2.IsDown() && PreviousState.XButton2.IsUp(),
        _ => false
    };

    /// <summary>
    ///     Returns a value that indicates whether <paramref name="buttonA"/> or
    ///     <paramref name="buttonB"/> was just pressed.
    /// </summary>
    /// <remarks>
    ///     "Just Pressed" means that the mouse button was just pushed down on
    ///     the current frame and was up on the previous frame.  This means that
    ///     if they mouse button is down for two frames in a row it is not
    ///     considered as "Just Pressed".
    /// </remarks>
    /// <param name="buttonA">
    ///     The first mouse button to check.
    /// </param>
    /// <param name="buttonB">
    ///     The second mouse button to check.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if either <paramref name="buttonA"/> or
    ///     <paramref name="buttonB"/> was just pressed; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public bool WasButtonJustPressed(MouseButton buttonA, MouseButton buttonB) =>
        WasButtonJustPressed(buttonA) || WasButtonJustPressed(buttonB);

    /// <summary>
    ///     Returns a value that indicates whether <paramref name="buttonA"/>,
    ///     <paramref name="buttonB"/>, or <paramref name="buttonC"/> was just
    ///     pressed.
    /// </summary>
    /// <remarks>
    ///     "Just Pressed" means that the mouse button was just pushed down on
    ///     the current frame and was up on the previous frame.  This means that
    ///     if they mouse button is down for two frames in a row it is not
    ///     considered as "Just Pressed".
    /// </remarks>
    /// <param name="buttonA">
    ///     The first mouse button to check.
    /// </param>
    /// <param name="buttonB">
    ///     The second mouse button to check.
    /// </param>
    /// <param name="buttonB">
    ///     The third mouse button to check.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if either <paramref name="buttonA"/>,
    ///     <paramref name="buttonB"/>, or <paramref name="buttonC"/> was just
    ///     pressed; otherwise, <see langword="false"/>.
    /// </returns>
    public bool WasButtonJustPressed(MouseButton buttonA, MouseButton buttonB, MouseButton buttonC) =>
        WasButtonJustPressed(buttonA) || WasButtonJustPressed(buttonB) || WasButtonJustPressed(buttonC);

    /// <summary>
    ///     Returns a value that indicates whether any mouse button was just
    ///     pressed.
    /// </summary>
    /// <remarks>
    ///     "Just Pressed" means that the mouse button was just pushed down on
    ///     the current frame and was up on the previous frame.  This means that
    ///     if they mouse button is down for two frames in a row it is not
    ///     considered as "Just Pressed".
    /// </remarks>
    /// <returns>
    ///     <see langword="true"/> if any mouse button was just pressed;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    public bool WasAnyButtonJustPressed()
    {
        foreach (MouseButton button in (MouseButton[])Enum.GetValues<MouseButton>())
        {
            if (WasButtonJustPressed(button))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    ///     Returns a value that indicates whether any mouse button was just
    ///     pressed.
    /// </summary>
    /// <remarks>
    ///     "Just Pressed" means that the mouse button was just pushed down on
    ///     the current frame and was up on the previous frame.  This means that
    ///     if they mouse button is down for two frames in a row it is not
    ///     considered as "Just Pressed".
    /// </remarks>
    /// <param name="buttons">
    ///     When this method returns, each element of the array contains a
    ///     <see cref="MouseButton"/> value for each mouse button that was
    ///     just pressed. This is passed in uninitialized.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if any mouse button was just pressed;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    public bool WasAnyButtonJustPressed(out MouseButton[] buttons)
    {
        List<MouseButton> wasPressed = new();

        foreach (MouseButton button in (MouseButton[])Enum.GetValues<MouseButton>())
        {
            if (WasButtonJustPressed(button))
            {
                wasPressed.Add(button);
            }
        }

        buttons = wasPressed.ToArray();
        return buttons.Length > 0;
    }

    /// <summary>
    ///     Returns a value that indicates whether <paramref name="button"/> was
    ///     just released.
    /// </summary>
    /// <remarks>
    ///     "Just Released" means that the mouse button is up on the current
    ///     frame and down on the previous frame.  This means that if the
    ///     mouse button is up for two frames in a row, it is not considered
    ///     as "Just Released".
    /// </remarks>
    /// <param name="button">
    ///     The mouse button to check.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if <paramref name="button"/> was just
    ///     released; otherwise, <see langword="false"/>.
    /// </returns>
    public bool WasButtonJustReleased(MouseButton button) => button switch
    {
        MouseButton.LeftButton => CurrentState.LeftButton.IsUp() && PreviousState.LeftButton.IsDown(),
        MouseButton.MiddleButton => CurrentState.MiddleButton.IsUp() && PreviousState.MiddleButton.IsDown(),
        MouseButton.RightButton => CurrentState.RightButton.IsUp() && PreviousState.RightButton.IsDown(),
        MouseButton.XButton1 => CurrentState.XButton1.IsUp() && PreviousState.XButton1.IsDown(),
        MouseButton.XButton2 => CurrentState.XButton2.IsUp() && PreviousState.XButton2.IsDown(),
        _ => false
    };

    /// <summary>
    ///     Returns a value that indicates whether <paramref name="buttonA"/> or
    ///     <paramref name="buttonB"/> was just released.
    /// </summary>
    /// <remarks>
    ///     "Just Released" means that the mouse button is up on the current
    ///     frame and down on the previous frame.  This means that if the
    ///     mouse button is up for two frames in a row, it is not considered
    ///     as "Just Released".
    /// </remarks>
    /// <param name="buttonA">
    ///     The first mouse button to check.
    /// </param>
    /// <param name="buttonB">
    ///     The second mouse button to check.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if either <paramref name="buttonA"/> or
    ///     <paramref name="buttonB"/> was just released; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public bool WasButtonJustReleased(MouseButton buttonA, MouseButton buttonB) =>
        WasButtonJustReleased(buttonA) || WasButtonJustReleased(buttonB);

    /// <summary>
    ///     Returns a value that indicates whether <paramref name="buttonA"/>,
    ///     <paramref name="buttonB"/>, or <paramref name="buttonC"/> was just
    ///     released.
    /// </summary>
    /// <remarks>
    ///     "Just Released" means that the mouse button is up on the current
    ///     frame and down on the previous frame.  This means that if the
    ///     mouse button is up for two frames in a row, it is not considered
    ///     as "Just Released".
    /// </remarks>
    /// <param name="buttonA">
    ///     The first mouse button to check.
    /// </param>
    /// <param name="buttonB">
    ///     The second mouse button to check.
    /// </param>
    /// <param name="buttonB">
    ///     The third mouse button to check.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if either <paramref name="buttonA"/>,
    ///     <paramref name="buttonB"/>, or <paramref name="buttonC"/> was just
    ///     released; otherwise, <see langword="false"/>.
    /// </returns>
    public bool WasButtonJustReleased(MouseButton buttonA, MouseButton buttonB, MouseButton buttonC) =>
        WasButtonJustReleased(buttonA) || WasButtonJustReleased(buttonB) || WasButtonJustReleased(buttonC);

    /// <summary>
    ///     Returns a value that indicates whether any mouse button was just
    ///     released.
    /// </summary>
    /// <remarks>
    ///     "Just Released" means that the mouse button is up on the current
    ///     frame and down on the previous frame.  This means that if the
    ///     mouse button is up for two frames in a row, it is not considered
    ///     as "Just Released".
    /// </remarks>
    /// <returns>
    ///     <see langword="true"/> if any mouse button was just released;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    public bool WasAnyButtonJustReleased()
    {
        foreach (MouseButton button in (MouseButton[])Enum.GetValues<MouseButton>())
        {
            if (WasButtonJustReleased(button))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    ///     Returns a value that indicates whether any mouse button was just
    ///     released.
    /// </summary>
    /// <remarks>
    ///     "Just Released" means that the mouse button is up on the current
    ///     frame and down on the previous frame.  This means that if the
    ///     mouse button is up for two frames in a row, it is not considered
    ///     as "Just Released".
    /// </remarks>
    /// <param name="buttons">
    ///     When this method returns, each element of the array contains a
    ///     <see cref="MouseButton"/> value for each mouse button that was
    ///     just released. This is passed in uninitialized.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if any mouse button was just released;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    public bool WasAnyButtonJustReleased(out MouseButton[] buttons)
    {
        List<MouseButton> wasReleased = new();

        foreach (MouseButton button in (MouseButton[])Enum.GetValues<MouseButton>())
        {
            if (WasButtonJustReleased(button))
            {
                wasReleased.Add(button);
            }
        }

        buttons = wasReleased.ToArray();
        return buttons.Length > 0;
    }
}
