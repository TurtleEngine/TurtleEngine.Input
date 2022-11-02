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
using Microsoft.Xna.Framework.Input;

namespace TurtleEngine.Input;

public sealed class KeyboardInput
{
    /// <summary>
    ///     Gets the state of keyboard input during the previous frame.
    /// </summary>
    public KeyboardState PreviousState { get; private set; } = new();

    /// <summary>
    ///     Gets the state of keyboard input during the current frame.
    /// </summary>
    public KeyboardState CurrentState { get; private set; } = new();

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    public KeyboardInput() { }

    /// <summary>
    ///     Updates the internal state values for this instance.
    /// </summary>
    public void Update()
    {
        PreviousState = CurrentState;
        CurrentState = Keyboard.GetState();
    }

    /// <summary>
    ///     Returns a value that indicates whether the specified keyboard key
    ///     is currently being pressed down.
    /// </summary>
    /// <param name="key">
    ///     The keyboard key to check.
    /// </param>
    /// <returns>
    ///     true if the specified keyboard key is currently being pressed down;
    ///     otherwise, false.
    /// </returns>
    public bool IsKeyDown(Keys key) => CurrentState.IsKeyDown(key);

    /// <summary>
    ///     Returns a value that indicates whether either of the specified
    ///     keyboard keys are currently being pressed down.
    /// </summary>
    /// <param name="keyA">
    ///     The first keyboard key to check.
    /// </param>
    /// <param name="keyB">
    ///     The second keyboard key to check.
    /// </param>
    /// <returns>
    ///     true if either of the specified keybaord keys are currently being
    ///     pressed down; otherwise, false.
    /// </returns>
    public bool IsKeyDown(Keys keyA, Keys keyB) => IsKeyDown(keyA) || IsKeyDown(keyB);

    /// <summary>
    ///     Returns a value that indicates whether any of the specified keyboard
    ///     keys are currently being pressed down.
    /// </summary>
    /// <param name="keyA">
    ///     The first keyboard key to check.
    /// </param>
    /// <param name="keyB">
    ///     The second keyboard key to check.
    /// </param>
    /// <param name="keyC">
    ///     The third keyboard key to check.
    /// </param>
    /// <returns>
    ///     true if any of the specified keyboard keys are currently being
    ///     pressed down; otherwise, false.
    /// </returns>
    public bool IsKeyDown(Keys keyA, Keys keyB, Keys keyC) => IsKeyDown(keyA) || IsKeyDown(keyB) || IsKeyDown(keyC);

    /// <summary>
    ///     Returns a value that indicates whether any keyboard key is currently
    ///     being pressed down.
    /// </summary>
    /// <returns>
    ///     true if any keyboard key is currently being pressed down; otherwise,
    ///     false.
    /// </returns>
    public bool IsAnyKeyDown() => CurrentState.GetPressedKeyCount() > 0;

    /// <summary>
    ///     Returns a value that indicates whether any keyboard key is currently
    ///     being pressed down.
    /// </summary>
    /// <param name="keys">
    ///     When this method returns, contains all keyboard keys that are
    ///     currently being pressed down.  This is passed in uninitialized.
    /// </param>
    /// <returns>
    ///     true if any keyboard key is currently being pressed down; otherwise,
    ///     false.
    /// </returns>
    public bool IsAnyKeyDown(out Keys[] keys) => (keys = CurrentState.GetPressedKeys()).Length > 0;


    /// <summary>
    ///     Returns a value that indicates whether the specified keyboard key
    ///     is currently not being pressed down.
    /// </summary>
    /// <param name="key">
    ///     The keyboard key to check.
    /// </param>
    /// <returns>
    ///     true if the specified keyboard key is currently not being pressed
    ///     down; otherwise, false.
    /// </returns>
    public bool IsKeyUp(Keys key) => CurrentState.IsKeyUp(key);

    /// <summary>
    ///     Returns a value that indicates whether either of the specified
    ///     keyboard keys are currently not being pressed down.
    /// </summary>
    /// <param name="keyA">
    ///     The first keyboard key to check.
    /// </param>
    /// <param name="keyB">
    ///     The second keyboard key to check.
    /// </param>
    /// <returns>
    ///     true if either of the specified keybaord keys are not currently
    ///     being pressed down; otherwise, false.
    /// </returns>
    public bool IsKeyUp(Keys keyA, Keys keyB) => IsKeyUp(keyA) || IsKeyUp(keyB);

    /// <summary>
    ///     Returns a value that indicates whether any of the specified keyboard
    ///     keys are not currently being pressed down.
    /// </summary>
    /// <param name="keyA">
    ///     The first keyboard key to check.
    /// </param>
    /// <param name="keyB">
    ///     The second keyboard key to check.
    /// </param>
    /// <param name="keyC">
    ///     The third keyboard key to check.
    /// </param>
    /// <returns>
    ///     true if any of the specified keyboard keys are not currently being
    ///     pressed down; otherwise, false.
    /// </returns>
    public bool IsKeyUp(Keys keyA, Keys keyB, Keys keyC) => IsKeyUp(keyA) || IsKeyUp(keyB) || IsKeyUp(keyC);

    /// <summary>
    ///     Returns a value that indicates whether the specified keyboard key
    ///     was just pressed.
    /// </summary>
    /// <remarks>
    ///     "Just Pressed" means that the keyboard key was just pushed down on
    ///     the current frame and was up on the previous frame.  This means that
    ///     if they keyboard key is down for two frames in a row it is not
    ///     considered as "Just Pressed".
    /// </remarks>
    /// <param name="key">
    ///     The keyboard key to check.
    /// </param>
    /// <returns>
    ///     true if the specified keyboard key was just pressed; otherwise,
    ///     false.
    /// </returns>
    public bool WasKeyJustPressed(Keys key) => CurrentState.IsKeyDown(key) && PreviousState.IsKeyUp(key);

    /// <summary>
    ///     Returns a value that indicates whether either of specified keyboard
    ///     keys was just pressed.
    /// </summary>
    /// <remarks>
    ///     "Just Pressed" means that the keyboard key was just pushed down on
    ///     the current frame and was up on the previous frame.  This means that
    ///     if they keyboard key is down for two frames in a row it is not
    ///     considered as "Just Pressed".
    /// </remarks>
    /// <param name="keyA">
    ///     The first keyboard key to check.
    /// </param>
    /// <param name="keyB">
    ///     The second keyboard key to check.
    /// </param>
    /// <returns>
    ///     true if either of the specified keyboard key was just pressed;
    ///     otherwise, false.
    /// </returns>
    public bool WasKeyJustPressed(Keys keyA, Keys keyB) => WasKeyJustPressed(keyA) || WasKeyJustPressed(keyB);

    /// <summary>
    ///     Returns a value that indicates whether any of specified keyboard
    ///     keys was just pressed.
    /// </summary>
    /// <remarks>
    ///     "Just Pressed" means that the keyboard key was just pushed down on
    ///     the current frame and was up on the previous frame.  This means that
    ///     if they keyboard key is down for two frames in a row it is not
    ///     considered as "Just Pressed".
    /// </remarks>
    /// <param name="keyA">
    ///     The first keyboard key to check.
    /// </param>
    /// <param name="keyB">
    ///     The second keyboard key to check.
    /// </param>
    /// <param name="keyC">
    ///     The third keyboard key to check.
    /// </param>
    /// <returns>
    ///     true if any of the specified keyboard key was just pressed;
    ///     otherwise, false.
    /// </returns>
    public bool WasKeyJustPressed(Keys keyA, Keys keyB, Keys keyC) =>
        WasKeyJustPressed(keyA) || WasKeyJustPressed(keyB) || WasKeyJustPressed(keyC);

    /// <summary>
    ///     Returns a value that indicates whether any keyboard key was just
    ///     pressed.
    /// </summary>
    /// <remarks>
    ///     "Just Pressed" means that the keyboard key was just pushed down on
    ///     the current frame and was up on the previous frame.  This means that
    ///     if they keyboard key is down for two frames in a row it is not
    ///     considered as "Just Pressed".
    /// </remarks>
    /// <returns>
    ///     true if any keyboard key was just pressed; otherwise, false.
    /// </returns>
    public bool WasAnyKeyJustPressed() => CurrentState.GetPressedKeyCount() > PreviousState.GetPressedKeyCount();

    /// <summary>
    ///     Returns a value that indicates whether any keyboard key was just
    ///     pressed.
    /// </summary>
    /// <remarks>
    ///     "Just Pressed" means that the keyboard key was just pushed down on
    ///     the current frame and was up on the previous frame.  This means that
    ///     if they keyboard key is down for two frames in a row it is not
    ///     considered as "Just Pressed".
    /// </remarks>
    /// <returns>
    ///     true if any keyboard key was just pressed; otherwise, false.
    /// </returns>
    public bool WasAnyKeyJustPressed(out Keys[] keys)
    {
        Keys[] prevKeys = PreviousState.GetPressedKeys();
        Keys[] curKeys = CurrentState.GetPressedKeys();

        keys = curKeys.Except(prevKeys).ToArray();

        return keys.Length > 0;
    }

    /// <summary>
    ///     Returns a value that indicates whether the specified keyboard key
    ///     was just released.
    /// </summary>
    /// <remarks>
    ///     "Just Released" means that the keyboard key was just released  on
    ///     the current frame and was down on the previous frame.  This means
    ///     that if they keyboard key is up for two frames in a row it is not
    ///     considered as "Just Released".
    /// </remarks>
    /// <param name="key">
    ///     The keyboard key to check.
    /// </param>
    /// <returns>
    ///     true if the specified keyboard key was just released; otherwise,
    ///     false.
    /// </returns>
    public bool WasKeyJustReleased(Keys key) => CurrentState.IsKeyUp(key) && PreviousState.IsKeyDown(key);

    /// <summary>
    ///     Returns a value that indicates whether either of specified keyboard
    ///     keys was just released.
    /// </summary>
    /// <remarks>
    ///     "Just Released" means that the keyboard key was just released  on
    ///     the current frame and was down on the previous frame.  This means
    ///     that if they keyboard key is up for two frames in a row it is not
    ///     considered as "Just Released".
    /// </remarks>
    /// <param name="keyA">
    ///     The first keyboard key to check.
    /// </param>
    /// <param name="keyB">
    ///     The second keyboard key to check.
    /// </param>
    /// <returns>
    ///     true if either of the specified keyboard key was just released;
    ///     otherwise, false.
    /// </returns>
    public bool WasKeyJustReleased(Keys keyA, Keys keyB) => WasKeyJustReleased(keyA) || WasKeyJustReleased(keyB);

    /// <summary>
    ///     Returns a value that indicates whether any of specified keyboard
    ///     keys was just released.
    /// </summary>
    /// <remarks>
    ///     "Just Released" means that the keyboard key was just released  on
    ///     the current frame and was down on the previous frame.  This means
    ///     that if they keyboard key is up for two frames in a row it is not
    ///     considered as "Just Released".
    /// </remarks>
    /// <param name="keyA">
    ///     The first keyboard key to check.
    /// </param>
    /// <param name="keyB">
    ///     The second keyboard key to check.
    /// </param>
    /// <param name="keyC">
    ///     The third keyboard key to check.
    /// </param>
    /// <returns>
    ///     true if any of the specified keyboard key was just released;
    ///     otherwise, false.
    /// </returns>
    public bool WasKeyJustReleased(Keys keyA, Keys keyB, Keys keyC) =>
        WasKeyJustReleased(keyA) || WasKeyJustReleased(keyB) || WasKeyJustReleased(keyC);

    /// <summary>
    ///     Returns a value that indicates whether any keyboard key was just
    ///     released.
    /// </summary>
    /// <remarks>
    ///     "Just Released" means that the keyboard key was just released  on
    ///     the current frame and was down on the previous frame.  This means
    ///     that if they keyboard key is up for two frames in a row it is not
    ///     considered as "Just Released".
    /// </remarks>
    /// <returns>
    ///     true if any keyboard key was just released; otherwise, false.
    /// </returns>
    public bool WasAnyKeyJustReleased() => CurrentState.GetPressedKeyCount() < PreviousState.GetPressedKeyCount();

    /// <summary>
    ///     Returns a value that indicates whether any keyboard key was just
    ///     released.
    /// </summary>
    /// <remarks>
    ///     "Just Released" means that the keyboard key was just released  on
    ///     the current frame and was down on the previous frame.  This means
    ///     that if they keyboard key is up for two frames in a row it is not
    ///     considered as "Just Released".
    /// </remarks>
    /// <returns>
    ///     true if any keyboard key was just released; otherwise, false.
    /// </returns>
    public bool WasAnyKeyJustReleased(out Keys[] keys)
    {
        Keys[] prevKeys = PreviousState.GetPressedKeys();
        Keys[] curKeys = CurrentState.GetPressedKeys();

        keys = prevKeys.Except(curKeys).ToArray();

        return keys.Length > 0;
    }


}
