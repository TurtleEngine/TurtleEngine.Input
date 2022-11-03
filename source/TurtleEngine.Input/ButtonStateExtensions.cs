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

/// <summary>
///     Contains extension methods for the <see cref="ButtonState"/> enum
///     values.
/// </summary>
public static class ButtonStateExtensions
{
    /// <summary>
    ///     Returns a value that indicates whether the <see cref="ButtonState"/>
    ///     value is one that is equivilant to saying the button is currently
    ///     down.
    /// </summary>
    /// <param name="state">
    ///     The <see cref="ButtonState"/> value to check.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if the <see cref="ButtonState"/> value
    ///     is equivilant to saying the button is currently down; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public static bool IsDown(this ButtonState state) => state == ButtonState.Pressed;

    /// <summary>
    ///     Returns a value that indicates whether the <see cref="ButtonState"/>
    ///     value is one that is equivilant to saying the button is currently
    ///     up.
    /// </summary>
    /// <param name="state">
    ///     The <see cref="ButtonState"/> value to check.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if the <see cref="ButtonState"/> value
    ///     is equivilant to saying the button is currently up; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public static bool IsUp(this ButtonState state) => state == ButtonState.Released;
}
