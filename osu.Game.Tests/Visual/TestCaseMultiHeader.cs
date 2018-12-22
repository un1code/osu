﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Game.Screens;
using osu.Game.Screens.Multi;

namespace osu.Game.Tests.Visual
{
    [TestFixture]
    public class TestCaseMultiHeader : OsuTestCase
    {
        public TestCaseMultiHeader()
        {
            int index = 0;

            OsuScreen currentScreen = new TestMultiplayerScreen(index);

            Children = new Drawable[]
            {
                currentScreen,
                new Header(currentScreen)
            };

            AddStep("push multi screen", () => currentScreen.Push(currentScreen = new TestMultiplayerScreen(++index)));
        }

        private class TestMultiplayerScreen : OsuScreen, IMultiplayerScreen
        {
            private readonly int index;

            public string ShortTitle => $"Screen {index}";

            public TestMultiplayerScreen(int index)
            {
                this.index = index;
            }

            public override string ToString() => ShortTitle;
        }
    }
}
