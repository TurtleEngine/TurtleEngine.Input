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
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace TurtleEngine.Input.Tests;

public class KeyboardInputTests
{
    [Fact]
    public void IsKeyDown_KeyA_IsDown_ReturnsTrue()
    {
        KeyboardInput input = new();

        KeyboardState curState = new(Keys.A);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.IsKeyDown(Keys.A));
    }

    [Fact]
    public void IsKeyDown_KeyA_IsUp_ReturnsFalse()
    {
        KeyboardInput input = new();

        KeyboardState curState = new();
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.IsKeyDown(Keys.A));
    }

    [Fact]
    public void IsKeyDown_KeyA_IsUp_KeyB_IsDown_ReturnsTrue()
    {
        KeyboardInput input = new();

        KeyboardState curState = new(Keys.B);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.IsKeyDown(Keys.A, Keys.B));
    }

    [Fact]
    public void IsKeyDown_KeyA_IsUp_KeyB_IsUp_ReturnsFalse()
    {
        KeyboardInput input = new();

        KeyboardState curState = new();
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.IsKeyDown(Keys.A, Keys.B));
    }

    [Fact]
    public void IsKeyDown_KeyA_IsUp_KeyB_IsUp_KeyC_IsDown_ReturnsTrue()
    {
        KeyboardInput input = new();

        KeyboardState curState = new(Keys.C);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.IsKeyDown(Keys.A, Keys.B, Keys.C));
    }

    [Fact]
    public void IsKeyDown_KeyA_IsUp_KeyB_IsUp_KeyC_IsUp_ReturnsFalse()
    {
        KeyboardInput input = new();

        KeyboardState curState = new();
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.IsKeyDown(Keys.A, Keys.B, Keys.C));
    }

    [Fact]
    public void IsAnyKeyDown_KeyA_IsDown_ReturnsTrue()
    {
        KeyboardInput input = new();

        KeyboardState curState = new(Keys.A);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.IsAnyKeyDown());
    }

    [Fact]
    public void IsAnyKeyDown_OutArray_KeyA_IsDown_ReturnsTrue_ExpectedArray()
    {
        KeyboardInput input = new();

        KeyboardState curState = new(Keys.A);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.IsAnyKeyDown(out Keys[] keys));
        Assert.Single(keys);
        Assert.Contains(Keys.A, keys);
    }

    [Fact]
    public void IsKeyUp_KeyA_IsUp_ReturnsTrue()
    {
        KeyboardInput input = new();

        KeyboardState curState = new();
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.IsKeyUp(Keys.A));
    }

    [Fact]
    public void IsKeyUp_KeyA_IsDown_ReturnsFalse()
    {
        KeyboardInput input = new();

        KeyboardState curState = new(Keys.A);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.IsKeyUp(Keys.A));
    }

    [Fact]
    public void IsKeyUp_KeyA_IsDown_KeyB_IsUp_ReturnsTrue()
    {
        KeyboardInput input = new();

        KeyboardState curState = new(Keys.A);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.IsKeyUp(Keys.A, Keys.B));
    }

    [Fact]
    public void IsKeyUp_KeyA_IsDown_KeyB_IsDown_ReturnsFalse()
    {
        KeyboardInput input = new();

        KeyboardState curState = new(Keys.A, Keys.B);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.IsKeyUp(Keys.A, Keys.B));
    }

    [Fact]
    public void IsKeyUp_KeyA_IsDown_KeyB_IsDown_KeyC_IsUp_ReturnsTrue()
    {
        KeyboardInput input = new();

        KeyboardState curState = new(Keys.A, Keys.B);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.IsKeyUp(Keys.A, Keys.B, Keys.C));
    }

    [Fact]
    public void IsKeyUp_KeyA_IsDown_KeyB_IsDown_KeyC_IsDown_ReturnsFalse()
    {
        KeyboardInput input = new();

        KeyboardState curState = new(Keys.A, Keys.B, Keys.C);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.IsKeyUp(Keys.A, Keys.B, Keys.C));
    }

    [Fact]
    public void WasKeyJustPressed_KeyA_WasPressed_ReturnsTrue()
    {
        KeyboardInput input = new();

        KeyboardState prevState = new();
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.PreviousState))?.SetValue(input, prevState);

        KeyboardState curState = new(Keys.A);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.WasKeyJustPressed(Keys.A));
    }

    [Fact]
    public void WasKeyJustPressed_KeyA_WasNotPressed_ReturnsFalse()
    {
        KeyboardInput input = new();

        KeyboardState prevState = new(Keys.A);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.PreviousState))?.SetValue(input, prevState);

        KeyboardState curState = new(Keys.A);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.WasKeyJustPressed(Keys.A));
    }

    [Fact]
    public void WasKeyJustPressed_KeyA_WasNotPressed_KeyB_WasPressed_ReturnsTrue()
    {
        KeyboardInput input = new();

        KeyboardState prevState = new(Keys.A);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.PreviousState))?.SetValue(input, prevState);

        KeyboardState curState = new(Keys.A, Keys.B);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.WasKeyJustPressed(Keys.A, Keys.B));
    }

    [Fact]
    public void WasKeyJustPressed_KeyA_WasNotPressed_KeyB_WasNotPresssed_ReturnsFalse()
    {
        KeyboardInput input = new();

        KeyboardState prevState = new(Keys.A, Keys.B);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.PreviousState))?.SetValue(input, prevState);

        KeyboardState curState = new(Keys.A, Keys.B);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.WasKeyJustPressed(Keys.A, Keys.B));
    }

    [Fact]
    public void WasKeyJustPressed_KeyA_WasNotPressed_KeyB_WasNotPressed_KeyC_WasPressed_ReturnsTrue()
    {
        KeyboardInput input = new();

        KeyboardState prevState = new(Keys.A, Keys.B);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.PreviousState))?.SetValue(input, prevState);

        KeyboardState curState = new(Keys.A, Keys.B, Keys.C);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.WasKeyJustPressed(Keys.A, Keys.B, Keys.C));
    }

    [Fact]
    public void WasKeyJustPressed_KeyA_WasNotPressed_KeyB_WasNotPresssed_KeyC_WasNotPressed_ReturnsFalse()
    {
        KeyboardInput input = new();

        KeyboardState prevState = new(Keys.A, Keys.B, Keys.C);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.PreviousState))?.SetValue(input, prevState);

        KeyboardState curState = new(Keys.A, Keys.B, Keys.C);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.WasKeyJustPressed(Keys.A, Keys.B, Keys.C));
    }

    [Fact]
    public void WasAnyKeyPressed_KeyA_WasPressed_ReturnsTrue()
    {
        KeyboardInput input = new();

        KeyboardState prevState = new();
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.PreviousState))?.SetValue(input, prevState);

        KeyboardState curState = new(Keys.A);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.WasAnyKeyJustPressed());
    }

    [Fact]
    public void WasAnyKeyPressed_NoKeysPressed_ReturnsFalse()
    {
        KeyboardInput input = new();

        KeyboardState prevState = new();
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.PreviousState))?.SetValue(input, prevState);

        KeyboardState curState = new();
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.WasAnyKeyJustPressed());
    }

    [Fact]
    public void WasAnyKeyPressed_OutArray_KeyA_WasPressed_ReturnsTrue_ExpectedArray()
    {
        KeyboardInput input = new();

        KeyboardState prevState = new();
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.PreviousState))?.SetValue(input, prevState);

        KeyboardState curState = new(Keys.A);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.WasAnyKeyJustPressed(out Keys[] keys));
        Assert.Single(keys);
        Assert.Contains(Keys.A, keys);
    }

    [Fact]
    public void WasKeyJustReleased_KeyA_WasReleased_ReturnsTrue()
    {
        KeyboardInput input = new();

        KeyboardState prevState = new(Keys.A);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.PreviousState))?.SetValue(input, prevState);

        KeyboardState curState = new();
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.WasKeyJustReleased(Keys.A));
    }

    [Fact]
    public void WasKeyJustReleased_KeyA_WasNotReleased_ReturnsFalse()
    {
        KeyboardInput input = new();

        KeyboardState prevState = new();
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.PreviousState))?.SetValue(input, prevState);

        KeyboardState curState = new();
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.WasKeyJustReleased(Keys.A));
    }

    [Fact]
    public void WasKeyJustReleased_KeyA_WasNotReleased_KeyB_WasReleased_ReturnsTrue()
    {
        KeyboardInput input = new();

        KeyboardState prevState = new(Keys.A, Keys.B);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.PreviousState))?.SetValue(input, prevState);

        KeyboardState curState = new(Keys.A);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.WasKeyJustReleased(Keys.A, Keys.B));
    }

    [Fact]
    public void WasKeyJustReleased_KeyA_WasNotReleased_KeyB_WasNotReleased_ReturnsFalse()
    {
        KeyboardInput input = new();

        KeyboardState prevState = new();
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.PreviousState))?.SetValue(input, prevState);

        KeyboardState curState = new();
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.WasKeyJustReleased(Keys.A, Keys.B));
    }

    [Fact]
    public void WasKeyJustReleased_KeyA_WasNotReleased_KeyB_WasNotReleased_KeyC_WasReleased_ReturnsTrue()
    {
        KeyboardInput input = new();

        KeyboardState prevState = new(Keys.A, Keys.B, Keys.C);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.PreviousState))?.SetValue(input, prevState);

        KeyboardState curState = new(Keys.A, Keys.B);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.WasKeyJustReleased(Keys.A, Keys.B, Keys.C));
    }

    [Fact]
    public void WasKeyJustReleased_KeyA_WasNotReleased_KeyB_WasNotReleased_KeyC_WasNotReleased_ReturnsFalse()
    {
        KeyboardInput input = new();

        KeyboardState prevState = new();
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.PreviousState))?.SetValue(input, prevState);

        KeyboardState curState = new();
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.WasKeyJustReleased(Keys.A, Keys.B, Keys.C));
    }

    [Fact]
    public void WasAnyKeyReleased_KeyA_WasReleased_ReturnsTrue()
    {
        KeyboardInput input = new();

        KeyboardState prevState = new(Keys.A);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.PreviousState))?.SetValue(input, prevState);

        KeyboardState curState = new();
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.WasAnyKeyJustReleased());
    }

    [Fact]
    public void WasAnyKeyReleased_NoKeysReleased_ReturnsFalse()
    {
        KeyboardInput input = new();

        KeyboardState prevState = new(Keys.A);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.PreviousState))?.SetValue(input, prevState);

        KeyboardState curState = new(Keys.A);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.False(input.WasAnyKeyJustReleased());
    }

    [Fact]
    public void WasAnyKeyReleased_OutArray_KeyA_WasReleased_ReturnsTrue_ExpectedArray()
    {
        KeyboardInput input = new();

        KeyboardState prevState = new(Keys.A);
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.PreviousState))?.SetValue(input, prevState);

        KeyboardState curState = new();
        typeof(KeyboardInput).GetProperty(nameof(KeyboardInput.CurrentState))?.SetValue(input, curState);

        Assert.True(input.WasAnyKeyJustReleased(out Keys[] keys));
        Assert.Single(keys);
        Assert.Contains(Keys.A, keys);
    }

}
