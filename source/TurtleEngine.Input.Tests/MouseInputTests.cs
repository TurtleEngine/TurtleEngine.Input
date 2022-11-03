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
namespace TurtleEngine.Input.Tests;

public sealed class MouseInputTests
{
    [Fact]
    public void ScrollWheel_CurrentState_Is_10_Returns_10()
    {
        MouseInput input = new();

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 10,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.Equal(10, input.ScrollWheel);
    }

    [Fact]
    public void ScrollWheelDelta_CurrentState_Is_10_PreviousState_Is_0_Returns_10()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 10,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.Equal(10, input.ScrollWheelDelta);
    }

    [Fact]
    public void Position_CurrentState_Is_X_10_Y_20_Returns_X_10_Y_20()
    {
        MouseInput input = new();

        MouseState curState = new(x: 10,
                                  y: 20,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.Equal(new Point(10, 20), input.Position);
    }

    [Fact]
    public void X_CurrentState_Is_10_Returns_10()
    {
        MouseInput input = new();

        MouseState curState = new(x: 10,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.Equal(10, input.X);
    }

    [Fact]
    public void Y_CurrentState_Is_10_Returns_10()
    {
        MouseInput input = new();

        MouseState curState = new(x: 0,
                                  y: 10,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.Equal(10, input.Y);
    }

    [Fact]
    public void WasMoved_HasMoved_ReturnsTrue()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);


        MouseState curState = new(x: 10,
                                  y: 20,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.WasMoved);
    }

    [Fact]
    public void IsButtonDown_LeftButton_IsDown_ReturnsTrue()
    {
        MouseInput input = new();

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Pressed,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.IsButtonDown(MouseButton.LeftButton));
    }

    [Fact]
    public void IsButtonDown_LeftButton_IsUp_ReturnsFalse()
    {
        MouseInput input = new();

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.IsButtonDown(MouseButton.LeftButton));
    }

    [Fact]
    public void IsButtonDown_LeftButton_IsUp_MiddleButton_IsDown_ReturnsTrue()
    {
        MouseInput input = new();

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Pressed,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.IsButtonDown(MouseButton.LeftButton, MouseButton.MiddleButton));
    }

    [Fact]
    public void IsButtonDown_LeftButton_IsUp_MiddleButton_IsUp_ReturnsFalse()
    {
        MouseInput input = new();

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.IsButtonDown(MouseButton.LeftButton, MouseButton.MiddleButton));
    }

    [Fact]
    public void IsButtonDown_LeftButton_IsUp_MiddleButton_IsUp_RightButton_IsDown_ReturnsTrue()
    {
        MouseInput input = new();

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Pressed,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.IsButtonDown(MouseButton.LeftButton, MouseButton.MiddleButton, MouseButton.RightButton));
    }

    [Fact]
    public void IsButtonDown_LeftButton_IsUp_MiddleButton_IsUp_RightButton_IsUp_ReturnsFalse()
    {
        MouseInput input = new();

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.IsButtonDown(MouseButton.LeftButton, MouseButton.MiddleButton, MouseButton.RightButton));
    }

    [Fact]
    public void IsAnyButtonDown_LeftButton_IsDown_ReturnsTrue()
    {
        MouseInput input = new();

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Pressed,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.IsAnyButtonDown());
    }

    [Fact]
    public void IsAnyButtonDown_NoButtonDown_ReturnsFalse()
    {
        MouseInput input = new();

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.IsAnyButtonDown());
    }

    [Fact]
    public void IsAnyButtonDown_OutArray_LeftButton_IsDown_ReturnsTrue_ReturnsExpectedArray()
    {
        MouseInput input = new();

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Pressed,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.IsAnyButtonDown(out MouseButton[] buttons));
        Assert.Single(buttons);
        Assert.Contains(MouseButton.LeftButton, buttons);
    }

    [Fact]
    public void IsAnyButtonDown_OutArray_NoButtonDown_ReturnsFalse_ReturnsExpectedArray()
    {
        MouseInput input = new();

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.IsAnyButtonDown(out MouseButton[] buttons));
        Assert.Empty(buttons);
    }

    [Fact]
    public void IsButtonUp_LeftButton_IsUp_ReturnsTrue()
    {
        MouseInput input = new();

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.IsButtonUp(MouseButton.LeftButton));
    }

    [Fact]
    public void IsButtonUp_LeftButton_IsDown_ReturnsFalse()
    {
        MouseInput input = new();

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Pressed,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.IsButtonUp(MouseButton.LeftButton));
    }

    [Fact]
    public void IsButtonUp_LeftButton_IsDown_MiddleButton_IsUp_ReturnsTrue()
    {
        MouseInput input = new();

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Pressed,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.IsButtonUp(MouseButton.LeftButton, MouseButton.MiddleButton));
    }

    [Fact]
    public void IsButtonUp_LeftButton_IsDown_MiddleButton_IsDown_ReturnsFalse()
    {
        MouseInput input = new();

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Pressed,
                                  middleButton: ButtonState.Pressed,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.IsButtonUp(MouseButton.LeftButton, MouseButton.MiddleButton));
    }

    [Fact]
    public void IsButtonUp_LeftButton_IsDown_MiddleButton_IsDown_RightButton_IsUp_ReturnsTrue()
    {
        MouseInput input = new();

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Pressed,
                                  middleButton: ButtonState.Pressed,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.IsButtonUp(MouseButton.LeftButton, MouseButton.MiddleButton, MouseButton.RightButton));
    }

    [Fact]
    public void IsButtonUp_LeftButton_IsDown_MiddleButton_IsDown_RightButton_IsDown_ReturnsFalse()
    {
        MouseInput input = new();

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Pressed,
                                  middleButton: ButtonState.Pressed,
                                  rightButton: ButtonState.Pressed,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.IsButtonUp(MouseButton.LeftButton, MouseButton.MiddleButton, MouseButton.RightButton));
    }

    [Fact]
    public void WasButtonJustPressed_LeftButton_WasJustPressed_ReturnsTrue()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Pressed,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.WasButtonJustPressed(MouseButton.LeftButton));
    }

    [Fact]
    public void WasButtonJustPressed_LeftButton_WasNotJustPressed_ReturnsFalse()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                         y: 0,
                                         scrollWheel: 0,
                                         leftButton: ButtonState.Pressed,
                                         middleButton: ButtonState.Released,
                                         rightButton: ButtonState.Released,
                                         xButton1: ButtonState.Released,
                                         xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Pressed,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.WasButtonJustPressed(MouseButton.LeftButton));
    }

    [Fact]
    public void WasButtonJustPressed_LeftButton_WasNotJustPressed_MiddleButton_WasJustPressed_ReturnsTrue()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                 y: 0,
                                 scrollWheel: 0,
                                 leftButton: ButtonState.Pressed,
                                 middleButton: ButtonState.Released,
                                 rightButton: ButtonState.Released,
                                 xButton1: ButtonState.Released,
                                 xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Pressed,
                                  middleButton: ButtonState.Pressed,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.WasButtonJustPressed(MouseButton.LeftButton, MouseButton.MiddleButton));
    }

    [Fact]
    public void WasButtonJustPressed_LeftButton_WasNotJustPressed_MiddleButton_WasNotJustPressed_ReturnsFalse()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                 y: 0,
                                 scrollWheel: 0,
                                 leftButton: ButtonState.Pressed,
                                 middleButton: ButtonState.Pressed,
                                 rightButton: ButtonState.Released,
                                 xButton1: ButtonState.Released,
                                 xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.WasButtonJustPressed(MouseButton.LeftButton, MouseButton.MiddleButton));
    }

    [Fact]
    public void WasButtonJustPressed_LeftButton_WasNotJustPressed_MiddleButton_WasNotJustPressed_RightButton_WasJustPressed_ReturnsTrue()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                 y: 0,
                                 scrollWheel: 0,
                                 leftButton: ButtonState.Pressed,
                                 middleButton: ButtonState.Pressed,
                                 rightButton: ButtonState.Released,
                                 xButton1: ButtonState.Released,
                                 xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Pressed,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.WasButtonJustPressed(MouseButton.LeftButton, MouseButton.MiddleButton, MouseButton.RightButton));
    }

    [Fact]
    public void WasButtonJustPressed_LeftButton_WasNotJustPressed_MiddleButton_WasNotJustPressed_RightButton_WasNotJustPressed_ReturnsFalse()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                 y: 0,
                                 scrollWheel: 0,
                                 leftButton: ButtonState.Pressed,
                                 middleButton: ButtonState.Pressed,
                                 rightButton: ButtonState.Pressed,
                                 xButton1: ButtonState.Released,
                                 xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.WasButtonJustPressed(MouseButton.LeftButton, MouseButton.MiddleButton, MouseButton.RightButton));
    }

    [Fact]
    public void wasAnyButtonJustPressed_LeftButton_WasJustPressed_ReturnsTrue()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                 y: 0,
                                 scrollWheel: 0,
                                 leftButton: ButtonState.Released,
                                 middleButton: ButtonState.Released,
                                 rightButton: ButtonState.Released,
                                 xButton1: ButtonState.Released,
                                 xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Pressed,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.WasAnyButtonJustPressed());
    }

    [Fact]
    public void WasAnyButtonJustPressed_NoButtonDown_ReturnsFalse()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                 y: 0,
                                 scrollWheel: 0,
                                 leftButton: ButtonState.Pressed,
                                 middleButton: ButtonState.Pressed,
                                 rightButton: ButtonState.Pressed,
                                 xButton1: ButtonState.Pressed,
                                 xButton2: ButtonState.Pressed);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Pressed,
                                  middleButton: ButtonState.Pressed,
                                  rightButton: ButtonState.Pressed,
                                  xButton1: ButtonState.Pressed,
                                  xButton2: ButtonState.Pressed);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.WasAnyButtonJustPressed());
    }

    [Fact]
    public void WasAnyButtonJustPressed_OutArray_LeftButton_WasJustPressed_ReturnsTrue_ReturnsExpectedArray()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                 y: 0,
                                 scrollWheel: 0,
                                 leftButton: ButtonState.Released,
                                 middleButton: ButtonState.Released,
                                 rightButton: ButtonState.Released,
                                 xButton1: ButtonState.Released,
                                 xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Pressed,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.WasAnyButtonJustPressed(out MouseButton[] buttons));
        Assert.Single(buttons);
        Assert.Contains(MouseButton.LeftButton, buttons);
    }

    [Fact]
    public void WasAnyButtonJustPressed_OutArray_NoButtonDown_ReturnsFalse_ReturnsExpectedArray()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                 y: 0,
                                 scrollWheel: 0,
                                 leftButton: ButtonState.Pressed,
                                 middleButton: ButtonState.Pressed,
                                 rightButton: ButtonState.Pressed,
                                 xButton1: ButtonState.Pressed,
                                 xButton2: ButtonState.Pressed);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Pressed,
                                  middleButton: ButtonState.Pressed,
                                  rightButton: ButtonState.Pressed,
                                  xButton1: ButtonState.Pressed,
                                  xButton2: ButtonState.Pressed);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.WasAnyButtonJustPressed(out MouseButton[] buttons));
        Assert.Empty(buttons);
    }

    [Fact]
    public void WasButtonJustReleased_LeftButton_WasJustReleased_ReturnsTrue()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Pressed,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.WasButtonJustReleased(MouseButton.LeftButton));
    }

    [Fact]
    public void WasButtonJustReleased_LeftButton_WasNotJustReleased_ReturnsFalse()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                         y: 0,
                                         scrollWheel: 0,
                                         leftButton: ButtonState.Released,
                                         middleButton: ButtonState.Released,
                                         rightButton: ButtonState.Released,
                                         xButton1: ButtonState.Released,
                                         xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.WasButtonJustReleased(MouseButton.LeftButton));
    }

    [Fact]
    public void WasButtonJustReleased_LeftButton_WasNotJustReleased_MiddleButton_WasJustReleased_ReturnsTrue()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                 y: 0,
                                 scrollWheel: 0,
                                 leftButton: ButtonState.Released,
                                 middleButton: ButtonState.Pressed,
                                 rightButton: ButtonState.Released,
                                 xButton1: ButtonState.Released,
                                 xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.WasButtonJustReleased(MouseButton.LeftButton, MouseButton.MiddleButton));
    }

    [Fact]
    public void WasButtonJustReleased_LeftButton_WasNotJustReleased_MiddleButton_WasNotJustReleased_ReturnsFalse()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                 y: 0,
                                 scrollWheel: 0,
                                 leftButton: ButtonState.Released,
                                 middleButton: ButtonState.Released,
                                 rightButton: ButtonState.Released,
                                 xButton1: ButtonState.Released,
                                 xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.WasButtonJustReleased(MouseButton.LeftButton, MouseButton.MiddleButton));
    }

    [Fact]
    public void WasButtonJustReleased_LeftButton_WasNotJustReleased_MiddleButton_WasNotJustReleased_RightButton_WasJustReleased_ReturnsTrue()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                 y: 0,
                                 scrollWheel: 0,
                                 leftButton: ButtonState.Released,
                                 middleButton: ButtonState.Released,
                                 rightButton: ButtonState.Pressed,
                                 xButton1: ButtonState.Released,
                                 xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.WasButtonJustReleased(MouseButton.LeftButton, MouseButton.MiddleButton, MouseButton.RightButton));
    }

    [Fact]
    public void WasButtonJustReleased_LeftButton_WasNotJustReleased_MiddleButton_WasNotJustReleased_RightButton_WasNotJustReleased_ReturnsFalse()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                 y: 0,
                                 scrollWheel: 0,
                                 leftButton: ButtonState.Released,
                                 middleButton: ButtonState.Released,
                                 rightButton: ButtonState.Released,
                                 xButton1: ButtonState.Released,
                                 xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.WasButtonJustReleased(MouseButton.LeftButton, MouseButton.MiddleButton, MouseButton.RightButton));
    }

    [Fact]
    public void WasAnyButtonJustReleased_LeftButton_WasJustReleased_ReturnsTrue()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                 y: 0,
                                 scrollWheel: 0,
                                 leftButton: ButtonState.Pressed,
                                 middleButton: ButtonState.Released,
                                 rightButton: ButtonState.Released,
                                 xButton1: ButtonState.Released,
                                 xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.WasAnyButtonJustReleased());
    }

    [Fact]
    public void WasAnyButtonJustReleased_NoButtonDown_ReturnsFalse()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                 y: 0,
                                 scrollWheel: 0,
                                 leftButton: ButtonState.Released,
                                 middleButton: ButtonState.Released,
                                 rightButton: ButtonState.Released,
                                 xButton1: ButtonState.Released,
                                 xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.WasAnyButtonJustReleased());
    }

    [Fact]
    public void WasAnyButtonJustReleased_OutArray_LeftButton_WasJustReleased_ReturnsTrue_ReturnsExpectedArray()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                 y: 0,
                                 scrollWheel: 0,
                                 leftButton: ButtonState.Pressed,
                                 middleButton: ButtonState.Released,
                                 rightButton: ButtonState.Released,
                                 xButton1: ButtonState.Released,
                                 xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.WasAnyButtonJustReleased(out MouseButton[] buttons));
        Assert.Single(buttons);
        Assert.Contains(MouseButton.LeftButton, buttons);
    }

    [Fact]
    public void WasAnyButtonJustReleased_OutArray_NoButtonDown_ReturnsFalse_ReturnsExpectedArray()
    {
        MouseInput input = new();

        MouseState prevState = new(x: 0,
                                 y: 0,
                                 scrollWheel: 0,
                                 leftButton: ButtonState.Released,
                                 middleButton: ButtonState.Released,
                                 rightButton: ButtonState.Released,
                                 xButton1: ButtonState.Released,
                                 xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.PreviousState))?.SetValue(input, prevState);

        MouseState curState = new(x: 0,
                                  y: 0,
                                  scrollWheel: 0,
                                  leftButton: ButtonState.Released,
                                  middleButton: ButtonState.Released,
                                  rightButton: ButtonState.Released,
                                  xButton1: ButtonState.Released,
                                  xButton2: ButtonState.Released);

        typeof(MouseInput).GetProperty(nameof(MouseInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.WasAnyButtonJustReleased(out MouseButton[] buttons));
        Assert.Empty(buttons);
    }
}
